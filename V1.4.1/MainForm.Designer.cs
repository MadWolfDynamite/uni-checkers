namespace CheckersGame
{
    partial class MainForm {
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
            this.boardBox = new System.Windows.Forms.GroupBox();
            this.darkBox = new System.Windows.Forms.GroupBox();
            this.remainingDarkLabel = new System.Windows.Forms.Label();
            this.lightBox = new System.Windows.Forms.GroupBox();
            this.remainingLightLabel = new System.Windows.Forms.Label();
            this.diffBox = new System.Windows.Forms.GroupBox();
            this.hardRadio = new System.Windows.Forms.RadioButton();
            this.normalRadio = new System.Windows.Forms.RadioButton();
            this.easyRadio = new System.Windows.Forms.RadioButton();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.darkBox.SuspendLayout();
            this.lightBox.SuspendLayout();
            this.diffBox.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardBox
            // 
            this.boardBox.Enabled = false;
            this.boardBox.Location = new System.Drawing.Point(12, 12);
            this.boardBox.Name = "boardBox";
            this.boardBox.Size = new System.Drawing.Size(550, 553);
            this.boardBox.TabIndex = 0;
            this.boardBox.TabStop = false;
            this.boardBox.Text = "GameBoard";
            // 
            // darkBox
            // 
            this.darkBox.Controls.Add(this.remainingDarkLabel);
            this.darkBox.Location = new System.Drawing.Point(568, 12);
            this.darkBox.Name = "darkBox";
            this.darkBox.Size = new System.Drawing.Size(148, 94);
            this.darkBox.TabIndex = 1;
            this.darkBox.TabStop = false;
            this.darkBox.Text = "Remaining Dark";
            // 
            // remainingDarkLabel
            // 
            this.remainingDarkLabel.AutoSize = true;
            this.remainingDarkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingDarkLabel.Location = new System.Drawing.Point(49, 28);
            this.remainingDarkLabel.Name = "remainingDarkLabel";
            this.remainingDarkLabel.Size = new System.Drawing.Size(57, 39);
            this.remainingDarkLabel.TabIndex = 0;
            this.remainingDarkLabel.Text = "20";
            this.remainingDarkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightBox
            // 
            this.lightBox.Controls.Add(this.remainingLightLabel);
            this.lightBox.Location = new System.Drawing.Point(722, 12);
            this.lightBox.Name = "lightBox";
            this.lightBox.Size = new System.Drawing.Size(148, 94);
            this.lightBox.TabIndex = 2;
            this.lightBox.TabStop = false;
            this.lightBox.Text = "Remaining Light";
            // 
            // remainingLightLabel
            // 
            this.remainingLightLabel.AutoSize = true;
            this.remainingLightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingLightLabel.Location = new System.Drawing.Point(46, 28);
            this.remainingLightLabel.Name = "remainingLightLabel";
            this.remainingLightLabel.Size = new System.Drawing.Size(57, 39);
            this.remainingLightLabel.TabIndex = 1;
            this.remainingLightLabel.Text = "20";
            this.remainingLightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // diffBox
            // 
            this.diffBox.Controls.Add(this.hardRadio);
            this.diffBox.Controls.Add(this.normalRadio);
            this.diffBox.Controls.Add(this.easyRadio);
            this.diffBox.Location = new System.Drawing.Point(573, 112);
            this.diffBox.Name = "diffBox";
            this.diffBox.Size = new System.Drawing.Size(297, 106);
            this.diffBox.TabIndex = 3;
            this.diffBox.TabStop = false;
            this.diffBox.Text = "Difficulty";
            // 
            // hardRadio
            // 
            this.hardRadio.AutoSize = true;
            this.hardRadio.Location = new System.Drawing.Point(51, 75);
            this.hardRadio.Name = "hardRadio";
            this.hardRadio.Size = new System.Drawing.Size(48, 17);
            this.hardRadio.TabIndex = 2;
            this.hardRadio.TabStop = true;
            this.hardRadio.Text = "Hard";
            this.hardRadio.UseVisualStyleBackColor = true;
            this.hardRadio.CheckedChanged += new System.EventHandler(this.hardRadio_CheckedChanged);
            // 
            // normalRadio
            // 
            this.normalRadio.AutoSize = true;
            this.normalRadio.Location = new System.Drawing.Point(51, 52);
            this.normalRadio.Name = "normalRadio";
            this.normalRadio.Size = new System.Drawing.Size(101, 17);
            this.normalRadio.TabIndex = 1;
            this.normalRadio.TabStop = true;
            this.normalRadio.Text = "Normal (Default)";
            this.normalRadio.UseVisualStyleBackColor = true;
            this.normalRadio.CheckedChanged += new System.EventHandler(this.normalRadio_CheckedChanged);
            // 
            // easyRadio
            // 
            this.easyRadio.AutoSize = true;
            this.easyRadio.Location = new System.Drawing.Point(51, 29);
            this.easyRadio.Name = "easyRadio";
            this.easyRadio.Size = new System.Drawing.Size(48, 17);
            this.easyRadio.TabIndex = 0;
            this.easyRadio.TabStop = true;
            this.easyRadio.Text = "Easy";
            this.easyRadio.UseVisualStyleBackColor = true;
            this.easyRadio.CheckedChanged += new System.EventHandler(this.easyRadio_CheckedChanged);
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.resetButton);
            this.controlBox.Controls.Add(this.endButton);
            this.controlBox.Controls.Add(this.startButton);
            this.controlBox.Location = new System.Drawing.Point(573, 224);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(297, 131);
            this.controlBox.TabIndex = 4;
            this.controlBox.TabStop = false;
            this.controlBox.Text = "Game Controls";
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(51, 89);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(201, 29);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "RESTART GAME";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // endButton
            // 
            this.endButton.Enabled = false;
            this.endButton.Location = new System.Drawing.Point(51, 54);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(201, 29);
            this.endButton.TabIndex = 5;
            this.endButton.Text = "END GAME";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(51, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(201, 29);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START GAME";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 576);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.diffBox);
            this.Controls.Add(this.lightBox);
            this.Controls.Add(this.darkBox);
            this.Controls.Add(this.boardBox);
            this.Name = "MainForm";
            this.Text = "Checkers Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.darkBox.ResumeLayout(false);
            this.darkBox.PerformLayout();
            this.lightBox.ResumeLayout(false);
            this.lightBox.PerformLayout();
            this.diffBox.ResumeLayout(false);
            this.diffBox.PerformLayout();
            this.controlBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boardBox;
        private System.Windows.Forms.GroupBox darkBox;
        private System.Windows.Forms.Label remainingDarkLabel;
        private System.Windows.Forms.GroupBox lightBox;
        private System.Windows.Forms.GroupBox diffBox;
        private System.Windows.Forms.Label remainingLightLabel;
        private System.Windows.Forms.GroupBox controlBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RadioButton normalRadio;
        private System.Windows.Forms.RadioButton easyRadio;
        private System.Windows.Forms.RadioButton hardRadio;
    }
}

