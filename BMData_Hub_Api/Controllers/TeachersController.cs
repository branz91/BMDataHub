using Buisness.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BMData_Hub_Api.Controllers
{

    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private readonly IContactsRepository _teacherRepository;

        public TeachersController(IContactsRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var allTeachers = await _teacherRepository.GetAllContacts();
            return Ok(allTeachers);
        }
       
    }

}
