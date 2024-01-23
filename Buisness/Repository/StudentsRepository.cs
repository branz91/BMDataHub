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
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public StudentsRepository(ApplicationDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }



        public async Task<IEnumerable<StudentsDTO>> GetAllStudents()
        {
            try
            {
                IEnumerable<Courses> students = await _db.CoursesList.ToListAsync();
                IEnumerable<StudentsDTO> StudentsDTOs = _mapper.Map<IEnumerable<StudentsDTO>>(students);
                if (students == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: _db.ContactsList ha restituito null.");
                    return Enumerable.Empty<StudentsDTO>(); // ritorna un enumerable vuoto.
                }

                if (StudentsDTOs == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: La mappatura ha restituito null.");
                    return Enumerable.Empty<StudentsDTO>(); // ritorna un enumerable vuoto.
                }

                return StudentsDTOs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore in GetAllContacts: {ex}");
                throw; // Rilancia l'eccezione o gestiscila come preferisci.
            }

        }

     

        //public async Task<List<CoursesDTO>> SetTeacherId(long? ProductId, CoursesDTO coursesDTO)
        //{
        //    var coursesToUpdate = await _db.CoursesList
        //                                   .Where(c => c.ProductId == ProductId)
        //                                   .ToListAsync();

        //    if (!coursesToUpdate.Any())
        //    {
        //        return new List<CoursesDTO>();
        //    }

        //    foreach (var course in coursesToUpdate)
        //    {
        //        course.IdTeacher = coursesDTO.IdTeacher;
        //        // Aggiorna qui altre proprietà se necessario
        //    }

        //    await _db.SaveChangesAsync();

        //    // Mappatura delle entità aggiornate in una lista di DTO
        //    var updatedCoursesDTOs = coursesToUpdate.Select(course => _mapper.Map<CoursesDTO>(course)).ToList();

        //    return updatedCoursesDTOs;
        //}

      
    }
}

