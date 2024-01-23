
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
    public partial class ContactsList : ComponentBase

    {
        [Inject] IContactsRepository ContactsRepository { get; set; }

        [Inject] ICoursesRepository CoursesRepository { get; set; }
        [Inject] IFeesRepository FeesRepository { get; set; }



        [Inject] NavigationManager NavigationManager { get; set; }

        [CascadingParameter] 
        public Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public string Country { get; set; }
        private string Title { get; set; } = " All Countries";
        string text = "Hi";
        RadzenDataGrid<ContactsDTO> grid;
        int count;
        private string avatarImagePath;


        protected IEnumerable<ContactsDTO> Contacts1 { set; get; } = new List<ContactsDTO>();

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
                var normalizedCountry = Country?.ToLower();

                var allContacts = await ContactsRepository.GetAllContacts();
                var allCourses = await CoursesRepository.GetAllCourses();
                var allFees = await FeesRepository.GetAllFees();

                foreach(var course in allCourses)
                {
                    course.FeesAmount = allFees.Where(x => x.ProductId == course.ProductId).Sum(y => y.Price);
                }

                if (normalizedCountry != null)
                {
                    // Utilizza il confronto case-insensitive
                    Contacts1 = allContacts
                        .Where(contact => contact.country_calculated?.ToLower() == normalizedCountry)
                        .ToList();

                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    Title = " "+textInfo.ToTitleCase(normalizedCountry);
                }
                else
                {
                    Contacts1 = allContacts;
                }

                foreach (var contact in Contacts1)
                {
                    contact.TotalIncome = allCourses.Where(x => x.IdTeacher == contact.id).Sum(y => y.LineItemPrice);
                    contact.TotalFees = allCourses.Where(x => x.IdTeacher == contact.id).Select(y => y.FeesAmount).FirstOrDefault();
                    contact.SharingBMInt = CalcolaPercentuale(contact.TotalIncome - contact.TotalFees, 2, 0.0);
                    contact.SharingCountry = CalcolaPercentuale(contact.TotalIncome - contact.TotalFees, 3, 0.0);
                    contact.SharingTeachers = CalcolaPercentuale(contact.TotalIncome - contact.TotalFees, 1, 0.0);
                    contact.TotalCourses = allCourses.GroupBy(y=>y.ProductId).Where(x => x.FirstOrDefault().IdTeacher == contact.id).Count();

                }

                // Aggiorna lo stato del componente
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

        private void CreateContact()
        {
            NavigationManager.NavigateTo("Contacts-list/create");
        }


        protected override void OnInitialized()
        {
            Random rnd = new Random();
            int avatarNumber = rnd.Next(1, 21); // Genera un numero casuale tra 1 e 20.
            avatarImagePath = $"/Public/avatars/{avatarNumber}.png"; // Assumendo che il formato delle immagini sia .png.
        }

        public double? CalcolaPercentuale(double? numero, int opzione, double? tax)
        {

            switch (opzione)
            {
                case 1:
                    return numero * 0.50 - numero * 0.50 * (tax / 100);
                case 2:
                    return numero * 0.0 - numero * 0.0 * (tax / 100);
                case 3:
                    return numero * 0.50 - numero * 0.50 * (tax / 100);
                case 4:
                    return tax * 10;
                default:
                    throw new ArgumentException("Opzione non valida. Deve essere 1, 2 o 3.");
            }
        }

    }
}

