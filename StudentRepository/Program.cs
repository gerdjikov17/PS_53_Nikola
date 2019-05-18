using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            string facultyNum;
            StudentData.InitTestStudents();
            Console.WriteLine("Search user by faculty num");
            facultyNum = Console.ReadLine();
            Student studentMatching = StudentData.IsThereStudent(facultyNum);
            if (studentMatching != null)
            {
                File.AppendAllText("../../testFacultyNumber.txt", studentMatching.ToString());
            }
            else
            {
                Console.WriteLine("No matching student");
            }
        }
    }
}
