using Microsoft.VisualBasic;
using System.Collections;
using System.Text;

namespace CSVTEST
{
    public partial class Form1 : Form
    {
        private OpenFileDialog ofd;
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
           if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var transactionHistory = new Dictionary<int, TransactionDetail>();

            if (this.textBox1!= null || this.textBox1.Text != "")
            {
                var transactionHistory = Converter.ParseFromCSV(this.textBox1.Text);
                StringBuilder s = new StringBuilder();

                foreach( KeyValuePair<int, TransactionDetail> transaction in transactionHistory )
                {
                     TransactionDetail transDetail = (TransactionDetail)transaction.Value;
                     s.Append($"Code: {transDetail.Code}" + "\n" +
                        $"Cost: {transDetail.Cost.ToString()}" + "\n" +
                        $"Date: {transDetail.Date.ToString()}" + "\n" );
                }
                richTextBox1.Text = s.ToString();
                
            }
        }
    }
}