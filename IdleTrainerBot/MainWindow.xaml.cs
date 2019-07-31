using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IdleTrainerBot.Functions;

namespace IdleTrainerBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.GLOBAL_PROC_NAME = WindowCapture.GetProccessName();
        }

        private void TakeScreen_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.GLOBAL_PROC_NAME = WindowCapture.GetProccessName();
            Bitmap BMP = WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);
            BMP.Save("ScreenCap.bmp", ImageFormat.Bmp);
        }

        private void CheckSize_Click(object sender, RoutedEventArgs e)
        {
            System.Drawing.Size ProcSize = WindowCapture.GetProcessSize(GlobalVariables.GLOBAL_PROC_NAME);

            //if (ProcSize != new Size(544, 994))
            //{
            //    MessageBox.Show("Wrong Resoloution Selected, Bot Stopped. \nGo To NOX >> SETTINGS >> ADVANCED SETTINGS >> 540x960 >> Restore Window Settings \n Start Bot Once Window Size Restored");
            //}
            //else
            //{
            //    MessageBox.Show("Valid Size");
            //}
            
            MessageBox.Show(ProcSize.ToString());
        }

        private void MailCheck_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlayerInfo.CheckMenu();
        }
    }
}
