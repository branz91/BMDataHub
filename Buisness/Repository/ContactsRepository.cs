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
    public class ContactsRepository : IContactsRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public ContactsRepository(ApplicationDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ContactsDTO> CreateContact(ContactsDTO contactDTO)
        {
            Contacts contacts = _mapper.Map<ContactsDTO, Contacts>(contactDTO);

            //contacts.CreatedDate = DateTime.Now;
            //contacts.CreatedBy = "";

            var addedContact = await _db.ContactsList.AddAsync(contacts);
            await _db.SaveChangesAsync();
            return _mapper.Map<ContactsDTO>(addedContact.Entity);
        }

        public async Task<IEnumerable<ContactsDTO>> GetAllContacts()
        {
            try
            {
                IEnumerable<Contacts> contacts = await _db.ContactsList.ToListAsync();
                IEnumerable<ContactsDTO> ContactsDTOs = _mapper.Map<IEnumerable<ContactsDTO>>(contacts);
                if (contacts == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: _db.ContactsList ha restituito null.");
                    return Enumerable.Empty<ContactsDTO>(); // ritorna un enumerable vuoto.
                }

                if (ContactsDTOs == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: La mappatura ha restituito null.");
                    return Enumerable.Empty<ContactsDTO>(); // ritorna un enumerable vuoto.
                }

                return ContactsDTOs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore in GetAllContacts: {ex}");
                throw; // Rilancia l'eccezione o gestiscila come preferisci.
            }

        }

        public async Task<IEnumerable<ContactsDTO>> TeacherById(int? Id)
        {
            return _mapper.Map<IEnumerable<Contacts>, IEnumerable<ContactsDTO>>(
                            await _db.ContactsList.Where(x => x.id == Id).ToListAsync());

        }

    }
}
