namespace WaveEditor
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
            this.enemyLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.enterTimeLabel = new System.Windows.Forms.Label();
            this.tickAmountLabel = new System.Windows.Forms.Label();
            this.saveWaveButton = new System.Windows.Forms.Button();
            this.loadWaveButton = new System.Windows.Forms.Button();
            this.addLineButton = new System.Windows.Forms.Button();
            this.instructionsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.enemyLevelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enemyLabel
            // 
            this.enemyLabel.AutoSize = true;
            this.enemyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.enemyLabel.Location = new System.Drawing.Point(12, 9);
            this.enemyLabel.Name = "enemyLabel";
            this.enemyLabel.Size = new System.Drawing.Size(58, 20);
            this.enemyLabel.TabIndex = 0;
            this.enemyLabel.Text = "Enemy";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.amountLabel.Location = new System.Drawing.Point(229, 9);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(65, 20);
            this.amountLabel.TabIndex = 2;
            this.amountLabel.Text = "Amount";
            // 
            // enterTimeLabel
            // 
            this.enterTimeLabel.AutoSize = true;
            this.enterTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.enterTimeLabel.Location = new System.Drawing.Point(335, 9);
            this.enterTimeLabel.Name = "enterTimeLabel";
            this.enterTimeLabel.Size = new System.Drawing.Size(86, 20);
            this.enterTimeLabel.TabIndex = 4;
            this.enterTimeLabel.Text = "Enter Time";
            // 
            // tickAmountLabel
            // 
            this.tickAmountLabel.AutoSize = true;
            this.tickAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tickAmountLabel.Location = new System.Drawing.Point(441, 9);
            this.tickAmountLabel.Name = "tickAmountLabel";
            this.tickAmountLabel.Size = new System.Drawing.Size(97, 20);
            this.tickAmountLabel.TabIndex = 6;
            this.tickAmountLabel.Text = "Tick Amount";
            // 
            // saveWaveButton
            // 
            this.saveWaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.saveWaveButton.Location = new System.Drawing.Point(747, 31);
            this.saveWaveButton.Name = "saveWaveButton";
            this.saveWaveButton.Size = new System.Drawing.Size(135, 65);
            this.saveWaveButton.TabIndex = 68;
            this.saveWaveButton.Text = "Save Wave";
            this.saveWaveButton.UseVisualStyleBackColor = true;
            this.saveWaveButton.Click += new System.EventHandler(this.SaveWaveButton_Click);
            // 
            // loadWaveButton
            // 
            this.loadWaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loadWaveButton.Location = new System.Drawing.Point(747, 102);
            this.loadWaveButton.Name = "loadWaveButton";
            this.loadWaveButton.Size = new System.Drawing.Size(135, 65);
            this.loadWaveButton.TabIndex = 69;
            this.loadWaveButton.Text = "Load Wave";
            this.loadWaveButton.UseVisualStyleBackColor = true;
            this.loadWaveButton.Click += new System.EventHandler(this.LoadWaveButton_Click);
            // 
            // addLineButton
            // 
            this.addLineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addLineButton.Location = new System.Drawing.Point(747, 173);
            this.addLineButton.Name = "addLineButton";
            this.addLineButton.Size = new System.Drawing.Size(135, 65);
            this.addLineButton.TabIndex = 70;
            this.addLineButton.Text = "Add Line";
            this.addLineButton.UseVisualStyleBackColor = true;
            this.addLineButton.Click += new System.EventHandler(this.AddLineButton_Click);
            // 
            // instructionsRichTextBox
            // 
            this.instructionsRichTextBox.Enabled = false;
            this.instructionsRichTextBox.Location = new System.Drawing.Point(747, 264);
            this.instructionsRichTextBox.Name = "instructionsRichTextBox";
            this.instructionsRichTextBox.Size = new System.Drawing.Size(135, 153);
            this.instructionsRichTextBox.TabIndex = 71;
            this.instructionsRichTextBox.Text = "Lines cannot be partially filled.\nYou cannot skip lines.\nWhen adding decimals mak" +
    "e sure to put 0 first.";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.instructionsLabel.Location = new System.Drawing.Point(743, 241);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(92, 20);
            this.instructionsLabel.TabIndex = 72;
            this.instructionsLabel.Text = "Instructions";
            // 
            // enemyLevelLabel
            // 
            this.enemyLevelLabel.AutoSize = true;
            this.enemyLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.enemyLevelLabel.Location = new System.Drawing.Point(118, 9);
            this.enemyLevelLabel.Name = "enemyLevelLabel";
            this.enemyLevelLabel.Size = new System.Drawing.Size(46, 20);
            this.enemyLevelLabel.TabIndex = 74;
            this.enemyLevelLabel.Text = "Level";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(911, 414);
            this.Controls.Add(this.enemyLevelLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.instructionsRichTextBox);
            this.Controls.Add(this.addLineButton);
            this.Controls.Add(this.loadWaveButton);
            this.Controls.Add(this.saveWaveButton);
            this.Controls.Add(this.tickAmountLabel);
            this.Controls.Add(this.enterTimeLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.enemyLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enemyLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label enterTimeLabel;
        private System.Windows.Forms.Label tickAmountLabel;
        private System.Windows.Forms.Button saveWaveButton;
        private System.Windows.Forms.Button loadWaveButton;
        private System.Windows.Forms.Button addLineButton;
        private System.Windows.Forms.RichTextBox instructionsRichTextBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label enemyLevelLabel;
    }
}

