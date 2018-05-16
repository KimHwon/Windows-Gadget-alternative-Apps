using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GadgetAlternativeApps
{
    public partial class GadgetForm : Form
    {
        private int _index;

        public GadgetForm(int index, int posX, int posY)
        {
            InitializeComponent();

            Location = new Point(posX, posY);
            _index = index;
        }
        ~GadgetForm()
        {
            GadgetManager.setGadgetActivationAt(_index, false);
        }

        private void GadgetForm_LocationChanged(object sender, EventArgs e)
        {
            GadgetManager.setGadgetPositionAt(_index, Location.X, Location.Y);
        }
    }
}
