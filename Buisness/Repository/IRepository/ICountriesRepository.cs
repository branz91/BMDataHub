using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface ICountriesRepository
    {
        public Task<CountriesDTO> CreateCountries(CountriesDTO countriesDTO);
        public Task<IEnumerable<CountriesDTO>> GetAllCountries();
    }
}
