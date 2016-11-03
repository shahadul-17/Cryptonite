namespace Cryptonite
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.buttonCryptonite = new System.Windows.Forms.Button();
            this.buttonDecryptonite = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxFileAssociation = new System.Windows.Forms.CheckBox();
            this.checkBoxAddToContextMenu = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFile
            // 
            this.textBoxFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textBoxFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFile.Location = new System.Drawing.Point(162, 12);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(249, 23);
            this.textBoxFile.TabIndex = 2;
            this.textBoxFile.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirectory.Location = new System.Drawing.Point(99, 16);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(25, 15);
            this.labelDirectory.TabIndex = 1;
            this.labelDirectory.Text = "File";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.Location = new System.Drawing.Point(417, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 3;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonClick);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(99, 45);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 15);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(162, 41);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(249, 23);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(162, 70);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(108, 19);
            this.checkBoxShowPassword.TabIndex = 6;
            this.checkBoxShowPassword.Text = "Show Password";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // buttonCryptonite
            // 
            this.buttonCryptonite.Enabled = false;
            this.buttonCryptonite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCryptonite.Location = new System.Drawing.Point(225, 166);
            this.buttonCryptonite.Name = "buttonCryptonite";
            this.buttonCryptonite.Size = new System.Drawing.Size(85, 23);
            this.buttonCryptonite.TabIndex = 8;
            this.buttonCryptonite.Text = "Cryptonite";
            this.buttonCryptonite.UseVisualStyleBackColor = true;
            this.buttonCryptonite.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonDecryptonite
            // 
            this.buttonDecryptonite.Enabled = false;
            this.buttonDecryptonite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDecryptonite.Location = new System.Drawing.Point(316, 166);
            this.buttonDecryptonite.Name = "buttonDecryptonite";
            this.buttonDecryptonite.Size = new System.Drawing.Size(85, 23);
            this.buttonDecryptonite.TabIndex = 9;
            this.buttonDecryptonite.Text = "Decryptonite";
            this.buttonDecryptonite.UseVisualStyleBackColor = true;
            this.buttonDecryptonite.Click += new System.EventHandler(this.ButtonClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(102, 145);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(390, 15);
            this.progressBar.TabIndex = 7;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(38, 36);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 9;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelFileSize
            // 
            this.labelFileSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileSize.Location = new System.Drawing.Point(12, 71);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(84, 23);
            this.labelFileSize.TabIndex = 0;
            this.labelFileSize.Text = "0 Bytes";
            this.labelFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(407, 166);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(85, 23);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonClick);
            // 
            // checkBoxFileAssociation
            // 
            this.checkBoxFileAssociation.AutoSize = true;
            this.checkBoxFileAssociation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFileAssociation.Location = new System.Drawing.Point(162, 95);
            this.checkBoxFileAssociation.Name = "checkBoxFileAssociation";
            this.checkBoxFileAssociation.Size = new System.Drawing.Size(138, 19);
            this.checkBoxFileAssociation.TabIndex = 11;
            this.checkBoxFileAssociation.Text = "(.cry) File Association";
            this.checkBoxFileAssociation.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddToContextMenu
            // 
            this.checkBoxAddToContextMenu.AutoSize = true;
            this.checkBoxAddToContextMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAddToContextMenu.Location = new System.Drawing.Point(162, 120);
            this.checkBoxAddToContextMenu.Name = "checkBoxAddToContextMenu";
            this.checkBoxAddToContextMenu.Size = new System.Drawing.Size(294, 19);
            this.checkBoxAddToContextMenu.TabIndex = 12;
            this.checkBoxAddToContextMenu.Text = "Add \"Cryptonite\" Option to Explorer Context Menu";
            this.checkBoxAddToContextMenu.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 200);
            this.Controls.Add(this.checkBoxAddToContextMenu);
            this.Controls.Add(this.checkBoxFileAssociation);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelFileSize);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonDecryptonite);
            this.Controls.Add(this.buttonCryptonite);
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelDirectory);
            this.Controls.Add(this.textBoxFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Cryptonite";
            this.Load += new System.EventHandler(this.FormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormDragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.Button buttonCryptonite;
        private System.Windows.Forms.Button buttonDecryptonite;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxFileAssociation;
        private System.Windows.Forms.CheckBox checkBoxAddToContextMenu;

    }
}