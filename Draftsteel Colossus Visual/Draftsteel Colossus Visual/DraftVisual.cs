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
    public partial class Draft_Visual : Form
    {
        private Draft draft;
        public Draft_Visual(Draft _draft)
        {
            draft = _draft;
            InitializeComponent();
        }

        private void Draft_Visual_Load(object sender, EventArgs e)
        {

        }

        private void btn_StartDraft_Click(object sender, EventArgs e)
        {
            draft.playDraft();
        }
    }
}
