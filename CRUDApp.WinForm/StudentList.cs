using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CRUDApp.Model;

namespace CRUDApp.WinForm
{
    public partial class StudentList : Form
    {
        ICollection<StudentsModel> theStudents;

        public StudentList()
        {
            InitializeComponent();           
        }

        private void StudentList_OnLoad(object sender, EventArgs e)
        {
            theStudents = StudentsModel.GetRecords();
            foreach (var student in theStudents)
            {
                studentsModelBindingSource.Add(student);
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var newWindow = new StudentEdit(new StudentsModel(), this);
            newWindow.Visible = true;
        }

        private void studentsModelBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void studentsModelBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (e.NewObject == null) return;

            bool returnValue = ((StudentsModel)e.NewObject).Save();
            
            if (!returnValue)
            {
                MessageBox.Show("Error Inserting new Student");
            }
        }

        private void studentsModelBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            bool returnValue = ((StudentsModel)((BindingSource)sender).Current).Save();
            if (!returnValue)
            {
                MessageBox.Show("Error Updating Student");
            }
        }

        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var student = (StudentsModel)studentsModelBindingSource[e.RowIndex];

            //MessageBox.Show(String.Format("Selected Student: {0} {1} {2}", student.FirstName, student.MiddleName, student.LastName));

            var newWindow = new StudentEdit(student, this);
            newWindow.Visible = true;
        }

        private void dgvStudents_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void StudentList_Activated(object sender, EventArgs e)
        {
            
        }

        public void RemoveRecordFromGrid(StudentsModel theStudent)
        {
            studentsModelBindingSource.Remove(theStudent);
        }

        public void AddRecordToGrid(StudentsModel theStudent)
        {
            if (!studentsModelBindingSource.Contains(theStudent))
                studentsModelBindingSource.Add(theStudent);
        }
    }
}
