using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentRepository;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StudentInformation : Window
    {
        Student student;

        public StudentInformation()
        {
            InitializeComponent();
            this.student = new Student("Nikola", "Georgiev", "Gerdzhikov", "FKST", "ITI", Degrees.BACHELOR,
                Statuses.CERTIFIED, "501216022", 3, 10, 53, new DateTime(2019, 1, 15), new DateTime(2019, 2, 12));
            FillTextBoxes(this.student);
        }

        private void FillTextBoxes(Student student)
        {
            // personal information
            nameTextBox.Text = student.firstName;
            surNameTextBox.Text = student.secondName;
            familyNameTextBox.Text = student.familyName;

            // student information
            facultyNameTextBox.Text = student.faculty;
            specialtyTextBox.Text = student.specialty;
            degreeTextBox.Text = student.degree.ToString();
            statusTextBox.Text = student.status.ToString();
            facultyNumberTextBox.Text = student.facultyNumber;
            courseTextBox.Text = student.course.ToString();
            streamNumberTextBox.Text = student.stream.ToString();
            groupNumberTextBox.Text = student.group.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAllTextBoxes(personalInformationGrid);
            ClearAllTextBoxes(studentInformationGrid);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (student == null) return;
            PrintStudentInformation(this.student);
        }

        private void ToggleTextBoxesButton_Click(object sender, RoutedEventArgs e)
        {
            // get and toggle last enabled
            bool enabled = !nameTextBox.IsEnabled;
            ToggleAllTextBoxes(personalInformationGrid, enabled);
            ToggleAllTextBoxes(studentInformationGrid, enabled);
        }
        
        private void ClearAllTextBoxes(Grid grid)
        {
            foreach (var item in grid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void ToggleAllTextBoxes(Grid grid, bool enabled)
        {
            foreach (var item in grid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = enabled;
                }
            }
        }

        private void PrintStudentInformation(Student student)
        {
            Console.WriteLine(student.ToString());
        }
    }
}
