using System;
using System.Reflection;
using System.Windows.Forms;

namespace Local.UIClass
{
    class DoubleBufferControl
    {
        /// <summary>
        /// DoubleBuffer Control
        /// </summary>
        /// <param name="oControl">Control</param>
        /// <param name="bOption">true = Buffer</param>
        public static void Buffer(object oControl, bool bOption)
        {
            Type typeControl = oControl.GetType();

            PropertyInfo pi = typeControl.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            pi.SetValue(oControl, bOption, null);
        }
    }
}
