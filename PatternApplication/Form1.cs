using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
//...
using System.Xml;
using System.Xml.Serialization;
using System.IO;
//...ref
using Controller;

namespace PatternApplication
{
    public partial class Form1 : Form
    {
        PatternClass patternObject = new PatternClass();
        string existingFileName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int row;
            int col;
            bool rowSuccess = int.TryParse(txtRow.Text, out row);
            bool colSuccess = int.TryParse(txtCol.Text, out col);

            if (rowSuccess && colSuccess)
            {
                if (row < 1 || row > 5 || col < 0 || row > 5)
                {
                    MessageBox.Show("Eror - enter number 1 - 5 only");
                }
                else
                {
                    patternObject.Pattern[row - 1][col - 1] = true;
                    setPattern();
                    clearTxtFields();
                }
            }
            else
            {
                MessageBox.Show("Eror - invalid input");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setPattern();
        }

        private void clearTxtFields()
        {
            txtRow.Clear();
            txtCol.Clear();
        }

        private void setPattern()
        {
            //string msg = "";
            lblPattern.Text = "";
            foreach (bool[] row in patternObject.Pattern)
            {
                foreach (bool col in row)
                {
                    //msg += col.ToString();
                    if (col == false)
                    {
                        lblPattern.Text += "    ";
                    }
                    else
                    {
                        lblPattern.Text += "X ";
                    }
                }
                lblPattern.Text += "\n";
                //msg += "\n";
            }
            //MessageBox.Show(msg);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            patternObject = new PatternClass();
            setPattern();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (existingFileName == "")
            {
                MessageBox.Show("Please select a file to save");
                openFileDialog1.Filter = "XML files (*.xml) | *.xml";

                DialogResult result = openFileDialog1.ShowDialog();
                existingFileName = openFileDialog1.FileName;
                XMLManager.writeToXML(existingFileName, patternObject);
            }
            else
            {
                if (patternObject == null)
                {
                    patternObject = new PatternClass();
                }
                XMLManager.writeToXML("newPattern.xml", patternObject);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML files (*.xml) | *.xml";

            DialogResult result = openFileDialog1.ShowDialog();
            existingFileName = openFileDialog1.FileName;

            if (result == DialogResult.OK)
            {
                string existingFileName = openFileDialog1.FileName;

                //PATTERN 1 & existing
                patternObject = XMLManager.readListXML(existingFileName);

                //PATTERN 2
                //patternObject = XMLManager.readXML(existingFileName);

                setPattern();
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "XML files (*.xml) | *.xml";

            DialogResult result = saveFileDialog1.ShowDialog();
            existingFileName = saveFileDialog1.FileName;

            if (patternObject == null)
            {
                patternObject = new PatternClass();
            }
            XMLManager.writeToXML(existingFileName, patternObject);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int row;
            int col;
            bool rowSuccess = int.TryParse(txtRow.Text, out row);
            bool colSuccess = int.TryParse(txtCol.Text, out col);

            if (rowSuccess && colSuccess)
            {
                if (row < 1 || row > 5 || col < 0 || row > 5)
                {
                    MessageBox.Show("Eror - enter number 1 - 5 only");
                }
                else
                {
                    patternObject.Pattern[row - 1][col - 1] = false;
                    setPattern();
                    clearTxtFields();
                }
            }
            else
            {
                MessageBox.Show("Eror - invalid input");
            }
        }
    }
}
