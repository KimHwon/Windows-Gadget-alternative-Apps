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
    public partial class GadgetManagerForm : Form
    {
        public GadgetManagerForm()
        {
            InitializeComponent();
        }

        private void GadgetManagerForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var gInfo in GadgetManager.getGadgetInfoList())
            {
                GadgetIconControl gIconControl = new GadgetIconControl(i, gInfo.name, gInfo.icon.src);
                gadgetListPanel.Controls.Add(gIconControl);
                i++;
            }
        }

        private void importGadgetLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (gadgetBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (GadgetManager.addGadget(gadgetBrowserDialog.SelectedPath))
                {
                    GadgetInfo gInfo = GadgetManager.getLastGadgetInfo();
                    GadgetIconControl gIconControl = new GadgetIconControl(GadgetManager.getGedgetCount(), gInfo.name, gInfo.icon.src);
                    gadgetListPanel.Controls.Add(gIconControl);
                }
                else
                {
                    MessageBox.Show("Error", "Can't load Gadget");
                }
            }
        }
    }
}
