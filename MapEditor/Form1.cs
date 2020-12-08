using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7Cassiar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateMapButton_Click(object sender, EventArgs e)
        {
            //any error messages get added to this string
            string errorMessage = "";

            //get the width and height values
            int.TryParse(widthTextBox.Text, out int width);
            int.TryParse(heightTextBox.Text, out int height);

            //test if width and height are outside requirements
            //if (width < 10)
            //{
            //    errorMessage += "Width must be atleast 10.\n";
            //}
            //else if (width > 30)
            //{
            //    errorMessage += "Width can't be over 30.\n";
            //}

            //if (height < 10)
            //{
            //    errorMessage += "Height must be atleast 10.\n";
            //}
            //else if (height > 30)
            //{
            //    errorMessage += "Width can't be over 30.";
            //}

            //if errormessage string has test then there was an error
            if(errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Error Creating Map", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //create map
            else
            {
                //width and height will always be 16x12
                MapEditor mapEditor = new MapEditor(width, height);
                mapEditor.Show();
            }
        }

        /// <summary>
        /// Open a file dialog to get the file the user wants to load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open a .map level file";
            openFileDialog.Filter = "Map Files | *.map_level";

            DialogResult dr = openFileDialog.ShowDialog();

            //if dialog is ok (user opened file)
            //then pass to map editor
            if (dr == DialogResult.OK)
            {
                MapEditor mapEditor = new MapEditor(openFileDialog.FileName);
                mapEditor.Show();
            }
        }
    }
}
