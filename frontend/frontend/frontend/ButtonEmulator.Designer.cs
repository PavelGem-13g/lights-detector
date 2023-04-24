namespace frontend
{
    partial class ButtonEmulator
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.switchesCheckBox = new System.Windows.Forms.CheckBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.comComboBox = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer.Panel1.Controls.Add(this.switchesCheckBox);
            this.splitContainer.Panel1.Controls.Add(this.connectButton);
            this.splitContainer.Panel1.Controls.Add(this.updateButton);
            this.splitContainer.Panel1.Controls.Add(this.comComboBox);
            this.splitContainer.Panel1.Controls.Add(this.portLabel);
            this.splitContainer.Size = new System.Drawing.Size(294, 450);
            this.splitContainer.SplitterDistance = 57;
            this.splitContainer.TabIndex = 5;
            // 
            // switchesCheckBox
            // 
            this.switchesCheckBox.AutoSize = true;
            this.switchesCheckBox.Location = new System.Drawing.Point(15, 32);
            this.switchesCheckBox.Name = "switchesCheckBox";
            this.switchesCheckBox.Size = new System.Drawing.Size(240, 17);
            this.switchesCheckBox.TabIndex = 9;
            this.switchesCheckBox.Text = "Использовать кнопки как переключатели";
            this.switchesCheckBox.UseVisualStyleBackColor = true;
            this.switchesCheckBox.CheckedChanged += new System.EventHandler(this.switchesCheckBox_CheckedChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(194, 5);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(88, 23);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "Подключить";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(150, 5);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(38, 21);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "upd";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // comComboBox
            // 
            this.comComboBox.FormattingEnabled = true;
            this.comComboBox.Location = new System.Drawing.Point(53, 5);
            this.comComboBox.Name = "comComboBox";
            this.comComboBox.Size = new System.Drawing.Size(91, 21);
            this.comComboBox.TabIndex = 6;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 9);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(35, 13);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "Порт:";
            // 
            // ButtonEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 450);
            this.Controls.Add(this.splitContainer);
            this.Name = "ButtonEmulator";
            this.Text = "ButtonEmulator";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.CheckBox switchesCheckBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ComboBox comComboBox;
        private System.Windows.Forms.Label portLabel;
    }
}