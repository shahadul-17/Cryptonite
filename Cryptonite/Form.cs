using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cryptonite
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string fileName;

        private static OpenFileDialog openFileDialog = new OpenFileDialog();

        public Form()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            if (sender.Equals(this))
            {
                if (!new FileInfo(Program.fileNames[0]).Exists)
                {
                    if (MessageBox.Show(null, "Would you like to associate (.cry) file extension with Cryptonite\nand add Cryptonite to explorer?", "Cryptonite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Program.StartProcess("5");
                        Program.settings[0] = true;
                        Program.settings[1] = true;
                        Program.WriteSettings();
                    }
                    else
                    {
                        Program.settings[0] = false;
                        Program.settings[1] = false;
                        Program.WriteSettings();
                    }
                }

                openFileDialog.Title = "Browse";
                openFileDialog.Multiselect = false;

                if (fileName == null)
                {
                    pictureBoxIcon.Image = SystemIcons.WinLogo.ToBitmap();
                }
                else
                {
                    textBoxFile.Text = fileName;
                }

                Program.ReadSettings();

                checkBoxFileAssociation.Checked = Program.settings[0];
                checkBoxAddToContextMenu.Checked = Program.settings[1];

                checkBoxFileAssociation.CheckedChanged += new EventHandler(CheckBoxCheckedChanged);
                checkBoxAddToContextMenu.CheckedChanged += new EventHandler(CheckBoxCheckedChanged);
            }
        }

        private void FormDragDrop(object sender, DragEventArgs e)
        {
            if (sender.Equals(this))
            {
                textBoxFile.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }

        private void FormDragEnter(object sender, DragEventArgs e)
        {
            if (sender.Equals(this) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (sender.Equals(textBoxFile))
            {
                if (textBoxFile.Text.Length == 0 || !File.Exists(textBoxFile.Text))
                {
                    buttonCryptonite.Enabled = buttonDecryptonite.Enabled = false;
                }
                else if (textBoxFile.Text.EndsWith(Cryptography.extension))
                {
                    buttonCryptonite.Enabled = buttonDecryptonite.Enabled = true;

                    SetFileIconAndFileSize(textBoxFile.Text);
                }
                else
                {
                    buttonCryptonite.Enabled = !(buttonDecryptonite.Enabled = false);

                    SetFileIconAndFileSize(textBoxFile.Text);
                }
            }
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(checkBoxShowPassword))
            {
                textBoxPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
            }
            else if (sender.Equals(checkBoxFileAssociation) || sender.Equals(checkBoxAddToContextMenu))
            {
                CheckBoxEvent(sender);
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender.Equals(buttonBrowse))
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    textBoxFile.Text = openFileDialog.FileName;
                }
            }
            else if (sender.Equals(buttonCryptonite))
            {
                ButtonEvent(true, false);
            }
            else if (sender.Equals(buttonDecryptonite))
            {
                ButtonEvent(false, false);
            }
            else if (sender.Equals(buttonStop))
            {
                Cryptography.run = buttonStop.Enabled = false;
            }
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (sender.Equals(backgroundWorker))
            {
                Cryptography.CryptoniteFile(textBoxFile.Text, textBoxPassword.Text);
            }
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender.Equals(backgroundWorker))
            {
                ButtonEvent(Cryptography.encrypt, true);
            }
        }

        private void SetFileIconAndFileSize(string fileName)
        {
            try
            {
                pictureBoxIcon.Image = Icon.ExtractAssociatedIcon(fileName).ToBitmap();
            }
            catch
            {
                pictureBoxIcon.Image = SystemIcons.WinLogo.ToBitmap();
            }

            try
            {
                labelFileSize.Text = Cryptography.FormatFileSize(new FileInfo(fileName).Length);
            }
            catch
            {
                labelFileSize.Text = "0 Bytes";
            }
        }

        private void CheckBoxEvent(Object sender)
        {
            CheckBox checkBox = sender as CheckBox;

            try
            {
                if (checkBox.Equals(checkBoxFileAssociation))
                {
                    if (checkBox.Checked)
                    {
                        Program.StartProcess("1");
                    }
                    else
                    {
                        Program.StartProcess("2");
                    }

                    Program.settings[0] = checkBoxFileAssociation.Checked;
                }
                else if (checkBox.Equals(checkBoxAddToContextMenu))
                {
                    if (checkBox.Checked)
                    {
                        Program.StartProcess("3");
                    }
                    else
                    {
                        Program.StartProcess("4");
                    }

                    Program.settings[1] = checkBoxAddToContextMenu.Checked;
                }
                
                Program.WriteSettings();
            }
            catch
            {
                checkBox.CheckedChanged -= new EventHandler(CheckBoxCheckedChanged);
                checkBox.Checked = !checkBox.Checked;
                checkBox.CheckedChanged += new EventHandler(CheckBoxCheckedChanged);
            }
        }

        private void ButtonEvent(bool encrypt, bool controlsEnabled)
        {
            Cryptography.encrypt = encrypt;

            if (encrypt)
            {
                buttonCryptonite.Enabled = controlsEnabled;

                if (!controlsEnabled)
                {
                    buttonDecryptonite.Enabled = false;
                }
                else
                {
                    buttonDecryptonite.Enabled = textBoxFile.Text.EndsWith(Cryptography.extension);
                }
            }
            else
            {
                buttonCryptonite.Enabled = buttonDecryptonite.Enabled = controlsEnabled;
            }

            if ((buttonStop.Enabled = !(buttonBrowse.Enabled = textBoxPassword.Enabled = textBoxFile.Enabled = AllowDrop = controlsEnabled)))
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        public void ShowErrorMessage(string message)
        {
            Action action = () =>
            {
                MessageBox.Show(this, message, "Cryptonite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Invoke(action);
        }

        public void UpdateProgress(int value)
        {
            Action action = () => progressBar.Value = value;
            Invoke(action);
        }
    }
}