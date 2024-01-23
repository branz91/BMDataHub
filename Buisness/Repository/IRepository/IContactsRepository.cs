using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface IContactsRepository
    {
        public Task<ContactsDTO> CreateContact(ContactsDTO contactDTO);
        public Task<IEnumerable<ContactsDTO>> GetAllContacts();

        public Task<IEnumerable<ContactsDTO>> TeacherById(int? Id);

    }
}
