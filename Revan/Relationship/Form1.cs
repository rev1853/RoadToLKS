using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Relationship
{
    public partial class Form1 : Form
    {
        private EsemkaCorporationEntities entities = new EsemkaCorporationEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = entities.employee.ToList();
        }

        private void employeeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (employeeBindingSource.Current is employee emp)
            {
                job job = emp.position.First(f => f.deleted_at == null).job;
                //job job = emp.position.Where(f => f.deleted_at == null).First().job
                var joblevel = job.job_level.id;

                // mengambil data partner
                var partners = entities.employee
                    .Where(z =>
                    z.id != emp.id 
                    &&
                    z.deleted_at == null
                    &&
                    z.position.Any(p => p.deleted_at == null && p.job.job_level_id == joblevel)
                    ).ToList();
                employeeBindingSource1.DataSource = partners;


                var subordinate = entities.employee
                    .Where(n =>
                        n.id != emp.id
                        &&
                        n.deleted_at == null
                        &&
                        n.position.Where(m => m.deleted_at == null && m.job.job_level_id == joblevel - 1).Count() > 0
                        ).ToList();
                // jika diubah ke query
                // SELECT * FROM employee e JOIN position p ON e.id = p.employee_id WHERE e.id != <id> && e.deleted_at == null && p.job_id IN (SELECT id FROM job WHERE job_level_id < joblevel)

                employeeBindingSource2.DataSource = subordinate;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is employee emp)
            {
                if (jobColumn.Index == e.ColumnIndex)
                {
                    e.Value = emp.position.First(f => f.deleted_at == null).job.name;
                }

                if (levelColumn.Index == e.ColumnIndex)
                {
                    e.Value = emp.position.First(f => f.deleted_at == null).job.job_level_id;
                }
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is employee emp)
            {
                if (jobColumn.Index == e.ColumnIndex)
                {
                    e.Value = emp.position.First(f => f.deleted_at == null).job.name;
                }

                if (levelColumn.Index == e.ColumnIndex)
                {
                    e.Value = emp.position.First(f => f.deleted_at == null).job.job_level_id;
                }
            }
        }
    }
}
