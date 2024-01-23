using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface IAllContactsRepository
    {
        public Task<IEnumerable<AllContactsListDTO>> GetAllContacts();


    }
}
