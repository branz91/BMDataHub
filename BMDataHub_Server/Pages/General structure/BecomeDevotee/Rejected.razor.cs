
using Models;
using Radzen.Blazor;
using Buisness.Repository.IRepository;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Components;
using Buisness.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;


namespace BMDataHub_Server.Pages.Contacts
{
    public partial class Rejected : ComponentBase

    {
        [Inject] IAllContactsRepository AllContactsRepository { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [CascadingParameter] 
        public Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public string Country { get; set; }
        private string Title { get; set; } = " Rejected";
        string text = "Hi";
        RadzenDataGrid<AllContactsListDTO> grid;
        int count;
        private string avatarImagePath;


        protected IEnumerable<AllContactsListDTO> Contacts1 { set; get; } = new List<AllContactsListDTO>();

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationState;
            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                var uri = new Uri(NavigationManager.Uri);
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={uri.LocalPath}");
            }
            try
            {
                // Normalizza Country a minuscolo se non è null
                //var normalizedCountry = Country?.ToLower();

                //var allContacts = await AllContactsRepository.GetAllContacts();


                //Contacts1 = allContacts;

                //// Aggiorna lo stato del componente
                //StateHasChanged();

                var allContacts = await AllContactsRepository.GetAllContacts();
                var tempContacts = new List<AllContactsListDTO>();


                foreach (var contact in allContacts)
                {

                    if (contact.BecomeADevoteeStatus == "Candidate Rejected")

                        tempContacts.Add(contact);
                }


                // Assegna la lista temporanea a Courses1
                Contacts1 = tempContacts;

                StateHasChanged();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
        }

        private void NavigateTo(string url)
        {
            // Assicurati di avere NavigationManager iniettato nel tuo componente
            NavigationManager.NavigateTo(url);
        }

   

        protected override void OnInitialized()
        {
            Random rnd = new Random();
            int avatarNumber = rnd.Next(1, 21); // Genera un numero casuale tra 1 e 20.
            avatarImagePath = $"/Public/avatars/{avatarNumber}.png"; // Assumendo che il formato delle immagini sia .png.
        }

     

    }
}

