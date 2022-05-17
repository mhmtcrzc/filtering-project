using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilteringProject.Adapter;
using FilteringProject.DataAccessLayer;

namespace FilteringProject
{
    public partial class Form1 : Form
    {
        private IDataAccess access;
        private DataAdapter adapter;
        private DataModel model;

        public Form1()
        {
            InitializeComponent();

            // Data access module
            access = new SqlLiteDataAccess();

            // Adapter between data access module and model
            adapter = new SQLDataAdapter();

            // Initialize model with an adapter & Set model contents
            model = new DataModel(adapter);
            model.SetModel(access.Read());

            // Initial values and selections
            this.radioButton1.Checked = true;
            this.radioButton4.Checked = true;
            this.radioButton6.Checked = true;
            this.trackBar1.Value = 1000;
            this.label3.Text = this.trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pot = trackBar1.Value;
            var bits = Convert.ToInt32(this.radioButton1.Checked).ToString() + Convert.ToInt32(this.radioButton4.Checked).ToString() 
                + Convert.ToInt32(this.radioButton6.Checked).ToString();
            var value = Convert.ToInt32(bits, 2);
            TableTypes type = (TableTypes) value;
            var x = model.GetTables((t) => t.Pot <= pot && (type == TableTypes.None || t.Type.HasFlag(type)));
            this.dataGridView1.DataSource = x;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }
    }
}
