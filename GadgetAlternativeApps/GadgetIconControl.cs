using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GadgetAlternativeApps
{
    public partial class GadgetIconControl : UserControl
    {
        private int _index;

        public GadgetIconControl(int index, string gadgetName, string gadgetImageSrc)
        {
            InitializeComponent();

            _index = index;

            nameLabel.Text = gadgetName;

            iconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox.ImageLocation = gadgetImageSrc;
        }

        private void iconPictureBox_DoubleClick(object sender, EventArgs e)
        {
            activeGadget();
        }

        private void nameLabel_DoubleClick(object sender, EventArgs e)
        {
            activeGadget();
        }

        private void activeGadget()
        {
            GadgetManager.setGadgetActivationAt(_index, true);
            GadgetManager.updateGadgets();
        }
    }
}
