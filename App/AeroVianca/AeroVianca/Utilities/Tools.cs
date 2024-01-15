using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AeroVianca.Utilities
{
    public class Tools(Window pWindow)
    {
        readonly Window window = pWindow;

        public void Minimize() => window.WindowState = WindowState.Minimized;
        public void Closed()   => Application.Current.Shutdown();
        public bool validateTxtBoxPressed(MouseButtonEventArgs e) => e.LeftButton == MouseButtonState.Pressed;
        public void openPage(Window pNewPage) => pNewPage.Show();
        public void MouseDown(MouseButtonEventArgs e)
        {
            if (e.LeftButton.Equals(MouseButtonState.Pressed)) window.DragMove();
        }



        private ToolTip? dynamicToolTip;
        private DispatcherTimer? timer;

        public void AddToolTipButton(Button pButton, string pNotificationText)
        {
            if (dynamicToolTip != null && dynamicToolTip.IsOpen)
            {
                dynamicToolTip.IsOpen = false;
                timer?.Stop();
            }

            dynamicToolTip = new ToolTip
            {
                Content = pNotificationText,
            };

            pButton.ToolTip = dynamicToolTip;
            dynamicToolTip.IsOpen = true;

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            timer.Tick += (s, args) =>
            {
                dynamicToolTip.IsOpen = false;
                timer.Stop();
            };

            timer.Start();
        }

    }
}
