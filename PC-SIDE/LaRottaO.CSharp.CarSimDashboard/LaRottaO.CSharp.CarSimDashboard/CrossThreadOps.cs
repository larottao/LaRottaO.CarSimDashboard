using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaRottaO.CSharp.CarSimDashboard
{
    public static class CrossThreadOps
    {
        public static void setControlEnabled(Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                // Use Invoke to marshal the call to the UI thread
                control.Invoke(new Action(() => setControlEnabled(control, enabled)));
            }
            else
            {
                // Set the control's enabled state
                control.Enabled = enabled;
            }
        }

        public static void SetControlText(Control control, String text)
        {
            if (control.InvokeRequired)
            {
                // Use Invoke to marshal the call to the UI thread
                control.Invoke(new Action(() => SetControlText(control, text)));
            }
            else
            {
                // Set the control's enabled state
                control.Text = text;
            }
        }
    }
}