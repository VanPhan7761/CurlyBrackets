namespace Homework7Cassiar
{
    partial class MapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentColorGroupBox = new System.Windows.Forms.GroupBox();
            this.currentTileButton = new System.Windows.Forms.Button();
            this.saveMapButton = new System.Windows.Forms.Button();
            this.loadMapButton = new System.Windows.Forms.Button();
            this.saveLoadMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.mapGroupBox = new System.Windows.Forms.GroupBox();
            this.tileComboBox = new System.Windows.Forms.ComboBox();
            this.startingMoneyLabel = new System.Windows.Forms.Label();
            this.easyMoneyLabel = new System.Windows.Forms.Label();
            this.mediumMoneyLabel = new System.Windows.Forms.Label();
            this.hardMoneyLabel = new System.Windows.Forms.Label();
            this.easyMoneyTextBox = new System.Windows.Forms.TextBox();
            this.hardMoneyTextBox = new System.Windows.Forms.TextBox();
            this.mediumMoneyTextBox = new System.Windows.Forms.TextBox();
            this.currentColorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentColorGroupBox
            // 
            this.currentColorGroupBox.Controls.Add(this.currentTileButton);
            this.currentColorGroupBox.Location = new System.Drawing.Point(20, 309);
            this.currentColorGroupBox.Name = "currentColorGroupBox";
            this.currentColorGroupBox.Size = new System.Drawing.Size(126, 94);
            this.currentColorGroupBox.TabIndex = 1;
            this.currentColorGroupBox.TabStop = false;
            this.currentColorGroupBox.Text = "Current Tile";
            // 
            // currentTileButton
            // 
            this.currentTileButton.BackColor = System.Drawing.Color.White;
            this.currentTileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.currentTileButton.Enabled = false;
            this.currentTileButton.Location = new System.Drawing.Point(34, 19);
            this.currentTileButton.Name = "currentTileButton";
            this.currentTileButton.Size = new System.Drawing.Size(60, 60);
            this.currentTileButton.TabIndex = 0;
            this.currentTileButton.UseVisualStyleBackColor = false;
            // 
            // saveMapButton
            // 
            this.saveMapButton.Location = new System.Drawing.Point(20, 410);
            this.saveMapButton.Name = "saveMapButton";
            this.saveMapButton.Size = new System.Drawing.Size(126, 65);
            this.saveMapButton.TabIndex = 2;
            this.saveMapButton.Text = "Save Map";
            this.saveMapButton.UseVisualStyleBackColor = true;
            this.saveMapButton.Click += new System.EventHandler(this.SaveMapButton_Click);
            // 
            // loadMapButton
            // 
            this.loadMapButton.Location = new System.Drawing.Point(20, 497);
            this.loadMapButton.Name = "loadMapButton";
            this.loadMapButton.Size = new System.Drawing.Size(126, 65);
            this.loadMapButton.TabIndex = 3;
            this.loadMapButton.Text = "Load Map";
            this.loadMapButton.UseVisualStyleBackColor = true;
            this.loadMapButton.Click += new System.EventHandler(this.LoadMapButton_Click);
            // 
            // saveLoadMapDialog
            // 
            this.saveLoadMapDialog.FileName = "openFileDialog1";
            // 
            // mapGroupBox
            // 
            this.mapGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.mapGroupBox.Location = new System.Drawing.Point(154, 25);
            this.mapGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.mapGroupBox.Name = "mapGroupBox";
            this.mapGroupBox.Size = new System.Drawing.Size(542, 550);
            this.mapGroupBox.TabIndex = 4;
            this.mapGroupBox.TabStop = false;
            this.mapGroupBox.Text = "Map";
            this.mapGroupBox.TextChanged += new System.EventHandler(this.MapGroupBox_TextChanged);
            // 
            // tileComboBox
            // 
            this.tileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileComboBox.FormattingEnabled = true;
            this.tileComboBox.Items.AddRange(new object[] {
            "Intersection",
            "Obstacle",
            "",
            "BottomTop",
            "LeftRight",
            "RightLeft",
            "TopBottom",
            "",
            "BottomLeft",
            "BottomRight",
            "LeftBottom",
            "LeftTop",
            "RightBottom",
            "RightTop",
            "TopLeft",
            "TopRight",
            "",
            "StartBottom",
            "StartLeft",
            "StartRight",
            "StartTop",
            "",
            "BottomEnd",
            "LeftEnd",
            "RightEnd",
            "TopEnd"});
            this.tileComboBox.Location = new System.Drawing.Point(20, 25);
            this.tileComboBox.Name = "tileComboBox";
            this.tileComboBox.Size = new System.Drawing.Size(126, 21);
            this.tileComboBox.TabIndex = 14;
            this.tileComboBox.TextChanged += new System.EventHandler(this.MapGroupBox_TextChanged);
            // 
            // startingMoneyLabel
            // 
            this.startingMoneyLabel.AutoSize = true;
            this.startingMoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.startingMoneyLabel.Location = new System.Drawing.Point(16, 101);
            this.startingMoneyLabel.Name = "startingMoneyLabel";
            this.startingMoneyLabel.Size = new System.Drawing.Size(116, 20);
            this.startingMoneyLabel.TabIndex = 15;
            this.startingMoneyLabel.Text = "Starting Money";
            this.startingMoneyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // easyMoneyLabel
            // 
            this.easyMoneyLabel.AutoSize = true;
            this.easyMoneyLabel.Location = new System.Drawing.Point(20, 125);
            this.easyMoneyLabel.Name = "easyMoneyLabel";
            this.easyMoneyLabel.Size = new System.Drawing.Size(33, 13);
            this.easyMoneyLabel.TabIndex = 16;
            this.easyMoneyLabel.Text = "Easy:";
            // 
            // mediumMoneyLabel
            // 
            this.mediumMoneyLabel.AutoSize = true;
            this.mediumMoneyLabel.Location = new System.Drawing.Point(20, 155);
            this.mediumMoneyLabel.Name = "mediumMoneyLabel";
            this.mediumMoneyLabel.Size = new System.Drawing.Size(47, 13);
            this.mediumMoneyLabel.TabIndex = 17;
            this.mediumMoneyLabel.Text = "Medium:";
            // 
            // hardMoneyLabel
            // 
            this.hardMoneyLabel.AutoSize = true;
            this.hardMoneyLabel.Location = new System.Drawing.Point(20, 183);
            this.hardMoneyLabel.Name = "hardMoneyLabel";
            this.hardMoneyLabel.Size = new System.Drawing.Size(33, 13);
            this.hardMoneyLabel.TabIndex = 18;
            this.hardMoneyLabel.Text = "Hard:";
            // 
            // easyMoneyTextBox
            // 
            this.easyMoneyTextBox.Location = new System.Drawing.Point(60, 125);
            this.easyMoneyTextBox.Name = "easyMoneyTextBox";
            this.easyMoneyTextBox.Size = new System.Drawing.Size(86, 20);
            this.easyMoneyTextBox.TabIndex = 19;
            this.easyMoneyTextBox.TextChanged += new System.EventHandler(this.ValidateMoney);
            this.easyMoneyTextBox.MouseCaptureChanged += new System.EventHandler(this.ValidateMoney);
            // 
            // hardMoneyTextBox
            // 
            this.hardMoneyTextBox.Location = new System.Drawing.Point(59, 183);
            this.hardMoneyTextBox.Name = "hardMoneyTextBox";
            this.hardMoneyTextBox.Size = new System.Drawing.Size(87, 20);
            this.hardMoneyTextBox.TabIndex = 20;
            this.hardMoneyTextBox.TextChanged += new System.EventHandler(this.ValidateMoney);
            this.hardMoneyTextBox.MouseCaptureChanged += new System.EventHandler(this.ValidateMoney);
            // 
            // mediumMoneyTextBox
            // 
            this.mediumMoneyTextBox.Location = new System.Drawing.Point(73, 155);
            this.mediumMoneyTextBox.Name = "mediumMoneyTextBox";
            this.mediumMoneyTextBox.Size = new System.Drawing.Size(73, 20);
            this.mediumMoneyTextBox.TabIndex = 21;
            this.mediumMoneyTextBox.TextChanged += new System.EventHandler(this.ValidateMoney);
            this.mediumMoneyTextBox.MouseCaptureChanged += new System.EventHandler(this.ValidateMoney);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 590);
            this.Controls.Add(this.mediumMoneyTextBox);
            this.Controls.Add(this.hardMoneyTextBox);
            this.Controls.Add(this.easyMoneyTextBox);
            this.Controls.Add(this.hardMoneyLabel);
            this.Controls.Add(this.mediumMoneyLabel);
            this.Controls.Add(this.easyMoneyLabel);
            this.Controls.Add(this.startingMoneyLabel);
            this.Controls.Add(this.tileComboBox);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.loadMapButton);
            this.Controls.Add(this.saveMapButton);
            this.Controls.Add(this.currentColorGroupBox);
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapEditor_FormClosing);
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapEditor_MouseUp);
            this.currentColorGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox currentColorGroupBox;
        private System.Windows.Forms.Button currentTileButton;
        private System.Windows.Forms.Button saveMapButton;
        private System.Windows.Forms.Button loadMapButton;
        private System.Windows.Forms.OpenFileDialog saveLoadMapDialog;
        private System.Windows.Forms.GroupBox mapGroupBox;
        private System.Windows.Forms.ComboBox tileComboBox;
        private System.Windows.Forms.Label startingMoneyLabel;
        private System.Windows.Forms.Label easyMoneyLabel;
        private System.Windows.Forms.Label mediumMoneyLabel;
        private System.Windows.Forms.Label hardMoneyLabel;
        private System.Windows.Forms.TextBox easyMoneyTextBox;
        private System.Windows.Forms.TextBox hardMoneyTextBox;
        private System.Windows.Forms.TextBox mediumMoneyTextBox;
    }
}