using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repository.IRepository
{
    public interface IStudentsRepository
    {
        public Task<IEnumerable<StudentsDTO>> GetAllStudents();


        //public Task<List<CoursesDTO>> SetTeacherId(long? ProductId, CoursesDTO coursesDTO);


    }
}
