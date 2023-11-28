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
using Draftsteel_Colossus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Draftsteel_Colossus_Visual
{
    public partial class Simulator : Form
    {
        private List<string> cardFileList = new List<string>();
        private List<string> playerFileList = new List<string>();

        private Draft draft = new Draft();

        public Simulator()
        {
            InitializeComponent();

            // Subscribe to the ItemSelectionChanged events
            lv_CardFiles.ItemSelectionChanged += lv_CardFiles_ItemSelectionChanged;
            lv_PlayerFiles.ItemSelectionChanged += lv_PlayerFiles_ItemSelectionChanged;
        }

        private void btn_GenerateDraft_Click(object sender, EventArgs e)
        {
            draft.playDraft();
        }

        private void lv_CardFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Check if the item is selected
            if (e.IsSelected)
            {
                // Get the selected item
                ListViewItem selectedItem = e.Item;

                // Access item properties
                string itemName = selectedItem.Text;
                string subItemText = selectedItem.SubItems[0].Text;

                // Set the filename for the draft
                draft.setCardsFileName(itemName);

                // Set the label
                lb_SelectedCardFile.Text = itemName;
            }
        }

        private void lv_PlayerFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Check if the item is selected
            if (e.IsSelected)
            {
                // Get the selected item
                ListViewItem selectedItem = e.Item;

                // Access item properties
                string itemName = selectedItem.Text;
                string subItemText = selectedItem.SubItems[0].Text;

                // Set the filename for the draft
                draft.setPlayerFileName(itemName);

                // Set the label
                lb_SelectedPlayerFile.Text = itemName;
            }
        }

        private void lv_CardFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_PlayerFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_AddCardFile_Click(object sender, EventArgs e)
        {
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
                if (!cardFileList.Contains(selectedFile))
                {
                    // Add the file to the list
                    cardFileList.Add(selectedFile);

                    // Update the ListBox
                    UpdateFileList(lv_CardFiles, cardFileList);

                }
                else
                {
                    MessageBox.Show("File already in the list.", "Duplicate File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_AddPlayerFile_Click(object sender, EventArgs e)
        {
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
                if (!playerFileList.Contains(selectedFile))
                {
                    // Add the file to the list
                    playerFileList.Add(selectedFile);

                    // Update the ListBox
                    UpdateFileList(lv_PlayerFiles, playerFileList);
                }
                else
                {
                    MessageBox.Show("File already in the list.", "Duplicate File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
        }
        private void UpdateFileList(System.Windows.Forms.ListView listBoxFiles, List<string> fileList)
        {
            // Clear the ListBox
            listBoxFiles.Items.Clear();

            // Add each file to the ListBox
            foreach (string file in fileList)
            {
                listBoxFiles.Items.Add(Path.GetFileName(file));
            }
        }

        private void lb_SelectedCardLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

