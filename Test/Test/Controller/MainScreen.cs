using System;
using System.Diagnostics;
using System.Text;
using System.Net;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class MainScreen : Screen
    {
        public override void OnLoading()
        {
            initialize();
        }

        private void initialize()
        {
            var vl = new VerticalLayout();
            vl.AddChild(new Button("Buttons", ButtonScreen_OnClick));
            vl.AddChild(new Button("CheckBox", CheckBoxScreen_OnClick));
            vl.AddChild(new Button("SomeControls", SomeControlsScreen_OnClick));
            vl.AddChild(new Button("VerticalLayout", VerticalLayoutScreen_OnClick));
            vl.AddChild(new Button("HorizontalLayout", HorizontalLayoutScreen_OnClick));
            vl.AddChild(new Button("Image", ImageScreen_OnClick));
            vl.AddChild(new Button("Make Yandex Photos", YandexScreen_OnClick));
            vl.AddChild(new Button("Web Request", MakeWebRequest_OnClick));
            vl.AddChild(new Button("Exit", ExitButton_OnClick));
            AddChild(vl);
        }
        void YandexScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("YandexScreen");
        }
        void MakeWebRequest_OnClick(object sender, EventArgs e)
        {

            WebRequest req = WebRequest.Create("http://bitmobile1.bt/bitmobileX/platform/device/GetClientMetadata");
            DConsole.WriteLine(String.Format("Web Request Created"));
            string svcCredentials =
                Convert.ToBase64String(Encoding.ASCII.GetBytes("fm" + ":" + "fm"));
            req.Headers.Add("Authorization", "Basic " + svcCredentials);

            DConsole.WriteLine(String.Format("Headers added"));

            using (WebResponse resp = req.GetResponse()) { }

            DConsole.WriteLine(String.Format("The response is received"));


        }     
        void ButtonScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("ButtonScreen");
        }
        void CheckBoxScreen_OnClick (object sender, EventArgs e)
        {
            BusinessProcess.DoAction("CheckBoxScreen");
        }
        void SomeControlsScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SomeControlsScreen");
        }
        void VerticalLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("VerticalLayoutScreen");
        }
        void HorizontalLayoutScreen_OnClick (object sender, EventArgs e)
        {
           BusinessProcess.DoAction("HorizontalLayoutScreen");
        }
        void ImageScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("ImageScreen");
        }
        void ExitButton_OnClick(object sender, EventArgs e)
        {

            Application.Terminate();

        }       
    }
}
