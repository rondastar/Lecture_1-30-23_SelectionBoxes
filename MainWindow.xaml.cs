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

namespace Lecture_1_30_23_SelectionBoxes
    // Ronda Rutherford
    // Lecture Notes - 1-30-23 - Selection Boxes
    // 2-4-23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = null;

        public MainWindow()
        {
            InitializeComponent();

            // How to add items to a selection box
            // Add to a selection box by accessing its items list
            Preload();
            DisplayToListBox();
            DisplayToComboBox();

            //// Add an iten to combo box
            //cbDisplay.Items.Add("Breshma");
            // Automatically select the first item in our listbox on load
            lbDisplay.SelectedIndex = 0;
            cbDisplay.SelectedIndex = 0;
        }

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtAddToList.Text;
            lbDisplay.Items.Add(userInput);

        } // btnAddToList_Click

        public void DisplayToListBox()
        {
            // Use the .Clear() method to clear all items from our listbox - this keeps the list box and the students list synchronized
            lbDisplay.Items.Clear();
            //Displays the list of students to the list box
            for (int i = 0; i < students.Count; i++)
            {
                //string firstName = students[i].FirstName;
                //string lastName = students[i].LastName;
                //string fullName = $"{firstName} {lastName}";
                //lbDisplay.Items.Add(fullName);
                lbDisplay.Items.Add(students[i]);
            }
        }
        public void DisplayToComboBox()
        {
            // Use the .Clear() method to clear all items from our listbox - this keeps the list box and the students list synchronized
            cbDisplay.Items.Clear();
            //Displays the list of students to the list box
            for (int i = 0; i < students.Count; i++)
            {
                //string firstName = students[i].FirstName;
                //string lastName = students[i].LastName;
                //string fullName = $"{firstName} {lastName}";
                //cbDisplay.Items.Add(fullName);
                cbDisplay.Items.Add(students[i]);
            }
        }
        private void btnDisplaySelectedStudent_Click(object sender, RoutedEventArgs e)
        {
            // You can access the selected item by using .SelectedIndex
            int selectedIndex = lbDisplay.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select a name from the list box.");
            }
            else
            {
                //Student selectedStudent = students[selectedIndex];
                //txtFirstName.Text = selectedStudent.FirstName;
                //txtLastName.Text = selectedStudent.LastName;
                //txtCSIGrade.Text = selectedStudent.CSIGrade.ToString();
                //txtGenEdGrade.Text = selectedStudent.GenEdGrade.ToString();
                DisplayStudentInformation(selectedStudent);
            }
        } // btnDisplaySelectedStudent_Click()
        public void DisplayStudentInformation(Student student)
        {
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtCSIGrade.Text = student.CSIGrade.ToString();
            txtGenEdGrade.Text = student.GenEdGrade.ToString();
        }
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string csi = txtCSIGrade.Text;
            string genEd = txtGenEdGrade.Text;

            int csigrade = int.Parse(csi);
            int genEdGrade = int.Parse(genEd);

            // I want to create a new instance of student,
            // Add our text information to it,
            // Add it to our students list,
            students.Add(new Student(fName, lName, csigrade, genEdGrade));
            // Then see the name appear in the list box
            DisplayToListBox();
        } // btnAddStudent_Click()

        private void btnRemoveSelectedStudent_Click(object sender, RoutedEventArgs e)
        {
            //// Remove by index
            //int selectedIndex = lbDisplay.SelectedIndex;
            //students.RemoveAt(selectedIndex);
            //DisplayToListBox();

            // Remove by object
            //int selectedIndex = lbDisplay.SelectedIndex;
            //Student selectedStudent = students[selectedIndex];
            students.Remove(selectedStudent);
            DisplayToListBox();
        }

        public void Preload()
        {

            //Student student1 = new Student()
            //{
            //    FirstName = "Will",
            //    LastName = "Cram",
            //    CSIGrade = 67,
            //    GenEdGrade = 97

            ////};
            //students.Add(student1);
            Student student = new Student("Will", "Cram", 101, 97);
            // Saves the new student to the list
            students.Add(student);
            students.Add(new Student("Hannah", "Angel", 102, 98));
            students.Add(new Student("Dylan", "Register", 101, 99));
            students.Add(new Student("Kris", "Taniguchi", 100, 96));
            // variable name for Hannah Angel is students[1]

        }

        public void DisplayUpdatedInformation(int selectedIndex)
        {
            selectedStudent = students[selectedIndex];
            DisplayStudentInformation(selectedStudent);
        }

        private void lbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int selectedIndex = lbDisplay.SelectedIndex;
            //selectedStudent = students[selectedIndex];
            //DisplayStudentInformation(selectedStudent);
            DisplayUpdatedInformation(lbDisplay.SelectedIndex);
        }

        private void cbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int selectedIndex = cbDisplay.SelectedIndex;
            DisplayUpdatedInformation(cbDisplay.SelectedIndex);
        }
    }

    // What "Item" in your listbox and combo box do you add objects to to display them?
    // Item

    // What's the property name that returns the selected item's index?
    // .SelectedIndex

    // What's the difference between the combo box and the list box?
    // they function simmilarly, but the combo box displays items in a dropdown box, while the list box displays items in a static box (looks similar to a rich text box).

    // You remove an item from your list box but not the list of data you've associated it with. Is this a problem? Yes or no? And why?
    // Yes this is a problem, because the index of the list box is used to call the data from the list.
    // If someone selects an item from the index the item was removed from, or any of the following indices, the wrong data will be called. 
    // It is important to synchronize your data. (Similar to model view control - some code interacts with the front end, some interacts with back end; keep the two separate)

    // What kind of event is created when you double-click a combo or list box?
    // SelectionChanged() - this event runs when the item selected in the listbox changes

}
