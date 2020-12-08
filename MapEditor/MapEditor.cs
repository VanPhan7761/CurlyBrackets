using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

namespace Homework7Cassiar
{
    /// <summary>
    /// Class that allows the user to place different tiles on the screen
    /// Author: Cassiar Beaver
    /// Feburary 20 2020
    /// </summary>
    public partial class MapEditor : Form
    {
        //width and height of group box in tiles
        private int tileWidth;
        private int tileHeight;

        //size of a tile
        private int tileSize;

        //file path
        private string path;
        private string name;

        //has been saved
        private bool saved = true;

        private bool needToLoad = false;

        //pen image
        private Image penImage;
        //what the tag of the image is. For saving
        private String imageTag = "00";

        //needing to drag to paint
        private bool mouseDown = false;

        //array hold picture boxes
        PictureBox[][] map;

        //to prevent more than one start and end tile
        private bool hasStartTile = false;
        private bool hasEndTile = false;

        //validating path
        private int startX;
        private int startY;

        //which way the search moves to find the critical path
        private int moveX;
        private int moveY;

        private int numTiles;

        //ordered list of corners start and end
        private List<int[]> criticalPoints = new List<int[]>();

        public MapEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor when passing in width and height
        /// </summary>
        /// <param name="width">The width of the map in tiles</param>
        /// <param name="height">The height of the map in tiles</param>
        public MapEditor(int width, int height) : this()
        {
            this.tileWidth = width;
            this.tileHeight = height;

            //create size of array
            map = new PictureBox[tileWidth][];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new PictureBox[tileHeight];
            }

            //set the tile size based on the number of tiles
            tileSize = mapGroupBox.Height / height;
        }

        /// <summary>
        /// Constructor when passing in a file to load
        /// </summary>
        /// <param name="path">The path to the file to load</param>
        public MapEditor(string path) : this()
        {
            this.path = path;
            needToLoad = true;
        }

        /// <summary>
        /// On load, if a path was specified load map, otherwise size group box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapEditor_Load(object sender, EventArgs e)
        {
            //if need to load mao
            if (needToLoad)
            {
                LoadMap();
            }
            else
            {
                //resize the window based on new width and height
                ResizeWindow();
                //populate group box with picture boxes
                //the columns
                for (int i = 0; i < tileWidth; i++)
                {
                    //the rows
                    for (int j = 0; j < tileHeight; j++)
                    {
                        PopulatePictureBox(i, j);
                    }
                }
            }
        }

        /// <summary>
        /// set the mousedown bool to true when a picture box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PictureBoxClicked(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            { 
                //allow dragging to change color
                mouseDown = true;
                pictureBox.Capture = false;

