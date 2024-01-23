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
    public class AllContactsRepository : IAllContactsRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public AllContactsRepository(ApplicationDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }


        public async Task<IEnumerable<AllContactsListDTO>> GetAllContacts()
        {
            try
            {
                IEnumerable<AllContactsList> allContacts = await _db.AllContactsList.ToListAsync();
                IEnumerable<AllContactsListDTO> allContactsDTOs = _mapper.Map<IEnumerable<AllContactsListDTO>>(allContacts);
                if (allContacts == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: _db.ContactsList ha restituito null.");
                    return Enumerable.Empty<AllContactsListDTO>(); // ritorna un enumerable vuoto.
                }

                if (allContactsDTOs == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: La mappatura ha restituito null.");
                    return Enumerable.Empty<AllContactsListDTO>(); // ritorna un enumerable vuoto.
                }

                return allContactsDTOs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore in GetAllContacts: {ex}");
                throw; // Rilancia l'eccezione o gestiscila come preferisci.
            }

        }

    }
}
