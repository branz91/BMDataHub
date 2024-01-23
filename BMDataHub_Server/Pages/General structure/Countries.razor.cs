
using Models;
using Radzen.Blazor;
using Buisness.Repository.IRepository;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Humanizer;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BMDataHub_Server.Pages.Countries
{
    public partial class Countries : ComponentBase

    {
        [Inject] ICountriesRepository CountriesRepository { get; set; }
        [Inject] ICoursesRepository CoursesRepository { get; set; }
        [Inject] IFeesRepository FeesRepository { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] IJSRuntime JSRuntime { get; set; }


        string text = "Hi";
        RadzenDataGrid<CountriesDTO> grid;
        int count;
        private string avatarImagePath;


        protected IEnumerable<CountriesDTO> Countries1 { set; get; } = new List<CountriesDTO>();
       


        protected override async Task OnInitializedAsync()
        {
            try
            {


                var allCourses = await  CoursesRepository.GetAllCourses();

                var allFees = await FeesRepository.GetAllFees();

                var allCountries = await CountriesRepository.GetAllCountries();

                foreach (var course in allCourses)
                {
                    course.FeesAmount = allFees.Where(fee => fee.ProductId == course.ProductId).Sum(fee => fee.Price);
                }


                foreach (var country in allCountries)
                {
                    country.TotalIncome = allCourses
                        .Where(course => course.IdTeacher == country.id)
                        .Sum(course => course.LineItemPrice);

                    country.TotalFees = 0.0;

                    country.TotalFees = allCourses
                         .Where(course => course.IdTeacher == country.id)
                         .Select(course => course.FeesAmount)
                         .FirstOrDefault();
                }

                // Raggruppamento per 'country_calculated' (case-insensitive) e ordinamento
                var groupedCountries = allCountries
                        .GroupBy(c => c.country_calculated.ToLower()) // Raggruppa (case-insensitive)
                        .Select(g => new
                        {
                            Country = g.Key,
                            TotalIncome = g.Sum(x => x.TotalIncome),
                            TotalFees = g.Sum(x=>x.TotalFees),
                            FirstCountry = g.First(), // Primo elemento di ogni gruppo
                            TotalTeachers = g.Count(), // Conteggio degli elementi per gruppo
                           
                        })
                        .OrderBy(x => x.Country) // Ordina i risultati
                        .ToList();

                    // Assegna il conteggio a 'TotalTeachers' di ciascun oggetto DTO
                    Countries1 = groupedCountries
                        .Select(x =>
                        {
                            var dto = x.FirstCountry;
                            dto.TotalTeachers = x.TotalTeachers;
                            dto.TotalIncome = x.TotalIncome;
                            dto.TotalFees = x.TotalFees;
                            dto.SharingBMInt = CalcolaPercentuale(x.TotalIncome - x.TotalFees, 2, 0);
                            dto.SharingCountry = CalcolaPercentuale(x.TotalIncome - x.TotalFees, 3, 0);
                            dto.SharingTeachers = CalcolaPercentuale(x.TotalIncome - x.TotalFees, 1, 0);
                            return dto;
                        })
                        .ToList();





        //await JSRuntime.InvokeVoidAsync("console.log", InitializedCountries);





        // Aggiorna lo stato del componente.
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

