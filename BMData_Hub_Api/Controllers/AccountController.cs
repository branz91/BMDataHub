using Buisness.Repository.IRepository;
using Common;
using BMData_Hub_Api.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BMData_Hub_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly APISettings _apiSettings;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<APISettings> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _apiSettings = options.Value;
        }

        public bool IsRegistrationSuccessfull { get; private set; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new IdentityUser
            {
                UserName = userRequestDTO.Email,
                Email = userRequestDTO.Email,
                PhoneNumber = userRequestDTO.PhoneNo,
                EmailConfirmed = true,

            };

            var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponceDTO
                {
                    Errors = errors,
                    IsRegistrationSuccessfull = false
                });
            }
            var roleResult = await _userManager.AddToRoleAsync(user, SD.Role_Teacher);
            if (!roleResult.Succeeded)
            {
                var errors2 = result.Errors.Select(equals => equals.Description);
                return BadRequest(new RegistrationResponceDTO
                {
                    Errors = errors2,
                    IsRegistrationSuccessfull = false
                });
            }

            return StatusCode(201);


        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationDTO authenticationDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticationDTO.UserName, authenticationDTO.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(authenticationDTO.UserName);
                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        IsAuthSuccessfull = false,
                        ErrorMessage = "Invalid Authentication"
                    });
                }
                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _apiSettings.ValidIssuer,
                    audience: _apiSettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

             var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthenticationResponseDTO
                {
                    IsAuthSuccessfull = true,
                    Token = token,
                    UserDTO = new UserDTO
                    {
                        Name = user.UserName,
                        Id = user.Id,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber,
                    }

                });
            }
            else
            {
                return Unauthorized(new AuthenticationResponseDTO
                {
                    IsAuthSuccessfull = false,
                    ErrorMessage = "Invalid Authentication"
                });
            }
        
        }

        private SigningCredentials GetSigningCredentials()
        {
            if (string.IsNullOrEmpty(_apiSettings.SecretKey))
            {
                throw new InvalidOperationException("La chiave segreta non è configurata correttamente.");
            }

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiSettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        private async Task<List<Claim>> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.Id),
            };
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        [Authorize(Roles =SD.Role_Admin)]
        [HttpDelete("{userId}")]
        //[AllowAnonymous]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("L'ID dell'utente non può essere vuoto");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Utente con ID {userId} non trovato.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                // Gestisci i possibili errori restituiti da Identity
                return BadRequest(result.Errors.Select(e => e.Description));
            }

            return Ok($"Utente con ID {userId} è stato cancellato con successo.");
        }



    }
}
