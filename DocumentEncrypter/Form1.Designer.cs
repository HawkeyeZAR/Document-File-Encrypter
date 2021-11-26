
namespace DocumentEncrypter
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.encryptFileBtn = new System.Windows.Forms.Button();
            this.decryptFileBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileBtn
            // 
            this.openFileBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openFileBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openFileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSpringGreen;
            this.openFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFileBtn.Location = new System.Drawing.Point(501, 7);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 33);
            this.openFileBtn.TabIndex = 0;
            this.openFileBtn.Text = "Open";
            this.openFileBtn.UseVisualStyleBackColor = false;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(483, 22);
            this.fileNameTextBox.TabIndex = 1;
            // 
            // encryptFileBtn
            // 
            this.encryptFileBtn.Enabled = false;
            this.encryptFileBtn.Location = new System.Drawing.Point(12, 49);
            this.encryptFileBtn.Name = "encryptFileBtn";
            this.encryptFileBtn.Size = new System.Drawing.Size(75, 30);
            this.encryptFileBtn.TabIndex = 2;
            this.encryptFileBtn.Text = "Encrypt";
            this.encryptFileBtn.UseVisualStyleBackColor = true;
            this.encryptFileBtn.Click += new System.EventHandler(this.encryptFileBtn_Click);
            // 
            // decryptFileBtn
            // 
            this.decryptFileBtn.Enabled = false;
            this.decryptFileBtn.Location = new System.Drawing.Point(121, 49);
            this.decryptFileBtn.Name = "decryptFileBtn";
            this.decryptFileBtn.Size = new System.Drawing.Size(75, 30);
            this.decryptFileBtn.TabIndex = 3;
            this.decryptFileBtn.Text = "Decrypt";
            this.decryptFileBtn.UseVisualStyleBackColor = true;
            this.decryptFileBtn.Click += new System.EventHandler(this.decryptFileBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 92);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(47, 16);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 117);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.decryptFileBtn);
            this.Controls.Add(this.encryptFileBtn);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.openFileBtn);
            this.Name = "MainForm";
            this.Text = "Document Encrypter / Decrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button encryptFileBtn;
        private System.Windows.Forms.Button decryptFileBtn;
        private System.Windows.Forms.Label statusLabel;
    }
}

