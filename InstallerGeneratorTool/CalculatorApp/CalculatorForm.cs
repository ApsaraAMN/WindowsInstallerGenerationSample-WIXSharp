using System;
using System.Windows.Forms;



namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            display.Text += button.Text;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            display.Text += button.Text;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = display.Text;
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression, "");
                display.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            display.Clear();
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (display.Text.Length > 0)
                display.Text = display.Text.Remove(display.Text.Length - 1);
        }


    }
}
