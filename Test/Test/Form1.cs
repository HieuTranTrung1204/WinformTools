using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    

    public partial class Form1 : Form
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-objects-to-windows-forms-datagridview-controls
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Knight> listdata = new List<Knight>();
            listdata.Add(new Knight(Title.King, "Uther", true));
            listdata.Add(new Knight(Title.King, "Arthur", true));
            listdata.Add(new Knight(Title.Sir, "Mordred", false));
            listdata.Add(new Knight(Title.Sir, "Gawain", true));
            listdata.Add(new Knight(Title.Sir, "Galahad", true));

            bindingSource1.DataSource = listdata;

            // Populate the data source.
            //bindingSource1.Add(new Knight(Title.King, "Uther", true));
            //bindingSource1.Add(new Knight(Title.King, "Arthur", true));
            //bindingSource1.Add(new Knight(Title.Sir, "Mordred", false));
            //bindingSource1.Add(new Knight(Title.Sir, "Gawain", true));
            //bindingSource1.Add(new Knight(Title.Sir, "Galahad", true));

            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns.Add(CreateComboBoxWithEnums());

            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Knight";
            dataGridView1.Columns.Add(column);

            // Initialize and add a check box column.
            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "GoodGuy";
            column.Name = "Good";
            dataGridView1.Columns.Add(column);

            // Inittialize and add image
            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic.HeaderText = "Payment";
            ic.Image = null;
            ic.Name = "cImg";
            ic.Width = 50;
            dataGridView1.Columns.Add(ic);

            // Initialize the form.
            this.Controls.Add(dataGridView1);
            this.AutoSize = true;
            this.Text = "DataGridView object binding demo";
        }

        DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetValues(typeof(Title));
            combo.DataPropertyName = "Title";
            combo.Name = "Title";
            return combo;
        }
    }
}
