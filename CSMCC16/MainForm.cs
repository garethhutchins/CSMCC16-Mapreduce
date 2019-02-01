using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace CSMCC16
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            //Browse to the pasenger file
            //empty the file path from the browser
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        
            if (!openFileDialog1.FileName.Equals("")) {
                //If a file has been selected, add it to the text box
                txt_pdf.Text = openFileDialog1.FileName;
            }
        }

        private void btn_apt_Click(object sender, EventArgs e)
        {
            //Browse to the airport file
            //empty the file path from the browser
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            if (!openFileDialog1.FileName.Equals(""))
            {
                //If a file has been selected, add it to the text box
                txt_apt.Text = openFileDialog1.FileName;
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            //browse to the output directory
            //empty the browser first
            folderBrowserDialog1.SelectedPath = "";
            folderBrowserDialog1.ShowDialog();
            if (!folderBrowserDialog1.SelectedPath.Equals(""))
            {
                txt_output.Text = folderBrowserDialog1.SelectedPath;
            }
        }
       

        private void btn_run_Click(object sender, EventArgs e)
        {
            //Check to see if all of the values set are ok
            Boolean OK = true;
            //Passenger File
            if (txt_pdf.Text.Equals(""))
            {
                MessageBox.Show("Passenger File Required");
                OK = false;
            }
            else
            {
                //Check it exists
                if (!File.Exists(txt_pdf.Text))
                {
                    MessageBox.Show("Passenger File Does not Exist");
                    OK = false;
                }
            }

            //Airport File
            if (txt_apt.Text.Equals(""))
            {
                MessageBox.Show("Airport File Required");
                OK = false;
            }
            else
            {
                //Check it exists
                if (!File.Exists(txt_pdf.Text))
                {
                    MessageBox.Show("Airport File Does not Exist");
                    OK = false;
                }
            }

            //Output Directory
            if (txt_output.Text.Equals(""))
            {
                MessageBox.Show("Ouput Directiry Required");
                OK = false;
            }
            else
            {
                // check the directory existis
                if (!Directory.Exists(txt_output.Text))
                {
                    MessageBox.Show("Output Directory Does not Exist");
                }
            }
            //Check to see if it's all ok and then run
            if (OK)
            {
                //Clear the log
                txt_log.Text = "";
                txt_log.Text = "Starting New Mapreduce";
                Mapper mapper = new Mapper();
                mapper.AirportFile = txt_apt.Text;
                mapper.PassengerFile = txt_pdf.Text;
                mapper.outputPath = txt_output.Text;
                mapper.log = txt_log;
                mapper.Map();
            }
            else
            {

            }
        }




    }
}
