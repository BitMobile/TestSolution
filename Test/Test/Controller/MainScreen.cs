﻿using System;
using System.Net;
using System.Text;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class MainScreen : Screen
    {
        private ScrollView _scrollView;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            _scrollView = new ScrollView();
            var vl = new VerticalLayout();
            var vl2 = new VerticalLayout();
            _scrollView.Id = "Id Of ScrollView";
            _scrollView.OnScroll += ScrollIndex_OnScroll;

            vl.AddChild(new Button("Buttons", ButtonScreen_OnClick));
            vl.AddChild(new Button("CheckBox", CheckBoxScreen_OnClick));
            vl.AddChild(new Button("HorizontalLine And TextView", SomeControlsScreen_OnClick));
            vl.AddChild(new Button("Layouts", LayoutScreen_OnClick));
            vl.AddChild(new Button("Image", ImageScreen_OnClick));
            vl.AddChild(new Button("EditText", EditTextScreen_OnClick));
            vl.AddChild(new Button("MemoEdit", MemoEditScreen_OnClick));
            vl.AddChild(new Button("Indicator", IndicatorScreen_OnClick));
            vl.AddChild(new Button("Media Player", MediaPlayerScreen_OnClick));
            vl.AddChild(new Button("Make Yandex Photos", YandexScreen_OnClick));
            vl.AddChild(new Button("Web Request", MakeWebRequest_OnClick));
            vl.AddChild(new Button("Exit", ExitButton_OnClick));

            vl2.AddChild(new Button("Test XML Screen", TestXMLScreen_OnClick));
            vl2.AddChild(new Button("Web", WebScreen_OnClick));
            vl2.AddChild(new Button("Swipe", SwipeScreen_OnClick));
            vl2.AddChild(new Button("Database", DatabaseScreen_OnClick));
            vl2.AddChild(new Button("Dialog", DialogScreen_OnClick));
            vl2.AddChild(new Button("CameraPhoneGpsClipboard", CameraPhoneGps_OnClick));
            vl2.AddChild(new Button("FileSystemScreen", FileSystemScreen_OnClick));
            vl2.AddChild(new Button("Component Screen", ComponentScreen_OnClick));
            vl2.AddChild(new Button("Scroll To First Layout", ScrollToFirstLayout_OnClick));
            vl2.AddChild(new Button("ID Of ScrollView", IdOfScrollView_OnClick));
            vl2.AddChild(new Button("Exit", ExitButton_OnClick));

            _scrollView.AddChild(vl);
            _scrollView.AddChild(vl2);
            AddChild(_scrollView);
        }


        private void YandexScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("YandexScreen");
        }

        private void MakeWebRequest_OnClick(object sender, EventArgs e)
        {
            var req = WebRequest.Create("http://bitmobile1.bt/bitmobileX/platform/device/GetClientMetadata");
            DConsole.WriteLine("Web Request Created");
            var svcCredentials =
                Convert.ToBase64String(Encoding.ASCII.GetBytes("fm" + ":" + "fm"));
            req.Headers.Add("Authorization", "Basic " + svcCredentials);
            DConsole.WriteLine("Headers added");
            using (var resp = req.GetResponse())
            {
            }
            DConsole.WriteLine("The response is received");
        }

        private void ButtonScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("ButtonScreen");
        }

        private void CheckBoxScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("CheckBoxScreen");
        }

        private void SomeControlsScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SomeControlsScreen");
        }

        private void LayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("LayoutScreen");
        }

        private void ImageScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("ImageScreen");
        }

        private void EditTextScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("EditTextScreen");
        }

        private void MemoEditScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("MemoEditScreen");
        }

        private void IndicatorScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("IndicatorScreen");
        }

        private void MediaPlayerScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("MediaPlayerScreen");
        }

        private void ExitButton_OnClick(object sender, EventArgs e)
        {
            Application.Terminate();
        }

        private void TestXMLScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("TestXMLScreen");
        }

        private void WebScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("WebScreen");
        }

        private void SwipeScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SwipeScreen");
        }

        private void DatabaseScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("DatabaseScreen");
        }

        private void DialogScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("DialogScreen");
        }

        private void CameraPhoneGps_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("CameraPhoneGpsScreen");
        }

        private void FileSystemScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("FileSystemScreen");
        }
        private void ComponentScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("ComponentScreen");
        }

        private void ScrollIndex_OnScroll(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(_scrollView.ScrollIndex.ToString()));
        }

        private void IdOfScrollView_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(_scrollView.Id));
        }

        private void ScrollToFirstLayout_OnClick(object sender, EventArgs e)
        {
            _scrollView.Index = 0;
        }
    }
}