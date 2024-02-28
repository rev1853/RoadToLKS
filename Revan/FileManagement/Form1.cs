using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagement
{
    public partial class Form1 : Form
    {
        private string fileName = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Filter Gambar|*.png;*.jpeg;*.jpg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog.FileName;
                pictureBox1.Image = Image.FromFile(fileDialog.FileName);

                // jika hanya gambar maka bisa menggunakan method Save dari object Image
                //Image.FromFile(fileDialog.FileName).Save("C:\\Users\\risca\\Pictures\\Camera Roll\\file.jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                DirectoryInfo projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
                string imageDir = Path.Combine(projectDir.FullName, "Images");

                string destination = Path.Combine(imageDir, Path.GetFileName(fileName));
                File.Copy(fileName, destination, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (fileName != null && folderDialog.ShowDialog() == DialogResult.OK)
            {

                string destination = Path.Combine(folderDialog.SelectedPath, Path.GetFileName(fileName));
                File.Copy(fileName, destination, true);
            }
        }
    }
}
