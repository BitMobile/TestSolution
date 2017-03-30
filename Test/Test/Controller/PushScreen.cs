using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using ClientModel3.MD;

namespace Test
{
    public class PushScreen : Screen
    {
        private readonly Thread thread = new Thread();
        private Image _image;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);
            _image = new Image();
            _image.Source = "Image\\grotem.jpg";
            _image.CssClass = "Image";
            _image.Id = "ID Of Image";

            vl.AddChild(new Button("Push to some devices", PushMessage_OnClick));
            vl.AddChild(new Button("DegReg Push", DeRegPush_OnClick));
            vl.AddChild(new Button("Init Push", InitializePush_OnClick));
            vl.AddChild(new Button("IsInitialized Push", IsInitializedPush_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(_image);
        }


        private void PushMessage_OnClick(object sender, EventArgs e)
        {
            //LocalNotification.Notify("Срочно", "Сделать фото объекта");

            DConsole.WriteLine("Done");
            //thread.Sleep(5000);
            PushNotification.PushMessage("Привет",
                new[]
                {
                    "15f3904b-942b-11e5-bb64-f8a963e4bf15", "8d3e3420-f723-11e5-80fd-902b3416d383",
                    "71e1c804-1387-11e6-b0e4-6c71d97753d2"
                });
            //  Camera.MakeSnapshot("//private//testPrivate.jpg", 820, DconsoleWriteLine);
            //  Toast.MakeToast("Фото сделано успешно");
        }

        private void DconsoleWriteLine(object sender, ResultEventArgs<bool> args)
        {
            DConsole.WriteLine(args.Result.ToString());
        }

        private void DeRegPush_OnClick(object sender, EventArgs e)
        {
            PushNotification.Unregister("http://10.5.195.222/bitmobile/synchro3",
                "15f3904b-942b-11e5-bb64-f8a963e4bf15", "Sr");
        }
 private void InitializePush_OnClick(object sender, EventArgs e)
 {
            try
            {
                PushNotification.InitializePushService("http://10.5.195.222/bitmobile/synchro3",
                    "15f3904b-942b-11e5-bb64-f8a963e4bf15", "Sr");
                DConsole.WriteLine("initialized");
            }
            catch (Exception)
            {
                DConsole.WriteLine("SOME EXCEPTION");
            }
        }
 private void IsInitializedPush_OnClick(object sender, EventArgs e)
 {
     DConsole.WriteLine(PushNotification.IsInitialized.ToString());
 }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }
    }
}