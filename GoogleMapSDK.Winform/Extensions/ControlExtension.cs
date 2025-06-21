using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.Winform.Extensions
{
    internal static class ControlExtension
    {
        private static System.Threading.Timer singletonTimer;

        public static void DebounceHandler(this Control control, Action callback, int debounceTime = 1000)
        {

            if (singletonTimer != null)
            {
                singletonTimer.Change(debounceTime, Timeout.Infinite);
                return;
            }
            control.Tag = callback;

            singletonTimer = new System.Threading.Timer
            (
                HandleDebounce,
                control,
                debounceTime,
                Timeout.Infinite
            );
        }

        private static void HandleDebounce(object sender)
        {
            var control = sender as Control;
            Action action = control.Tag as Action;

            control.Invoke((Action)(() =>
            {
                action.Invoke();
            }));
        }
    }
}
