using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository

{
    class StudentValidation
    {

        public Student GetStudentDataByUser(User user)
        {
            Student student = StudentData.IsThereStudent(user.facultyNumber);
            if (student == null)
            {
                throw new NoStudentFoundException(user.facultyNumber);
            }
            return student;
        }
    }
}
