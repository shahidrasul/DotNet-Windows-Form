using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormStudent : Form
    {
        string connString = "data source=SHAHID;initial catalog=StudentManagementSystem;persist security info=True;user id=sss1;password=sss1;trustservercertificate=True";

        public FormStudent()
        {
            InitializeComponent();

            ShowAllStudents();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string strName = tbName.Text;
            string strFatherName = tbFName.Text;
            string strContactNumber = tbContactNumber.Text;

            if (isStudentExist(strName))
            {
                lbStatus.Text = "Student alrady exists.";
                return;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //sqlCommand.CommandText = "INSERT INTO tblStudent Values ('" + tbName + "','" +
                //    strFatherName + "','" + strContactNumber + "',1000)";

                sqlCommand.CommandText = "INSERT INTO tblStudent (Name, FatherName, Fee) Values " +
                    "(@Name, @FatherName, @Fee)";
                sqlCommand.Parameters.AddWithValue("@Name", strName);
                sqlCommand.Parameters.AddWithValue("@FatherName", strFatherName);
                //sqlCommand.Parameters.AddWithValue("@ContactNumber", strContactNumber);
                sqlCommand.Parameters.AddWithValue("@Fee", 1000);

                sqlCommand.ExecuteNonQuery();

                lbStatus.Text = "Student created successfully.";
            }

            ShowAllStudents();
        }

        private void ShowAllStudents()
        {
            IList<Student> lstStudents = new List<Student>();

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM tblStudent";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Student objStudent = new Student()
                    {
                        Name = sqlDataReader["Name"].ToString(),
                        FatherName = sqlDataReader["FatherName"].ToString(),
                        ContactNumber = sqlDataReader["ContactNumber"].ToString(),
                        Fee = double.Parse(sqlDataReader["Fee"].ToString())
                    };


                    lstStudents.Add(objStudent);
                }

                dataGrid.DataSource = lstStudents;
            }
        }

        private bool isStudentExist(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT COUNT(*) FROM tblStudent WHERE Name = '" + name + "'";

                return (int)sqlCommand.ExecuteScalar() > 0;

                //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                /*while (sqlDataReader.Read())
                {
                    return true;
                }*/

            }
        }

        private bool deleteStudent(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE tblStudent WHERE Name = '" + name + "'";

                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strName = tbName.Text.Trim();
            if (deleteStudent(strName))
            {
                lbStatus.Text = "Student deleted successfully.";
                ShowAllStudents();
            }
            else lbStatus.Text = "Student does not exists.";
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string ContactNumber { get; set; }
        public double Fee { get; set; }
    }
}
