using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqTOSql
{
    public partial class Form1 : Form
    {
        EmplinqsDataContext db = new EmplinqsDataContext();
        public Form1()
        {
            InitializeComponent();
        }
        private void Showe()
        {
            var emptable = from e1 in db.Emps
                           select e1;
            dataGridView1.DataSource = emptable;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Showe();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btEmpsearch_Click(object sender, EventArgs e)
        {
            var empd = db.sp_Sel(Convert.ToInt32(TXTempid.Text));
            dataGridView1.DataSource = empd;
        }

        private void btInsertEmp_Click(object sender, EventArgs e)
        {
            var inemp = db.sp_InsertEmp(Convert.ToString(TxtEname.Text), Convert.ToSingle(TxtSal.Text), Convert.ToInt32(TxtDeptno.Text));
            dataGridView1.DataSource = inemp;
            Showe();
        }

        private void btUpEmp_Click(object sender, EventArgs e)
        {
            var upemp = db.sp_UpdateEmp(Convert.ToInt32(TXTempid.Text), Convert.ToString(TxtEname.Text), Convert.ToSingle(TxtSal.Text), Convert.ToInt32(TxtDeptno.Text));
            dataGridView1.DataSource = upemp;
            Showe();
        }

        private void btDelemp_Click(object sender, EventArgs e)
        {
            var delemp = db.Emps.Single(p => p.Empid == Convert.ToInt32(TXTempid.Text));
            db.Emps.DeleteOnSubmit(delemp);
            db.SubmitChanges();
            Showe();
        }

    }
}
