using Buisness.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.ApiService;
using Buisness.Repository.IRepository;

namespace Buisness.ApiService
{
    public class DataUpdateService
    {
        private readonly ApiServices _apiService;
        private readonly CoursesRepository _coursesRepository;

        public DataUpdateService(ApiServices apiService, CoursesRepository coursesRepository)
        {
            _apiService = apiService;
            _coursesRepository = coursesRepository;
        }

    

        public async Task UpdateCoursesData()
                    {
            var coursesData = await _apiService.FetchDataFromApiAsync();

            // Assicurati che coursesData non sia null o vuoto prima di procedere
            _coursesRepository.ClearCoursesTable();
            _coursesRepository.InsertCourses(coursesData);
        }
    }
}


//public async Task UpdateCoursesData()
//{
//    var coursesDataDTO = await _apiService.FetchDataFromApiAsync();

//    if (coursesDataDTO == null || !coursesDataDTO.Any())
//    {
//        return;
//    }

//    // Mappa CoursesDTO a Courses
//    var coursesEntities = _mapper.Map<IEnumerable<Courses>>(coursesDataDTO);

//    if (coursesEntities == null || !coursesEntities.Any())
//    {
//        // Gestisci il caso di dati null o vuoti dopo la mappatura
//        return;
//    }

//    // Pulisci la tabella prima di inserire i nuovi dati
//    await _coursesRepository.ClearCoursesTable();

//    // Inserisci le entità nel database
//    await _coursesRepository.InsertCourses(coursesEntities);