using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{

    [Serializable]
    class NoStudentFoundException : Exception
    {
        public NoStudentFoundException()
        {

        }

        public NoStudentFoundException(string facultyNumber)
            : base(String.Format("No students found with faculty number: {0}", facultyNumber))
        {

        }

    }
}
