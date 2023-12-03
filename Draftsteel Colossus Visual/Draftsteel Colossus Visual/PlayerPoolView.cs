using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Draftsteel_Colossus;

namespace Draftsteel_Colossus_Visual
{
    public partial class PlayerPoolView : Form
    {

        Player player;

        int width = 150;
        int height = 200;

        int startingY = -400;

        public PlayerPoolView(Player p)
        {
            InitializeComponent();
            player = p;
        }

        private void PlayerPoolView_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < player.pool.Count; ++i)
            {

                if(i % 15 == 0)
                {
                    startingY += 200;
                }

                PictureBox imageControl = new PictureBox();
                imageControl.Width = width;
                imageControl.Height = height;
                imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
                Point point = new Point(width * (i % 15), startingY + height);
                imageControl.Location = point;
                imageControl.Image = player.pool[i].image;
                Controls.Add(imageControl);
            }
        }
    }
}
