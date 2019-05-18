using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Student
    {
        public string firstName;
        public string secondName;
        public string familyName;
        public string faculty;
        public string specialty;
        public Degrees degree;
        public Statuses status;
        public string facultyNumber;
        public ushort course;
        public ushort stream;
        public ushort group;
        public DateTime lastZaverkaDate;
        public DateTime lastPaidTaxDate;

        public Student(string firstName, string secondName, string familyName, string faculty, string specialty,
        Degrees degree, Statuses status, string facultyNumber, ushort course, ushort stream, ushort group,
        DateTime lastZaverka, DateTime lastPaidTax)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.familyName = familyName;
            this.faculty = faculty;
            this.specialty = specialty;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.stream = stream;
            this.group = group;
            this.lastZaverkaDate = lastZaverka;
            this.lastPaidTaxDate = lastPaidTax;
        }

        public override string ToString()
        {
            return "firstName: " + firstName + Environment.NewLine + 
                "secondName: " + secondName + Environment.NewLine +
                "familyName: " + familyName + Environment.NewLine + 
                "faculty: " + faculty + Environment.NewLine + 
                "specialty: " + specialty + Environment.NewLine + 
                "degree: " + degree.ToString() + Environment.NewLine + 
                "status: " + status.ToString() + Environment.NewLine + 
                "facultyNumber: " + facultyNumber + Environment.NewLine + 
                "course: " + course.ToString() + Environment.NewLine + 
                "stream: " + stream + Environment.NewLine + 
                "group: " + group.ToString() + Environment.NewLine + 
                "lastZaverka: " + lastZaverkaDate.ToString() + Environment.NewLine + 
                "lastPaidTaxDate: " + lastPaidTaxDate.ToString();
        }
    }
        
}
