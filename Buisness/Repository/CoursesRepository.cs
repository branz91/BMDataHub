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
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public CoursesRepository(ApplicationDBContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }



        public async Task<IEnumerable<CoursesDTO>> GetAllCourses()
        {
            try
            {
                IEnumerable<Courses> courses = await _db.CoursesList.ToListAsync();
                IEnumerable<CoursesDTO> CoursesDTOs = _mapper.Map<IEnumerable<CoursesDTO>>(courses);
                if (courses == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: _db.ContactsList ha restituito null.");
                    return Enumerable.Empty<CoursesDTO>(); // ritorna un enumerable vuoto.
                }

                if (CoursesDTOs == null)
                {
                    // Gestisci il caso o registra un messaggio di errore.
                    Console.WriteLine("Errore: La mappatura ha restituito null.");
                    return Enumerable.Empty<CoursesDTO>(); // ritorna un enumerable vuoto.
                }

                return CoursesDTOs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore in GetAllContacts: {ex}");
                throw; // Rilancia l'eccezione o gestiscila come preferisci.
            }

        }

        public async Task<CoursesDTO> UpdateCourse(int CourseId, CoursesDTO courseDTO)
        {
            try
            {


                if (CourseId == courseDTO.Id)
                {
                    Courses courseDetails = await _db.CoursesList.FindAsync(CourseId);
                    Courses course = _mapper.Map<CoursesDTO, Courses>(courseDTO, courseDetails);
                    var updatedCourse = _db.CoursesList.Update(course);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Courses, CoursesDTO>(updatedCourse.Entity);


                }
                else
                {
                    return null;
                    //invalid
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task ClearCoursesTable()
        {
            foreach (var course in _db.CoursesList)
            {
                _db.CoursesList.Remove(course);
            }
            await _db.SaveChangesAsync();
        }


        public async Task InsertCourses(IEnumerable<Courses> coursesEntities)
        {
            if (coursesEntities == null || !coursesEntities.Any())
            {
                return;
            }
            await _db.CoursesList.AddRangeAsync(coursesEntities);
            await _db.SaveChangesAsync();
        }



        //public async Task<CoursesDTO?> SetFees(int Id, CoursesDTO coursesDTO)
        //{
        //    var course = await _db.CoursesList.FindAsync(Id);

        //    if (course == null)
        //    {
        //        return null;
        //    }

        //    // Assumo che Transport, Rent, Food, e OtherFees siano le proprietà nel tuo modello Courses.
        //    // Aggiusta i nomi delle proprietà secondo il tuo modello.
        //    course.Transport = coursesDTO.Transport;
        //    course.Rent = coursesDTO.Rent;
        //    course.Food = coursesDTO.Food;
        //    course.OtherFees = coursesDTO.OtherFees;

        //    await _db.SaveChangesAsync();

        //    // Mappatura dell'entità aggiornata di nuovo in un DTO per il ritorno
        //    return _mapper.Map<CoursesDTO>(course);
        //}

        public async Task<List<CoursesDTO>> SetTeacherId(long? ProductId, CoursesDTO coursesDTO)
        {
            var coursesToUpdate = await _db.CoursesList
                                           .Where(c => c.ProductId == ProductId)
                                           .ToListAsync();

            if (!coursesToUpdate.Any())
            {
                return new List<CoursesDTO>();
            }

            foreach (var course in coursesToUpdate)
            {
                course.IdTeacher = coursesDTO.IdTeacher;
                // Aggiorna qui altre proprietà se necessario
            }

            await _db.SaveChangesAsync();

            // Mappatura delle entità aggiornate in una lista di DTO
            var updatedCoursesDTOs = coursesToUpdate.Select(course => _mapper.Map<CoursesDTO>(course)).ToList();

            return updatedCoursesDTOs;
        }


    }
}

