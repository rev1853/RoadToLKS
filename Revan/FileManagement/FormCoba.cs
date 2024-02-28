using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagement
{
    public partial class FormCoba : Form
    {
        private readonly EsemkaHeroEntities entities = new EsemkaHeroEntities();

        public FormCoba()
        {
            InitializeComponent();
        }

        private void bindingSource1_DataSourceChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Clan clan in bindingSource1.List)
            {
                Button btn = new Button
                {
                    Width = 100,
                    Height = 30,
                    Text = clan.Name,
                    BackColor = clan.Name == "Chinese" ? Color.Red : Color.Gray,
                    // cara 2 : step 2
                    //Tag = clan
                };

                // cara 2: step 3
                //btn.Click += Btn_Click;

                // cara 1 : step 1
                //btn.Click += (s, f) => {
                //    MessageBox.Show(clan.Name);
                //};

                btn.Click += (g, h) => bindingSource1.Position = bindingSource1.IndexOf(clan);

                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // cara 2 : step 2
            //Clan clan = (sender as Button).Tag as Clan;
            //MessageBox.Show(clan.Name);

        }

        private void FormCoba_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = entities.Clan.ToList();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Clan clan)
            {
                MessageBox.Show(clan.Name);
            }
        }
    }
}
