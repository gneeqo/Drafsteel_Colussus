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

namespace Draftsteel_Colossus_Visual
{
    public partial class Bingus : Form
    {

        private List<string> fileList = new List<string>();
        private Bitmap image;
        private string cardname = "Black Lotus";

        public Bingus()
        {
            InitializeComponent();
        }

        private void btn_ClickMe_Click(object sender, EventArgs e)
        {
            lb_MyLabel.Text = "Hello there!";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files (*.*)|*.*";

            // Set the initial directory two levels above the application's executable
            string initialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Data");
            openFileDialog.InitialDirectory = Path.GetFullPath(initialDirectory);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;

                // Check if the file is already in the list
                if (!fileList.Contains(selectedFile))
                {
                    // Add the file to the list
                    fileList.Add(selectedFile);

                    // Update the ListBox
                    UpdateFileList();
                }
                else
                {
                    MessageBox.Show("File already in the list.", "Duplicate File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UpdateFileList()
        {
            // Clear the ListBox
            lv_FileView.Items.Clear();

            // Add each file to the ListBox
            foreach (string file in fileList)
            {
                lv_FileView.Items.Add(Path.GetFileName(file));
            }
        }

        private void lb_MyLabel_Click(object sender, EventArgs e)
        {
            lb_MyLabel.Text = "Secret";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cardname = tb_InputBox.Text;
        }

        private void Bingus_Load(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            image = ScryfallAPI.GetCardImage(cardname);
            pictureBox1.Image = image;
        }
    }
}
