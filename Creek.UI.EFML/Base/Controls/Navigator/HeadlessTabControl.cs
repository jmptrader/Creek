using System;
using System.Windows.Forms;

namespace Creek.UI.EFML.Base.Controls.Navigator
{
    public class HeadlessTabControl : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            // Hide the tab headers at run-time
            if (m.Msg == TCM_ADJUSTRECT && !DesignMode)
            {
                m.Result = (IntPtr) 1;
                return;
            }

            // call the base class implementation
            base.WndProc(ref m);
        }
    }
}