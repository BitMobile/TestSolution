using System;
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
        void ExitButton_OnClick(object sender, EventArgs e)
        {
            Application.Terminate();
        }
        void ButtonScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("ButtonScreen");
        }

        private void initialize ()
        {
            var vl = new VerticalLayout();
            vl.AddChild(new Button("Test Buttons", ButtonScreen_OnClick));
            vl.AddChild(new Button("Make Yandex Photos", YandexScreen_OnClick));
            vl.AddChild(new Button("Web Request", MakeWebRequest_OnClick));
            vl.AddChild(new Button("Exit", ExitButton_OnClick));
            AddChild(vl);
        }
    }
}
