using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AdoNetCategoriesExample3
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private string _connectionString = string.Empty;
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();

            this._connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter("SELECT AVG(UnitPrice) FROM Products", this._connectionString);

                // Create a command builder to generate SQL update, insert, and delete commands based on selectCommand.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

                dataGridView1.DataSource = bindingSource1;

                //cmd.executescalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter("SELECT top 1 OrderDate FROM Orders order by OrderDate desc", this._connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

                dataGridView1.DataSource = bindingSource1;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
