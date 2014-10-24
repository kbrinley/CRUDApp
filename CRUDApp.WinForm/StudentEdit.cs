using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CRUDApp.Model;

namespace CRUDApp.WinForm
{
    public partial class StudentEdit : Form
    {
        StudentsModel TheStudent;
        StudentList ParentForm;

        public StudentEdit(StudentsModel theStudent, StudentList parentForm)
        {
            this.TheStudent = theStudent;
            this.ParentForm = parentForm;
            InitializeComponent();
        }

        private void StudentEdit_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = TheStudent.FirstName;
            txtMiddleName.Text = TheStudent.MiddleName;
            txtLastName.Text = TheStudent.LastName;
            txtAddressLine1.Text = TheStudent.AddressLine1;
            txtAddressLine2.Text = TheStudent.AddressLine2;
            txtCity.Text = TheStudent.AddressCity;
            txtState.Text = TheStudent.AddressState;
            txtZipCode.Text = TheStudent.AddressZip;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TheStudent.FirstName = txtFirstName.Text;
            TheStudent.MiddleName = txtMiddleName.Text;
            TheStudent.LastName = txtLastName.Text;
            TheStudent.AddressLine1 = txtAddressLine1.Text;
            TheStudent.AddressLine2 = txtAddressLine2.Text;
            TheStudent.AddressCity = txtCity.Text;
            TheStudent.AddressState = txtState.Text;
            TheStudent.AddressZip = txtZipCode.Text;

            var context = new ValidationContext(TheStudent, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            // False will cause this call to ignore Regex validation, which is always failing for some reason.
            var isValid = Validator.TryValidateObject(TheStudent, context, results, false);

            if (!isValid)
            {
                foreach (var result in results)
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
            else
            {
                bool saveResult = TheStudent.Save();
                if (saveResult)
                {
                    MessageBox.Show("Record Saved");
                    ParentForm.AddRecordToGrid(TheStudent);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occurred saving the record");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!TheStudent.Delete())
            {
                MessageBox.Show("An Error occurred deleting the record");
            }
            else
            {
                ParentForm.RemoveRecordFromGrid(TheStudent);
                this.Close();
            }
        }
    }
}
