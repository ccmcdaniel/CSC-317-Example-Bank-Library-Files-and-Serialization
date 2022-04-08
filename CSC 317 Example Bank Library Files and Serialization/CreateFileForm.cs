using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC_317_Example_Bank_Library_Files_and_Serialization
{
    public partial class CreateFileForm : BankUIForm
    {

        private StreamWriter streamWriter;

        public CreateFileForm()
        {
            InitializeComponent();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if(result == DialogResult.OK)
            {
                if(string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    try 
                    {
                        var output = new FileStream(fileName, FileMode.OpenOrCreate,
                            FileAccess.Write);

                        streamWriter = new StreamWriter(output);

                        btnSaveAs.Enabled = false;
                        btnEnter.Enabled = true;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }


            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string[] values = GetTextBoxValues();

            if(!string.IsNullOrEmpty(values[(int) TextBoxIndices.Account]))
            {
                try
                {
                    int accountNumber = int.Parse(values[(int)TextBoxIndices.Account]);

                    if (accountNumber > 0)
                    {
                        var record = new Record(accountNumber,
                            values[(int)TextBoxIndices.First],
                            values[(int)TextBoxIndices.Last],
                            decimal.Parse(values[(int)TextBoxIndices.Balance]));

                        streamWriter.WriteLine(
                            $"{record.Account},{record.FirstName},{record.LastName}," +
                            $"{record.Balance}");

                    }
                    else
                    {
                        MessageBox.Show("Invalid Account Number", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(IOException)
                {
                    MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
            }

            ClearTextBoxes();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try 
            {
                //Close stream and underlying file.
                streamWriter?.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Cannot Close File", "Error", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
            }

            Application.Exit();
        }
    }
}
