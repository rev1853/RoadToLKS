using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCrud
{
    public partial class Form1 : Form
    {
        private AlbumEntities1 entities = new AlbumEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // load data
            laguBindingSource.DataSource = entities.Lagu2.ToList();
            laguBindingSource.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // handle update
            entities.Lagu2.AddOrUpdate(laguBindingSource.Current as Lagu2);
            entities.SaveChanges();
            OnLoad(EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // handle delete
            entities.Lagu2.Remove(laguBindingSource.Current as Lagu2);
            entities.SaveChanges();
            OnLoad(EventArgs.Empty);
        }
    }
}