                ChangePictureBoxImage(sender, e);
            }
        }

        /// <summary>
        /// Set mouseDown to false so dragging no long changes color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseUp(object sender, EventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// If a picture box is clicked change the image to the current image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangePictureBoxImage(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && mouseDown)
            {
                //there's currently a start tile selected and already one on the map
                if (imageTag[0] == 'S' && hasStartTile)
                {
                    MessageBox.Show("There is already a start tile. Please remove that tile before placing another start tile.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //there's currently an end tile selected and already one on the map
                else if (imageTag[1] == 'E' && hasEndTile)
                {
                    MessageBox.Show("There is already an end tile. Please remove that tile before placing another end tile.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //if the tile being added is a start or end tile
                    if (imageTag[0] == 'S')
                    {
                        hasStartTile = true;
                    }
                    else if (imageTag[1] == 'E')
                    {
                        hasEndTile = true;
                    }

                    //if the image being removed was a start or end tile
                    if (((String)pictureBox.Tag)[0] == 'S')
                    {
                        hasStartTile = false;
                    }
                    else if (((String)pictureBox.Tag)[1] == 'E')
                    {
                        hasEndTile = false;
                    }

                    //change the image
                    pictureBox.BackgroundImage = penImage;
                    //set the tag for saving
                    pictureBox.Tag = imageTag;
                    pictureBox.Refresh();

                    AddStar();
                }
            }
        }

        /// <summary>
        /// Adds a star if the file has been changed and isn't saved
        /// </summary>
        private void AddStar()
        {
            //add star if changes were made
            if (saved)
            {
                saved = false;
                Text += " *";
            }
        }

        /// <summary>
        /// Open a file dialog and save the map with the .map extension
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveMapButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save a .map level file";
            saveFileDialog.Filter = "Map Files | *.map_level";
            saveFileDialog.InitialDirectory = "../../../CurlyBracket/Content/Levels";

            DialogResult dr = saveFileDialog.ShowDialog();

            //user wants to save file
            if (dr == DialogResult.OK)
            {
                FileStream writeStream = null;
                //making it a stream writer t o improve readablitiy of file
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

                    //basic saving, each picture box individually

                    //width and height and starting money
                    writer.WriteLine(tileHeight + "," + tileWidth + "," + easyMoneyTextBox.Text + ","
                        + mediumMoneyTextBox.Text + "," + hardMoneyTextBox.Text);

                    #region map
                    //loop through array
                    for (int i = 0; i < tileHeight; i++)
                    {
                        for (int j = 0; j < tileWidth; j++)
                        {
                            //if there isn't a picture save default thing instead
                            if (map[j][i].BackgroundImage == null)
                            {
                                writer.Write("00,");
                            }
                            else
                            {
                                //store the position of the start tile
                                if (((String)map[j][i].Tag)[0] == 'S')
                                {
                                    startX = j;
                                    startY = i;
                                }
                                //save the string of what the tag is
                                writer.Write((string)map[j][i].Tag + ",");
                            }
                        }
                        //add a new line to simplify human reading of file
                        writer.WriteLine();
                    }
                    #endregion

                    //finding and saving critical points
                    FindCriticalPoints(startX, startY);

                    for (int i = 0; i < criticalPoints.Count; i++)
                    {
                        //write corridinates to file
                        writer.Write(criticalPoints[i][0] + "." + criticalPoints[i][1] + ",");
                    }
                    //clear any extra junk in saved file
                    writer.WriteLine();

                    //the file has been saved and change the form title to reflect that
                    saved = true;
                    UpdateFormTitle();
                    MessageBox.Show("File Saved Successfully", "File Saved");
                }
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
                //close the writer and stream
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }else if(writeStream != null)
                    {
                        writeStream.Close();
                    }
                }
            }

            saveFileDialog.Dispose();
        }

        /// <summary>
        /// Change the map editor form title
        /// </summary>
        private void UpdateFormTitle()
        {
            this.Text = "Map Editor - " + name;
        }

        /// <summary>
        /// find all corners and the start and end tile
		/// Author: Van Phan & John Heiden & Cassiar Beaver
		/// Date: 03/07/20
		/// </summary>
		private void FindCriticalPoints(int row, int col)
        {
            PictureBox path = map[row][col];
            string tag = (String)path.Tag;

            //it's a start tile
            if (tag[0] == 'S')
            {
                //add to critical points
                criticalPoints.Add(new int[2] { row, col });

                //find which way it goes
                if (tag[1] == 'B')
                {
                    moveX = 0;
                    moveY = 1;
                    //FindCriticalPoints(row, col + 1);
                }
                else if (tag[1] == 'L')
                {
                    moveX = -1;
                    moveY = 0;
                    //FindCriticalPoints(row - 1, col);
                }
                else if (tag[1] == 'R')
                {
                    moveX = 1;
                    moveY = 0;
                    //FindCriticalPoints(row + 1, col);
                }
                else if (tag[1] == 'T')
                {
                    moveX = 0;
                    moveY = -1;
                    //FindCriticalPoints(row, col - 1);
                }
            }
            else
            {
                switch (tag[1])
                {
                    case 'R':
                        //it's a corner
                        if (tag == "BR" || tag == "TR")
                        {
                            criticalPoints.Add(new int[2] { row, col });
                        }
                        //move to right column and check again
                        moveX = 1;
                        moveY = 0;
                        //FindCriticalPoints(row + 1, col);
                        break;
                    case 'B':
                        if (tag == "RB" || tag == "LB")
                        {
                            criticalPoints.Add(new int[2] { row, col });
                        }
                        moveX = 0;
                        moveY = 1;
                        //FindCriticalPoints(row, col + 1);
                        break;
                    case 'T':
                        if (tag == "RT" || tag == "LT")
                        {
                            criticalPoints.Add(new int[2] { row, col });
                        }
                        moveX = 0;
                        moveY = -1;
                        //FindCriticalPoints(row, col - 1);
                        break;
                    case 'L':
                        if (tag == "BL" || tag == "TL")
                        {
                            criticalPoints.Add(new int[2] { row, col });
                        }
                        moveX = -1;
                        moveY = 0;
                        //FindCriticalPoints(row - 1, col);
                        break;
                    case 'E':
                        //it's the end tile so exit recursion
                        criticalPoints.Add(new int[2] { row, col });
                        return;
                    //there isn't a tile there so break
                    case '0':
                        break;
                }
            }

            FindCriticalPoints(row + moveX, col + moveY);
        }

        /// <summary>
        /// Load the map. Create and assign new values to the array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMapButton_Click(object sender, EventArgs e)
        {
            //if the file hasn't been saved
            if (!saved)
            {
                //cancel loading if the user chooses no
                if (MessageBox.Show("This map has not been saved. Are you sure you want to continue?", "Warrning", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "../../../CurlyBracket/Content/Levels";
            openFileDialog.Title = "Open a .map level file";
            openFileDialog.Filter = "Map Files | *.map_level";


            DialogResult dr = openFileDialog.ShowDialog();

            //if dialog is ok (user opened file)
            //then load map
            if (dr == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                name = openFileDialog.SafeFileName;

                LoadMap();
            }

            openFileDialog.Dispose();
        }

        /// <summary>
        /// Create each picture box and assign the colors to them. Default color is grey which is 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void PopulatePictureBox(int x, int y, Image image = null, String tag = "00")
        {
            PictureBox pictureBox = new PictureBox();
            mapGroupBox.Controls.Add(pictureBox);
            pictureBox.Size = new Size(tileSize, tileSize);

            //add to list
            map[x][y] = pictureBox;

            //pictureBox.BackColor = Color.White;

            //offsetting to allow group box border
            pictureBox.Location = new Point(2 + tileSize * x, 10 + tileSize * y);

            //add a border to the picture boxes
            pictureBox.BorderStyle = BorderStyle.FixedSingle;

            //set background layout to stretch so arrow image will fill whole box
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            //adding the image
            pictureBox.BackgroundImage = image;
            //adding the tag
            pictureBox.Tag = tag;

            //hooking up methods that allow dragging to color picture boxes
            pictureBox.MouseDown += PictureBoxClicked;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseEnter += ChangePictureBoxImage;
        }

        /// <summary>
        /// Resize the window when loading or creating a map
        /// </summary>
        private void ResizeWindow()
        {
            //adding two to width and height to allow border to show
            //set width
            mapGroupBox.Width = tileSize * tileWidth + 4;
            //change height slightly to avoid extra space at bottom
            mapGroupBox.Height = tileSize * tileHeight + 14;

            //auto size the form width and height
            this.Width = mapGroupBox.Width + mapGroupBox.Location.X + 50;
            this.Height = mapGroupBox.Height + mapGroupBox.Location.Y + 50;
        }

        /// <summary>
        /// Clears the previous map and loads in a new one
        /// </summary>
        private void LoadMap()
        {
            //create file stream and reader
            FileStream readStream = null;
            StreamReader reader = null;

            try
            {
                readStream = File.OpenRead(path);
                reader = new StreamReader(readStream);

                //clear starting money
                easyMoneyTextBox.Text = "";
                mediumMoneyTextBox.Text = "";
                hardMoneyTextBox.Text = "";

                //clear previous map
                for (int i = 0; i < this.tileWidth; i++)
                {
                    for (int j = 0; j < this.tileHeight; j++)
                    {
                        mapGroupBox.Controls.Remove(map[i][j]);
                        if (map[i][j] != null)
                        {
                            //remove the methods from the events
                            map[i][j].MouseDown -= PictureBoxClicked;
                            map[i][j].MouseUp -= PictureBox_MouseUp;
                            map[i][j].MouseEnter -= ChangePictureBoxImage;
                        }
                    }
                }

                //clear critical points list
                criticalPoints.Clear();

                //get first line, which is width and height, and starting money
                string[] info = reader.ReadLine().Split(',');

                //read the width and height
                //get the first two characters
                tileHeight = int.Parse(info[0]);
                //the two chars following the comma
                tileWidth = int.Parse(info[1]);

                try
                {
                    //update money text boxes
                    easyMoneyTextBox.Text = info[2];
                    mediumMoneyTextBox.Text = info[3];
                    hardMoneyTextBox.Text = info[4];
                }
                catch(IndexOutOfRangeException)
                {
                    MessageBox.Show("The file was saved with an older version of the editor. There will be no " +
                        "starting money values.", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //change the tile size
                tileSize = mapGroupBox.Height / tileHeight;

                //change the group box height
                ResizeWindow();

                //resize the array
                map = new PictureBox[tileWidth][];
                for (int i = 0; i < map.Length; i++)
                {
                    map[i] = new PictureBox[tileHeight];
                }
                //populate group box with picture boxes
                //the columns
                for (int i = 0; i < tileHeight; i++)
                {
                    //get the line
                    info = reader.ReadLine().Split(',');

                    //the rows
                    #region Rows
                    for (int j = 0; j < tileWidth; j++)
                    {
                        //check what image it is and give to PopulatePictureBox
                        //arrow pointing up
                        if (info[j].Equals("BT")) { PopulatePictureBox(j,i, Properties.Resources.BottomTop, "BT"); }
                        //arrow down
                        else if (info[j].Equals("TB")) { PopulatePictureBox(j,i, Properties.Resources.TopBottom, "TB"); }
                        //arrow left
                        else if (info[j].Equals("RL")) { PopulatePictureBox(j,i, Properties.Resources.RightLeft, "RL"); }
                        //arrow right
                        else if (info[j].Equals("LR")) { PopulatePictureBox(j,i, Properties.Resources.LeftRight, "LR"); }
                        //start tiles
                        else if (info[j].Equals("ST")) { PopulatePictureBox(j,i, Properties.Resources.StartTop, "ST"); }
                        else if (info[j].Equals("SB")) { PopulatePictureBox(j,i, Properties.Resources.StartBottom, "SB"); }
                        else if (info[j].Equals("SL")) { PopulatePictureBox(j,i, Properties.Resources.StartLeft, "SL"); }
                        else if (info[j].Equals("SR")) { PopulatePictureBox(j,i, Properties.Resources.StartRight, "SR"); }
                        //end tiles
                        else if (info[j].Equals("TE")) { PopulatePictureBox(j,i, Properties.Resources.TopEnd, "TE"); }
                        else if (info[j].Equals("BE")) { PopulatePictureBox(j,i, Properties.Resources.BottomEnd, "BE"); }
                        else if (info[j].Equals("LE")) { PopulatePictureBox(j,i, Properties.Resources.LeftEnd, "LE"); }
                        else if (info[j].Equals("RE")) { PopulatePictureBox(j,i, Properties.Resources.RightEnd, "RE"); }
                        //corners
                        else if (info[j].Equals("BL")) { PopulatePictureBox(j, i, Properties.Resources.BottomLeft, "BL"); }
                        else if (info[j].Equals("BR")) { PopulatePictureBox(j, i, Properties.Resources.BottomRight, "BR"); }
                        else if (info[j].Equals("LB")) { PopulatePictureBox(j, i, Properties.Resources.LeftBottom, "LB"); }
                        else if (info[j].Equals("LT")) { PopulatePictureBox(j, i, Properties.Resources.LeftTop, "LT"); }
                        else if (info[j].Equals("RB")) { PopulatePictureBox(j, i, Properties.Resources.RightBottom, "RB"); }
                        else if (info[j].Equals("RT")) { PopulatePictureBox(j, i, Properties.Resources.RightTop, "RT"); }
                        else if (info[j].Equals("TL")) { PopulatePictureBox(j, i, Properties.Resources.TopLeft, "TL"); }
                        else if (info[j].Equals("TR")) { PopulatePictureBox(j, i, Properties.Resources.TopRight, "TR"); }
                        //intersection
                        else if (info[j].Equals("IN")) { PopulatePictureBox(j, i, Properties.Resources.Intersection, "IN"); }
                        //obstacle
                        else if (info[j].Equals("CO")) { PopulatePictureBox(j, i, Properties.Resources.black_lotus, "CO"); }
                        //empty tile
                        else { PopulatePictureBox(j, i); }
                    }
                    #endregion
                }

                //change name of form
                UpdateFormTitle();
                saved = true;
                MessageBox.Show("File Loaded Successfully", "File Loaded");
            }
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

        /// <summary>
        /// Set mousedown bool to false when the mouse is no longer over the group box.
        /// Yes it does mean accidentally moving out of the group box cancels the drag.
        /// It's acceptable losses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapEditor_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// Use a drop down menu to select the tile type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapGroupBox_TextChanged(object sender, EventArgs e)
        {
            if(sender is ComboBox comboBox)
            {
                #region straight
                //arrow going up
                if (comboBox.Text == "BottomTop") 
                { 
                    penImage = Properties.Resources.BottomTop;
                    imageTag = "BT";
                    currentTileButton.BackgroundImage = penImage;
                }
                //arrow going down
                else if (comboBox.Text == "TopBottom")
                {
                    penImage = Properties.Resources.TopBottom;
                    imageTag = "TB";
                    currentTileButton.BackgroundImage = penImage;
                }
                //arrow going left
                else if (comboBox.Text == "RightLeft")
                {
                    penImage = Properties.Resources.RightLeft;
                    imageTag = "RL";
                    currentTileButton.BackgroundImage = penImage;
                }
                //arrow going right
                else if (comboBox.Text == "LeftRight")
                {
                    penImage = Properties.Resources.LeftRight;
                    imageTag = "LR";
                    currentTileButton.BackgroundImage = penImage;
                }
                #endregion
                #region start
                else if (comboBox.Text == "StartTop")
                {
                    penImage = Properties.Resources.StartTop;
                    imageTag = "ST";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if(comboBox.Text == "StartBottom")
                {
                    penImage = Properties.Resources.StartBottom;
                    imageTag = "SB";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if(comboBox.Text == "StartLeft")
                {
                    penImage = Properties.Resources.StartLeft;
                    imageTag = "SL";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if(comboBox.Text == "StartRight")
                {
                    penImage = Properties.Resources.StartRight;
                    imageTag = "SR";
                    currentTileButton.BackgroundImage = penImage;
                }
                #endregion
                #region end
                else if (comboBox.Text == "TopEnd")
                {
                    penImage = Properties.Resources.TopEnd;
                    imageTag = "TE";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "BottomEnd")
                {
                    penImage = Properties.Resources.BottomEnd;
                    imageTag = "BE";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "LeftEnd")
                {
                    penImage = Properties.Resources.LeftEnd;
                    imageTag = "LE";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "RightEnd")
                {
                    penImage = Properties.Resources.RightEnd;
                    imageTag = "RE";
                    currentTileButton.BackgroundImage = penImage;
                }
                #endregion
                #region corner
                else if (comboBox.Text == "BottomLeft")
                {
                    penImage = Properties.Resources.BottomLeft;
                    imageTag = "BL";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "BottomRight")
                {
                    penImage = Properties.Resources.BottomRight;
                    imageTag = "BR";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "LeftBottom")
                {
                    penImage = Properties.Resources.LeftBottom;
                    imageTag = "LB";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "LeftTop")
                {
                    penImage = Properties.Resources.LeftTop;
                    imageTag = "LT";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "RightBottom")
                {
                    penImage = Properties.Resources.RightBottom;
                    imageTag = "RB";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "RightTop")
                {
                    penImage = Properties.Resources.RightTop;
                    imageTag = "RT";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "TopLeft")
                {
                    penImage = Properties.Resources.TopLeft;
                    imageTag = "TL";
                    currentTileButton.BackgroundImage = penImage;
                }
                else if (comboBox.Text == "TopRight")
                {
                    penImage = Properties.Resources.TopRight;
                    imageTag = "TR";
                    currentTileButton.BackgroundImage = penImage;
                }
                #endregion
                //obstacle
                else if (comboBox.Text == "Obstacle")
                {
                    penImage = Properties.Resources.black_lotus;
                    imageTag = "CO";
                    currentTileButton.BackgroundImage = penImage;
                }
                //intersection
                else if (comboBox.Text == "Intersection")
                {
                    penImage = Properties.Resources.Intersection;
                    imageTag = "IN";
                    currentTileButton.BackgroundImage = penImage;
                }
                //blank tile
                else if (comboBox.Text == "")
                {
                    penImage = null;
                    imageTag = "00";
                    currentTileButton.BackgroundImage = penImage;
                }
            }
        }

        /// <summary>
        /// Make sure the starting money values are positive integers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateMoney(object sender, EventArgs e)
        {
            if(sender is TextBox textBox)
            {
                //prevent clearing text from triggering check
                if (textBox.Text != "")
                {
                    //test if text is valid
                    if (int.TryParse(textBox.Text, out int value) && value > 0)
                    {
                        //text is valid so add star b/c we need to save
                        AddStar();
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
    }
}
