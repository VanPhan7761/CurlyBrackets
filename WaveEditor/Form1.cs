using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WaveEditor
{
    /// <summary>
    /// A class to simplify making waves for the GDAPS 2 game
    /// Author: Cassiar 
    /// Feburary 27 2020
    /// </summary>
    public partial class Form1 : Form
    {
        //lists to hold the corresponding text boxes
        private List<ComboBox> enemyTypeComboBoxes;
        private List<ComboBox> enemyLevelComboBoxes;
        private List<TextBox> amountTextBoxes;
        private List<TextBox> enterTimeTextBoxes;
        private List<TextBox> tickAmountTextBoxes;

        private List<Button> deleteButtons;

        //keeping textbox size constant
        private const int textBoxWidth = 100;
        private const int textBoxHeight = 20;
        private const int textBoxSpacing = 6;

        //file path
        private string path;
        private string name;

        //has been saved
        private bool saved = true;

        /// <summary>
        /// When form is first opened this method runs
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form loads in, add the text boxes
        /// and assign the text boxes to their lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //make sure sender is correct
            if(sender is Form1)
            {
                //intialize lists
                enemyTypeComboBoxes = new List<ComboBox>(5);
                enemyLevelComboBoxes = new List<ComboBox>(5);
                amountTextBoxes = new List<TextBox>(5);
                enterTimeTextBoxes = new List<TextBox>(5);
                tickAmountTextBoxes = new List<TextBox>(5);

                deleteButtons = new List<Button>(5);

                for (int i = 0; i < 5; i++)
                {
                    AddNewLine();
                }
            }
        }

        /// <summary>
        /// Adds a new line of text boxes to the screen.
        /// Hooks up text boxes to their respective lists as well.
        /// </summary>
        private void AddNewLine()
        {
            //getting location of labels to simplify creation of text boxes
            int enemyX = enemyLabel.Location.X;
            int enemyY = enemyLabel.Location.Y;

            int levelX = enemyLevelLabel.Location.X;
            int levelY = enemyLevelLabel.Location.Y;

            int amountX = amountLabel.Location.X;
            int amountY = amountLabel.Location.Y;

            int enterTimeX = enterTimeLabel.Location.X;
            int enterTimeY = enterTimeLabel.Location.Y;

            int tickAmountX = tickAmountLabel.Location.X;
            int tickAmountY = tickAmountLabel.Location.Y;

            //create a enemy text box under the enemy label
            //and add it to the list
            enemyTypeComboBoxes.Add(new ComboBox()
            {
                //adjusting for size of label and previous text boxes
                //the 4 makes it not hit the label, and the 6 adds a space between text boxes
                Location = new Point(enemyX,
                            enemyY + enemyLabel.Height + 4 + (enemyTypeComboBoxes.Count * (textBoxHeight + textBoxSpacing))),
                Name = "enemyTypeComboBox" + enemyTypeComboBoxes.Count,
                Size = new Size(textBoxWidth, textBoxHeight),
                DropDownStyle = ComboBoxStyle.DropDownList
            });

            //adding the enemy types
            enemyTypeComboBoxes[enemyTypeComboBoxes.Count - 1].Items.AddRange(new String[] { "", "Armored", "Boss", "Fast", "Regular" });

            //create a enemy level box under the enemy label
            //and add it to the list
            enemyLevelComboBoxes.Add(new ComboBox()
            {
                //adjusting for size of label and previous text boxes
                //the 4 makes it not hit the label, and the 6 adds a space between text boxes
                Location = new Point(levelX,
                            levelY + enemyLevelLabel.Height + 4 + (enemyLevelComboBoxes.Count * (textBoxHeight + textBoxSpacing))),
                Name = "enemyLevelComboBox" + enemyLevelComboBoxes.Count,
                Size = new Size(textBoxWidth, textBoxHeight),
                DropDownStyle = ComboBoxStyle.DropDownList
            });

            //adding the enemy levels
            enemyLevelComboBoxes[enemyLevelComboBoxes.Count - 1].Items.AddRange(new String[] {"", "1", "2", "3", "4", "5" });

            //create a amount text box under the amount label
            //and add it to the list
            amountTextBoxes.Add(new TextBox()
            {
                //adjusting for size of label and previous text boxes
                //the 4 makes it not hit the label, and the 6 adds a space between text boxes
                Location = new Point(amountX,
                            amountY + amountLabel.Height + 4 + (amountTextBoxes.Count * (textBoxHeight + textBoxSpacing))),
                Name = "amountTextBox" + amountTextBoxes.Count,
                Size = new Size(textBoxWidth, textBoxHeight)
            });

            //create a enter time text box under the enter time label
            //and add it to the list
            enterTimeTextBoxes.Add(new TextBox()
            {
                //adjusting for size of label and previous text boxes
                //the 4 makes it not hit the label, and the 6 adds a space between text boxes
                Location = new Point(enterTimeX,
                            enterTimeY + enterTimeLabel.Height + 4 + (enterTimeTextBoxes.Count * (textBoxHeight + textBoxSpacing))),
                Name = "enterTimeTextBox" + enemyTypeComboBoxes.Count,
                Size = new Size(textBoxWidth, textBoxHeight)
            });

            //create a tick amount text box under the tick amount label
            //and add it to the list
            tickAmountTextBoxes.Add(new TextBox()
            {
                //adjusting for size of label and previous text boxes
                //the 4 makes it not hit the label, and the 6 adds a space between text boxes
                Location = new Point(tickAmountX,
                            tickAmountY + tickAmountLabel.Height + 4 + (tickAmountTextBoxes.Count * (textBoxHeight + textBoxSpacing))),
                Name = "tickAmountTextBox" + tickAmountTextBoxes.Count,
                Size = new Size(textBoxWidth, textBoxHeight)
            });

            //create the delete button
            deleteButtons.Add(new Button()
            {
                //adjusting for size of label and previous buttons
                Location = new Point(tickAmountX + textBoxWidth + 10,
                            tickAmountY + tickAmountLabel.Height + 4 + (deleteButtons.Count * (textBoxHeight + textBoxSpacing))),
                Name = "deleteButton" + deleteButtons.Count,
                Size = new Size(textBoxWidth, textBoxHeight),
                Text = "Delete"
            });

            //add text box to the controls
            Controls.Add(enemyTypeComboBoxes[enemyTypeComboBoxes.Count-1]);
            Controls.Add(enemyLevelComboBoxes[enemyLevelComboBoxes.Count - 1]);
            Controls.Add(amountTextBoxes[amountTextBoxes.Count-1]);
            Controls.Add(enterTimeTextBoxes[enterTimeTextBoxes.Count-1]);
            Controls.Add(tickAmountTextBoxes[tickAmountTextBoxes.Count-1]);
            Controls.Add(deleteButtons[deleteButtons.Count - 1]);

            //adding on textchange event to provide feedback if changes have been made
            enemyTypeComboBoxes[enemyTypeComboBoxes.Count - 1].TextChanged += AddStar;

            enemyLevelComboBoxes[enemyLevelComboBoxes.Count - 1].TextChanged += AddStar;

            amountTextBoxes[amountTextBoxes.Count - 1].TextChanged += AddStar;
            amountTextBoxes[amountTextBoxes.Count - 1].TextChanged += ValidateEnemyAmountTextBox;

            enterTimeTextBoxes[enterTimeTextBoxes.Count - 1].TextChanged += AddStar;
            enterTimeTextBoxes[enterTimeTextBoxes.Count - 1].TextChanged += ValidateDoulbeTextBox;

            tickAmountTextBoxes[tickAmountTextBoxes.Count - 1].TextChanged += AddStar;
            tickAmountTextBoxes[tickAmountTextBoxes.Count - 1].TextChanged += ValidateDoulbeTextBox;

            deleteButtons[deleteButtons.Count - 1].Click += DeleteLine;
        }

        /// <summary>
        /// Delete a row of text boxes and move other boxes up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLine(object sender, EventArgs e)
        {
            if(sender is Button button)
            {

                //the button name ends with it's index
                int index = int.Parse(button.Name.Substring(12));

                //remove text boxes from form
                enemyTypeComboBoxes[index].Dispose();
                enemyLevelComboBoxes[index].Dispose();
                enterTimeTextBoxes[index].Dispose();
                amountTextBoxes[index].Dispose();
                tickAmountTextBoxes[index].Dispose();
                deleteButtons[index].Dispose();

                //remove from 
                enemyTypeComboBoxes.RemoveAt(index);
                enemyLevelComboBoxes.RemoveAt(index);
                enterTimeTextBoxes.RemoveAt(index);
                amountTextBoxes.RemoveAt(index);
                tickAmountTextBoxes.RemoveAt(index);
                deleteButtons.RemoveAt(index);

                //shift over text boxes
                for (int i = index; i < enemyTypeComboBoxes.Count; i++)
                {
                    //the new text box's y location is moved to it's new location depending on it's index
                    enemyTypeComboBoxes[i].Location = new Point(enemyTypeComboBoxes[i].Location.X, enemyLabel.Location.Y 
                        + enemyLabel.Height + 4 + (i * (textBoxHeight + textBoxSpacing)));
                    //change name
                    enemyTypeComboBoxes[i].Name = "enemyTypeComboBox" + i;

                    //the new text box's y location is moved to it's new location depending on it's index
                    enemyLevelComboBoxes[i].Location = new Point(enemyLevelComboBoxes[i].Location.X, enemyLevelLabel.Location.Y
                        + enemyLevelLabel.Height + 4 + (i * (textBoxHeight + textBoxSpacing)));
                    //change name
                    enemyLevelComboBoxes[i].Name = "enemyLevelComboBox" + i;

                    enterTimeTextBoxes[i].Location = new Point(enterTimeTextBoxes[i].Location.X, enterTimeLabel.Location.Y
                        + enterTimeLabel.Height + 4 + (i * (textBoxHeight + textBoxSpacing)));
                    //change name
                    enterTimeTextBoxes[i].Name = "enterTimeTextBox" + i;

                    amountTextBoxes[i].Location = new Point(amountTextBoxes[i].Location.X, amountLabel.Location.Y
                        + amountLabel.Height + 4 + (i * (textBoxHeight + textBoxSpacing)));
                    //change name
                    amountTextBoxes[i].Name = "amountTextBox" + i;

                    tickAmountTextBoxes[i].Location = new Point(tickAmountTextBoxes[i].Location.X, tickAmountLabel.Location.Y
                        + tickAmountLabel.Height + 4 + (i * (textBoxHeight + textBoxSpacing)));
                    //change name
                    tickAmountTextBoxes[i].Name = "tickAmountTextBox" + i;

                    deleteButtons[i].Location = new Point(deleteButtons[i].Location.X, tickAmountLabel.Location.Y
                        + tickAmountLabel.Height + 4 + (i * (textBoxHeight + textBoxSpacing)));
                    //change name
                    deleteButtons[i].Name = "deleteButton" + i;
                }
            }
        }

        /// <summary>
        /// Checks if the waves were set up correctly then saves
        /// them as a .wave_level file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveWaveButton_Click(object sender, EventArgs e)
        {
            //test if can save works
            //Console.WriteLine(LastFilledLine());

            int lastFilledLine = LastFilledLine();

            //prevent saving if there's a problem with lines
            if (lastFilledLine == -1)
            {
                MessageBox.Show("Cannot save file. Please fix errors.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //do the save
            else
            {
                //open the file select screen
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save a .wave level file";
                saveFileDialog.Filter = "Wave Files | *.wave_level";

                DialogResult dr = saveFileDialog.ShowDialog();

                //user wants to save file
                if (dr == DialogResult.OK)
                {
                    FileStream writeStream = null;
                    //making it a stream writer to improve readablitiy of file
                    StreamWriter writer = null;

                    path = saveFileDialog.FileName;

                    //delete the file if overwriting to prevent extra info
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    //make sure stream and writer are valid
                    try
                    {
                        writeStream = File.OpenWrite(path);
                        writer = new StreamWriter(writeStream);

                        name = saveFileDialog.FileName;
                        //get just the file name removing the path
                        name = name.Substring(name.LastIndexOf('\\') + 1);

                        //save how many line are saved
                        writer.WriteLine(lastFilledLine + 1);

                        //save each full line of information
                        //doing <= b/c LastFilledLine returns the last full line
                        for (int i = 0; i <= lastFilledLine; i++)
                        {
                            //create string that holds one line of info
                            string text = enemyTypeComboBoxes[i].Text + ",";
                            text += enemyLevelComboBoxes[i].Text + ",";
                            text += amountTextBoxes[i].Text + ",";
                            text += enterTimeTextBoxes[i].Text + ",";
                            text += tickAmountTextBoxes[i].Text;

                            writer.WriteLine(text);
                        }

                        //the file has been saved and change the form title to reflect that
                        saved = true;
                        UpdateFormTitle();
                        MessageBox.Show("File Saved Successfully", "File Saved");
                    }
                    #region Exceptions
                    catch (UnauthorizedAccessException excep)
                    {
                        MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException excep)
                    {
                        MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (PathTooLongException excep)
                    {
                        MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (DirectoryNotFoundException excep)
                    {
                        MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                    //close the writer and stream
                    finally
                    {
                        if (writer != null)
                        {
                            writer.Close();
                        }
                        else if (writeStream != null)
                        {
                            writeStream.Close();
                        }
                    }
                }

                saveFileDialog.Dispose();
            }
        }

        /// <summary>
        /// Load a .wave_level file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadWaveButton_Click(object sender, EventArgs e)
        {
            //if the file hasn't been saved
            if (!saved)
            {
                //cancel loading if the user chooses no
                if (MessageBox.Show("This wave has not been saved. Are you sure you want to continue?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

            }

            //get the file path
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open a .wave level file";
            openFileDialog.Filter = "Wave Files | *.wave_level";

            DialogResult dr = openFileDialog.ShowDialog();

            //if dialog is ok (user opened file)
            //then load map
            if (dr == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                name = openFileDialog.SafeFileName;

                //create file stream and reader
                FileStream readStream = null;
                StreamReader reader = null;

                try
                {
                    readStream = File.OpenRead(path);
                    reader = new StreamReader(readStream);

                    //clear the text boxes on screen
                    for (int i = 0; i < enemyTypeComboBoxes.Count; i++)
                    {
                        enemyTypeComboBoxes[i].Text = "";
                        enemyLevelComboBoxes[i].Text = "";
                        amountTextBoxes[i].Text = "";
                        enterTimeTextBoxes[i].Text = "";
                        tickAmountTextBoxes[i].Text = "";
                    }

                    string info = null;

                    //get first line, which is number of lines
                    info = reader.ReadLine();

                    int numberLines = int.Parse(info);
                    
                    for (int i = 0; i < numberLines - 4; i++)
                    {
                        AddNewLine();
                    }

                    for (int i = 0; i < numberLines; i++)
                    {
                        //read the line and split the info on the comma
                        string[] savedInfo = reader.ReadLine().Split(',');

                        //add just read info to text boxes
                        //order is the same as displayed in form
                        enemyTypeComboBoxes[i].Text = savedInfo[0];
                        enemyLevelComboBoxes[i].Text = savedInfo[1];
                        amountTextBoxes[i].Text = savedInfo[2];
                        enterTimeTextBoxes[i].Text = savedInfo[3];
                        tickAmountTextBoxes[i].Text = savedInfo[4];
                    }

                    //change name of form
                    UpdateFormTitle();
                    saved = true;
                    MessageBox.Show("File Loaded Successfully", "File Loaded");
                }
                #region Exceptions
                catch (PathTooLongException excep)
                {
                    MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileNotFoundException excep)
                {
                    MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException excep)
                {
                    MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException excep)
                {
                    MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                //close the stream
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    else if (readStream != null)
                    {
                        readStream.Close();
                    }
                }
            }

            openFileDialog.Dispose();
        }

        /// <summary>
        /// Makes sure there are no partially filled lines
        /// and returns the last fully filled line
        /// </summary>
        /// <returns>-1 if the file can't be saved
        /// otherwise the index of the last filled line</returns>
        private int LastFilledLine()
        {
            //loop through lines of text boxes
            //each one should have the same count
            for (int i = 0; i < enemyTypeComboBoxes.Count; i++)
            {
                //if the whole line is empty, this captures an empty line
                //so the next check only captures partially filled lines
                if(enemyTypeComboBoxes[i].Text == "" && enemyLevelComboBoxes[i].Text == "" && amountTextBoxes[i].Text == "" && enterTimeTextBoxes[i].Text == "" && tickAmountTextBoxes[i].Text == "")
                {
                    //then we've reached the end of the filled text boxes
                    return i - 1;
                }
                //if any of the text boxes aren't filled
                else if (enemyTypeComboBoxes[i].Text == "" || enemyLevelComboBoxes[i].Text == "" || amountTextBoxes[i].Text == "" || enterTimeTextBoxes[i].Text == "" || tickAmountTextBoxes[i].Text == "")
                {
                    return -1;
                }
            }

            //exited the loop so all lines are good
            //return the count - 1
            return enterTimeTextBoxes.Count - 1;
        }

        /// <summary>
        /// Add a new line of text boxes after the previous one
        /// If buttons go past screen resize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLineButton_Click(object sender, EventArgs e)
        {
            AddNewLine();
        }

        /// <summary>
        /// Change the map editor form title
        /// </summary>
        private void UpdateFormTitle()
        {
            this.Text = "Wave Editor - " + name;
        }

        /// <summary>
        /// If changes have been made,
        /// change saved bool and update form title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStar(object sender, EventArgs e)
        {
            if (saved)
            {
                //make saved false
                saved = false;
                Text += " *";
            }
        }

        /// <summary>
        /// Make sure the enemy amount text box only accepts positive integers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateEnemyAmountTextBox(object sender, EventArgs e)
        {
            if(sender is TextBox textBox)
            {
                //if the text box was cleared, prevent the message box from appearing
                if (textBox.Text == "")
                {
                    return;
                }
                else
                {
                    //check if text is a number
                    bool valid = int.TryParse(textBox.Text, out int amount);

                    //make sure number is valid
                    if (valid && amount > 0)
                    {
                        //add the star showing the file has been changed
                        AddStar(sender, e);
                    }
                    else
                    {
                        //clear text
                        textBox.Text = "";
                        //tell user that's not allowed
                        MessageBox.Show("That value is not allowed. Only positive integers are allowed.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }   
        }

        /// <summary>
        /// Make sure the enemy amount text box only accepts positive integers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateDoulbeTextBox(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                //if the text box was cleared, prevent the message box from appearing
                if (textBox.Text != "")
                {
                    bool valid = double.TryParse(textBox.Text, out double amount);
                    //check if text is a number
                    if (valid && amount >= 0)
                    {
                        //add the star showing the file has been changed
                        AddStar(sender, e);
                    }
                    else
                    {
                        //clear text
                        textBox.Text = "";
                        //tell user that's not allowed
                        MessageBox.Show("That value is not allowed. Only positive doubles are allowed.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Ask the user if they are sure they want to close the form if there are unsaved changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                //cancel closing if the user chooses no
                if (MessageBox.Show("This map has not been saved. Are you sure you want to continue?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }

            }
        }
    }
}
