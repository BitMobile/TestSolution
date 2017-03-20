using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using ClientModel3.MD;

namespace Test
{

    public class Solution : Application
    {
        private readonly Thread thread = new Thread();

        public override void OnCreate()
        {
            BusinessProcess.Init();
            DConsole.WriteLine(Translator.Translate("greeting"));
            //try
            //{
            //    PushNotification.InitializePushService("http://10.5.195.222/bitmobile/synchro3",
            //        "15f3904b-942b-11e5-bb64-f8a963e4bf15", "Sr");
            //}
            //catch (Exception)
            //{
            //    DConsole.WriteLine("SOME EXCEPTION");
            //}
        }

        public override void OnPushMessage(string message)
        {
            LocalNotification.Notify($"NEW MESSAGE = {message}", $"NEW MESSAGE = {message}");
            Toast.MakeToast($"NEW MESSAGE = {message}");
            DConsole.WriteLine($"NEW MESSAGE = {message}");

            //Camera.MakeSnapshot("//private//testPrivate.jpg", 820, DconsoleWriteLine);
        }
        private void DconsoleWriteLine(object sender, ResultEventArgs<bool> args)
        {
            DConsole.WriteLine(args.Result.ToString());
        }
        public override void OnShake()
        {
            
            DConsole.WriteLine("on shake");
        }

        public override void OnRestore()
        {
            DConsole.WriteLine("on restore");
        }

        public override void OnBackground()
        {
            DConsole.WriteLine("on background");
        }
    }
}