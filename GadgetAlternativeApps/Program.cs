using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GadgetAlternativeApps
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GadgetManager.Init();
            initNotifyIcon();

            Application.Run();
        }

        private static void initNotifyIcon()
        {
            ContextMenu ctxMenu = new ContextMenu();
            MenuItem openItem = new MenuItem("Open Gadget Manager", new EventHandler(openGadgetManagerForm_Event));
            MenuItem exitItem = new MenuItem("Exit", new EventHandler(exitApplication_Event));
            ctxMenu.MenuItems.Add(openItem);
            ctxMenu.MenuItems.Add(exitItem);

            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("Icon.ico");
            notifyIcon.Text = "Gadget Manager";
            notifyIcon.DoubleClick += new EventHandler(openGadgetManagerForm_Event);
            notifyIcon.ContextMenu = ctxMenu;
            notifyIcon.Visible = true;
        }
        private static void openGadgetManagerForm_Event(object Sender, EventArgs e)
        {
            GadgetManagerForm gadgetMgr = new GadgetManagerForm();
            gadgetMgr.Show();
        }
        private static void exitApplication_Event(object Sender, EventArgs e)
        {
            GadgetManager.Close();
            Application.Exit();
        }
    }
}
