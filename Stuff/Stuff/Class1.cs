using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
namespace Stuff
{
    public sealed class Class1 :IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            SendToast("Hi this is background");
            
        }
        public static void SendToast(string message)
        {
            var template = ToastTemplateType.ToastImageAndText01;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var element = xml.GetElementsByTagName("Test");
            var Text = xml.CreateTextNode(message);

            element[0].AppendChild(Text);
            var toast = new ToastNotification(xml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
