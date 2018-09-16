using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Background;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackGroundStuff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void button_click(object sender, RoutedEventArgs e)
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();
            switch (access)
            {
                case BackgroundAccessStatus.Unspecified:
                    break;
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.Denied:
                    break;
                default:
                    break;

            }
            var task = new BackgroundTaskBuilder
            {
                Name="My Task",
                TaskEntryPoint=typeof(Stuff.Class1).ToString()

            };
            var trigger = new ApplicationTrigger();
            task.SetTrigger(trigger);
            var condition = new SystemCondition(SystemConditionType.InternetAvailable);
            task.Register();
            await trigger.RequestAsync();
        }
    }
}
