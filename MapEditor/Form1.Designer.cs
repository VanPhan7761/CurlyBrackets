namespace Homework7Cassiar
{
    partial class Form1
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
            this.loadMapButton = new System.Windows.Forms.Button();
            this.loadMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.createLevelGroupBox = new System.Windows.Forms.GroupBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.createMapButton = new System.Windows.Forms.Button();
            this.createLevelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadMapButton
            // 
            this.loadMapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loadMapButton.Location = new System.Drawing.Point(13, 13);
            this.loadMapButton.Name = "loadMapButton";
            this.loadMapButton.Size = new System.Drawing.Size(298, 64);
            this.loadMapButton.TabIndex = 0;
            this.loadMapButton.Text = "Load Map";
            this.loadMapButton.UseVisualStyleBackColor = true;
            this.loadMapButton.Click += new System.EventHandler(this.LoadMapButton_Click);
            // 
            // loadMapDialog
            // 
            this.loadMapDialog.FileName = "openFileDialog1";
            // 
            // createLevelGroupBox
            // 
            this.createLevelGroupBox.Controls.Add(this.widthTextBox);
            this.createLevelGroupBox.Controls.Add(this.heightTextBox);
            this.createLevelGroupBox.Controls.Add(this.heightLabel);
            this.createLevelGroupBox.Controls.Add(this.widthLabel);
            this.createLevelGroupBox.Controls.Add(this.createMapButton);
            this.createLevelGroupBox.Location = new System.Drawing.Point(13, 95);
            this.createLevelGroupBox.Name = "createLevelGroupBox";
            this.createLevelGroupBox.Size = new System.Drawing.Size(298, 197);
            this.createLevelGroupBox.TabIndex = 1;
            this.createLevelGroupBox.TabStop = false;
            this.createLevelGroupBox.Text = "Create Map";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Enabled = false;
            this.widthTextBox.Location = new System.Drawing.Point(125, 44);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(167, 20);
            this.widthTextBox.TabIndex = 6;
            this.widthTextBox.Text = "16";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Enabled = false;
            this.heightTextBox.Location = new System.Drawing.Point(125, 76);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(167, 20);
            this.heightTextBox.TabIndex = 5;
            this.heightTextBox.Text = "12";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.heightLabel.Location = new System.Drawing.Point(6, 77);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(112, 20);
            this.heightLabel.TabIndex = 4;
            this.heightLabel.Text = "Height in Tiles:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.widthLabel.Location = new System.Drawing.Point(6, 44);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(106, 20);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width in Tiles:";
            // 
            // createMapButton
            // 
            this.createMapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.createMapButton.Location = new System.Drawing.Point(6, 114);
            this.createMapButton.Name = "createMapButton";
            this.createMapButton.Size = new System.Drawing.Size(286, 64);
            this.createMapButton.TabIndex = 2;
            this.createMapButton.Text = "Create Map";
            this.createMapButton.UseVisualStyleBackColor = true;
            this.createMapButton.Click += new System.EventHandler(this.CreateMapButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 293);
            this.Controls.Add(this.createLevelGroupBox);
            this.Controls.Add(this.loadMapButton);
            this.Name = "Form1";
            this.Text = "Create/Load Menu";
            this.createLevelGroupBox.ResumeLayout(false);
            this.createLevelGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadMapButton;
        private System.Windows.Forms.OpenFileDialog loadMapDialog;
        private System.Windows.Forms.GroupBox createLevelGroupBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Button createMapButton;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
    }
}

