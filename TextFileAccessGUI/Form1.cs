using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileAccessGUI
{
    public partial class Form1 : Form
    {
        static string filePath = @"test.txt";
        static string outPath = @"peopleOut.txt";
        static List<Person> people = new List<Person>();
        static List<String> lines = File.ReadAllLines(filePath).ToList();
        static List<string> outputLines = new List<string>();
        static string firstName;
        static string lastName;
        static string URL;
        public Form1()
        {
            InitializeComponent();
            createListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Person p in people) 
            {
                //Add another line for the file output: 
                outputLines.Add("First Name: " + p.firstName + " Last Name: " +
                        p.lastName + "URL: " + p.Url + "\n");
                //Write to File
                File.WriteAllLines(outPath, outputLines);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Collect User Input from Form
            firstName = textBox1.Text;
            lastName = textBox2.Text;
            URL = textBox3.Text;

            //Create the Person Object
            Person p = new Person();
            p.firstName = firstName;
            p.lastName = lastName;
            p.Url = URL;

            //Add the person object to the People List
            people.Add(p);

            //Refresh the List View
            updateListView();
        }

        private void createListView() 
        {
            listView1.View = View.Details;
            listView1.Columns.Add("First Name", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Last Name", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("URL", 200, HorizontalAlignment.Left);
            listView1.GridLines = true;
        }

        private void updateListView() 
        {
            listView1.Items.Clear();

            foreach (Person p in people) 
            {
                string[] row = { p.firstName, p.lastName, p.Url };
                listView1.Items.Add(new ListViewItem(row));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');

                Person p = new Person();
                p.firstName = entries[0];
                p.lastName = entries[1];
                p.Url = entries[2];

                people.Add(p);
            }
            //Refresh the List View
            updateListView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
