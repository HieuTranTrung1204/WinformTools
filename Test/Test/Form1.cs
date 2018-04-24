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
     
        private BindingSource bindingSource1 = new BindingSource();

        List<Knight> listdata = new List<Knight>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            ic.HeaderText = "Hình";
            ic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ic.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ic.Name = "Av111t";
            ic.DataPropertyName = "Avt";
            dataGridView1.Columns.Add(ic);

            // Initialize the form.
            this.Controls.Add(dataGridView1);
            this.AutoSize = true;
            this.Text = "DataGridView object binding demo";
            
            listdata.Add(new Knight(Title.King, "Uther", true, Image.FromFile(@"Resources\icon_places.png")));
            listdata.Add(new Knight(Title.King, "Arthur", true, Image.FromFile(@"Resources\icon_hashtags.png")));
            listdata.Add(new Knight(Title.Sir, "Mordred", false, Image.FromFile(@"Resources\icon_users.png")));
            listdata.Add(new Knight(Title.Sir, "Gawain", true, Image.FromFile(@"Resources\icon_hashtags.png")));
            for (int i = 0; i < 100; i++)
            {
                listdata.Add(new Knight(Title.Sir, "Galahad", true, Image.FromFile(@"Resources\icon_users.png")));

            }

            bindingSource1.DataSource = listdata;

            dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUserDetails_RowPostPaint);

        }

        DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetValues(typeof(Title));
            combo.DataPropertyName = "Title";
            combo.Name = "Title";
            return combo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (text.Length > 0)
            {
                bindingSource1.DataSource = listdata;
                dataGridView1.DataSource = bindingSource1;
            }
        }
        private void dgvUserDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

    }
}
