namespace CSC_317_Example_Bank_Library_Files_and_Serialization
{
    public partial class BankUIForm : Form
    {
        //number of textboxes
        protected int TextBoxCount { get; set; } = 4;
        public enum TextBoxIndices { Account, First, Last, Balance };

        public BankUIForm()
        {
            InitializeComponent();
        }

        public void ClearTextBoxes()
        {
            foreach (Control guiControl in this.Controls)
                if((guiControl as TextBox) != null)
                    (guiControl as TextBox).Clear();
        }

        public void setTextBoxValues(string[] values)
        {
            if (values.Length != TextBoxCount)
            {
                string message = $"There must be {TextBoxCount} strings in the array";
                throw new ArgumentException(message, nameof(values));
            }
            else
            {
                txtAccount.Text = values[(int)TextBoxIndices.Account];
                txtFirstName.Text = values[(int)TextBoxIndices.First];
                txtLastName.Text = values[(int)TextBoxIndices.Last];
                txtBalance.Text = values[(int)TextBoxIndices.Balance];
            }
        }

        public string[] GetTextBoxValues()
        {
            return new string[] { txtAccount.Text, txtFirstName.Text, 
                txtLastName.Text, txtBalance.Text };

        }
    }
}