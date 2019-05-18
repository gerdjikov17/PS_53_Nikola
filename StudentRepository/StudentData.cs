using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class StudentData
    {
        public static List<Student> TestStudents { get;  private set; }

        public static void InitTestStudents()
        {
            List<Student> testStudents = new List<Student>();
            Student test1 = new Student("Nikola", "Gerdzhikov", "Gerdzhikov", "FKST", "ITI", Degrees.BACHELOR, Statuses.CERTIFIED, 
                "501216022", 3, 10, 53, new DateTime(2016, 10, 10), new DateTime(2016, 5, 1));
            Student test2 = new Student("Ivan", "Petrov", "Petrov", "FKST", "ITI", Degrees.BACHELOR, Statuses.CERTIFIED,
                "1234", 3, 10, 53, new DateTime(2016, 8, 8), new DateTime(2016, 3, 3));
            testStudents.Add(test1);
            testStudents.Add(test2);
            TestStudents = testStudents;
        }

        public static Student IsThereStudent(string facultyNum)
        {
            Student studentMatching = (from filteredStudent in TestStudents where filteredStudent.facultyNumber.Equals(facultyNum) select filteredStudent).First();
            return studentMatching;
        }
    }
}
