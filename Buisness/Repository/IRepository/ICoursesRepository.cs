using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface ICoursesRepository
    {
        public Task<IEnumerable<CoursesDTO>> GetAllCourses();

        //public Task<CoursesDTO> SetFees(int Id, CoursesDTO coursesDTO);

        public Task<List<CoursesDTO>> SetTeacherId(long? ProductId, CoursesDTO coursesDTO);
        public Task<CoursesDTO> UpdateCourse(int CourseId, CoursesDTO coursesDTO);

        Task ClearCoursesTable();
        Task InsertCourses(IEnumerable<Courses> courses);
    }
}
