﻿using Draftsteel_Colossus;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Draftsteel_Colossus_Visual
{
    public partial class Draft_Visual : Form
    {
        private Draft draft;

        // Keep a list of all the player labels and images
        List<PictureBox> playerImages = new List<PictureBox>();
        List<Label> playerLabels = new List<Label>();

        public Draft_Visual(Draft _draft)
        {
            draft = _draft;
            InitializeComponent();

            // Add all of the images/labels to their respective lists
            playerImages.Add(pic_Player0);
            playerImages.Add(pic_Player1);
            playerImages.Add(pic_Player2);
            playerImages.Add(pic_Player3);
            playerImages.Add(pic_Player4);
            playerImages.Add(pic_Player5);
            playerImages.Add(pic_Player6);
            playerImages.Add(pic_Player7);

            playerLabels.Add(lb_Player0);
            playerLabels.Add(lb_Player1);
            playerLabels.Add(lb_Player2);
            playerLabels.Add(lb_Player3);
            playerLabels.Add(lb_Player4);
            playerLabels.Add(lb_Player5);
            playerLabels.Add(lb_Player6);
            playerLabels.Add(lb_Player7);

            // Hide all of the buttons except the start draft button to start
            btn_NextPick.Hide();
            btn_NextPack.Hide();
            btn_FinishDraft.Hide();
        }

        private void Draft_Visual_Load(object sender, EventArgs e)
        {

        }


        private void lb_Player2_Click(object sender, EventArgs e)
        {

        }

        private void lb_Player7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pic_Player0_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lb_Player6_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePlayers()
        {
            // Change the player names and images
            for (int i = 0; i < playerLabels.Count; ++i)
            {
                playerLabels[i].Text = draft.allPlayers[i].name;

                if(draft.allPlayers[i].lastPicked != null)
                    playerImages[i].Image = draft.allPlayers[i].lastPicked.image;
            }

           
        }

        private void UpdateDraftLabels()
        {
            lb_PickCount.Text = $"Pick: {draft.pick}";
            lb_RoundCount.Text = $"Round: {draft.round}";
        }

        private void btn_StartDraft_Click(object sender, EventArgs e)
        {
            draft.startDraft();
            UpdateDraftLabels();
            UpdatePlayers();

            // Show all the buttons
            btn_NextPick.Show();
            btn_NextPack.Show();
            btn_FinishDraft.Show();
        }

        private void btn_NextPick_Click(object sender, EventArgs e)
        {
            draft.nextPick();
            UpdateDraftLabels();
            UpdatePlayers();
        }

        private void btn_NextPack_Click(object sender, EventArgs e)
        {
            draft.finishPack();
            UpdateDraftLabels();
            UpdatePlayers();
        }

        private void btn_FinishDraft_Click(object sender, EventArgs e)
        {
            draft.finishDraft();
            UpdateDraftLabels();
            UpdatePlayers();
        }

        private void btn_ShowCards0_Click(object sender, EventArgs e)
        {

        }

        private void btn_ShowCards1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ShowCards2_Click(object sender, EventArgs e)
        {

        }
    }
}