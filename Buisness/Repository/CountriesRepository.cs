using AutoMapper;
using Buisness.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public CountriesRepository(ApplicationDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<CountriesDTO> CreateCountries(CountriesDTO countriesDTO)
        {
            Contacts countries = _mapper.Map<CountriesDTO, Contacts>(countriesDTO);

            //contacts.CreatedDate = DateTime.Now;
            //contacts.CreatedBy = "";

            var addedCountries = await _db.ContactsList.AddAsync(countries);
            await _db.SaveChangesAsync();
            return _mapper.Map<CountriesDTO>(addedCountries.Entity);
        }

        public async Task<IEnumerable<CountriesDTO>> GetAllCountries()
        {
            try
            {
                IEnumerable<Contacts> countries = await _db.ContactsList.ToListAsync();
                IEnumerable<CountriesDTO> CountriesDTOs = _mapper.Map<IEnumerable<CountriesDTO>>(countries);
                if (countries == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: _db.ContactsList ha restituito null.");
                    return Enumerable.Empty<CountriesDTO>(); // ritorna un enumerable vuoto.
                }

                if (CountriesDTOs == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: La mappatura ha restituito null.");
                    return Enumerable.Empty<CountriesDTO>(); // ritorna un enumerable vuoto.
                }

                return CountriesDTOs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore in GetAllContacts: {ex}");
                throw; // Rilancia l'eccezione o gestiscila come preferisci.
            }
        }
    }
}
