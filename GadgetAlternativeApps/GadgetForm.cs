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

            this.Location = new Point(posX, posY);
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

        private void GadgetForm_Load(object sender, EventArgs e)
        {
            gadgetDisplay.Navigate(GadgetManager.getGadgetInfoAt(_index).htmlPath);
        }

        private void gadgetDisplay_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (isHorizontalScroll)
            {
                gadgetDisplay.Size = new Size(gadgetDisplay.Document.Body.ScrollRectangle.Width, gadgetDisplay.Document.Body.ScrollRectangle.Height);
                ActiveForm.Size = new Size(gadgetDisplay.Document.Body.ScrollRectangle.Width, gadgetDisplay.Document.Body.ScrollRectangle.Height);
            }
        }

        private bool isHorizontalScroll
        {
            get
            {
                var widthofScrollableArea = gadgetDisplay.Document.Body.ScrollRectangle.Width;
                var widthofControl = gadgetDisplay.Document.Window.Size.Width;

                return widthofScrollableArea > widthofControl;
            }
        }
    }
}
