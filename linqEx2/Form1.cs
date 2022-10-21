using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linqEx2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Student> myList = new List<Student>();
        BindingSource bs = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {

            //Create students
            Student s1 = new Student { Id = 123, FirstName = "Joe", Surname = "Bloggs", Course = "Economics" };
            Student s2 = new Student { Id = 456, FirstName = "Tom", Surname = "Jones", Course = "ICT" };
            Student s3 = new Student { Id = 789, FirstName = "Mary", Surname = "Murphy", Course = "Business" };
            Student s4 = new Student { Id = 423, FirstName = "Pat", Surname = "Karl", Course = "Economics" };
            Student s5 = new Student { Id = 223, FirstName = "Jim", Surname = "Doyles", Course = "ICT" };


            //Add Students to list
            myList.Add(s1);
            myList.Add(s2);
            myList.Add(s3);
            myList.Add(s4);
            myList.Add(s5);

            //Populate the DGV
            bs.DataSource = myList;
            dgv.DataSource = bs;
            lblCount.Text = myList.Count.ToString();

        }

        private void cboCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = cboCourses.SelectedItem.ToString();

            if (string.IsNullOrEmpty(query)) 
            {

                bs.DataSource = myList;

            }
            else
            {

                var data = myList.Where(s => s.Course.Contains(cboCourses.SelectedItem.ToString()));

                if(data.Count() > 0)
                {

                    bs.DataSource = data;

                }
                else
                {
                    bs.DataSource = null;
                    MessageBox.Show("No courses found!");

                }
            }

            bs.ResetBindings(false);
            lblCount.Text = bs.Count.ToString();

        }
    }
}
