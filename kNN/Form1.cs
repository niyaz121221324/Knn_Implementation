using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kNN
{
    public partial class frmMain : Form
    {
        private string customerfile;
        private string trainfile;

        private int k = 0;
       
        private int counter = 0;

        private List <Customer> lCustomer = new List<Customer>() ;
        private List<Customer> uCustomer = new List<Customer>();

        public frmMain()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            trainfile = "customers.txt";

            this.lblStatus.Visible = false;

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(trainfile);

            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(' ');

                Customer cus = new Customer();

                cus.Name = split[0];

                cus.Age = Int32.Parse(split[1]);
                cus.Gender = Int32.Parse(split[2]);
                cus.Incoming = Int32.Parse(split[3]);
                cus.NumCard = Int32.Parse(split[4]);
                cus.Response = Int32.Parse(split[5]);

                lCustomer.Add(cus);

                counter = counter + 1;
            }

            file.Close();

            this.lblTotal.Text = "/ " + counter;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog cFile = new OpenFileDialog();
            cFile.Filter = "classify customer file|*.txt";

            cFile.ShowDialog();

            customerfile = cFile.FileName;
            this.txtFile.Text = cFile.FileName;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader( customerfile );

            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(' ');


                Customer cus = new Customer();

                cus.Name = split[0];

                cus.Age = Int32.Parse(split[1]);
                cus.Gender = Int32.Parse(split[2]);
                cus.Incoming = Int32.Parse(split[3]);
                cus.NumCard = Int32.Parse(split[4]);
                cus.Response = -1;

                uCustomer.Add(cus);
            }

            file.Close();

        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text != "")
            {
                k = Int32.Parse(txtNumber.Text);

                if (k > counter)
                    MessageBox.Show("k must less than total of training set database", "Warning");
                else
                {
                    Algorithm alg = new Algorithm(k, lCustomer, uCustomer);
                    alg.runkNN();

                    List<Customer> ans = new List<Customer>();
                    ans = alg.getCustomerList();

                    for (int i = 0; i < ans.Count; i++)
                        insertRow(i, ans[i]);
                }
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "k is empty! k should be odd number";
            }
        }

        private void insertRow(int index, Customer cus)
        {
            index = index + 1;

            string[] row = new string[7];
            row[0] = index + "";
            row[1] = cus.Name;
            row[2] = cus.Age + "";
            row[3] = cus.Gender + "";
            row[4] = cus.Incoming + "";
            row[5] = cus.NumCard + "";
            row[6] = cus.Response + "";

            dataGrid.Rows.Add(row);
        }
    }
}
