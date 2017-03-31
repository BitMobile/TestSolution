using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using ClientModel3.MD;

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
			var vl3 = new VerticalLayout();
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
			vl2.AddChild(new Button("Test Bugs", TestBugsScreen_OnClick));
			vl2.AddChild(new Button("Exit", ExitButton_OnClick));
			vl3.AddChild(new Button("Application", ApplicationScreen_OnClick));
			vl3.AddChild(new Button("Push", PushScreen_OnClick));

			vl3.AddChild(new Button("TaV TEST", SecondButtonScreenOnClick));

			var tPush = new Button
			{
				Visible = true,
				Text = "Test push",
				Id = "MyTestPushButton",
				CssClass = "CssButton",
				Enabled = true
			};
			tPush.OnClick += GetPushOnClick;

			vl3.AddChild(tPush);

			var focusScreen = new Button
			{
				Visible = true,
				Text = "Test focus",
				Id = "MyTestFocusTestButton",
				CssClass = "CssButton",
				Enabled = true
			};
			focusScreen.OnClick += OpenFocusScreen;
			vl3.AddChild(focusScreen);

			vl3.AddChild(new Button("Test FisReg", OpenFisRegScreen));

			_scrollView.AddChild(vl);
			_scrollView.AddChild(vl2);
			_scrollView.AddChild(vl3);
			AddChild(_scrollView);
		}

		private static void OpenFisRegScreen(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("FisRegScreen");
		}

		private static void OpenFocusScreen(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("FocusScreen");
		}

		private static void GetPushOnClick(object sender, EventArgs e)
		{
			try
			{
				LocalNotification.Notify("Test this push!", "JUST GO TO focus screen", "FocusScreen");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"{exc}");
				throw;
			}
		}

		private static void YandexScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("YandexScreen");
		}

		private static void MakeWebRequest_OnClick(object sender, EventArgs e)
		{
			//var req = Web.Request();
			//req.Host = "http://bitmobile1.bt/";
			//req.UserName = "sr";
			//req.Password = "sr";
			//req.Timeout = "00:02:00";
			//req.Get("http://bitmobile1.bt/bitmobile/superagent/device/GetUserId");
			//DConsole.WriteLine("Authorization OK!");

			var request = new WebRequest();
			//request.Host = "http://10.5.195.222/";
			request.Host = "http://10.5.195.232/";
			request.UserName = "Ivan";
			request.Password = "2502";
			request.Timeout = "00:01:00";
			//request.Get("http://10.5.195.222/bitmobile/synchro3/device/GetUserId", test);
			request.Get("http://10.5.195.232/bitmobile/testsolution/device/GetUserId", test);


			//var req = WebRequest.Create("http://bitmobile1.bt/bitmobileX/platform/device/GetClientMetadata");
			//DConsole.WriteLine("Web Request Created");
			//var svcCredentials =
			//    Convert.ToBase64String(Encoding.ASCII.GetBytes("sr" + ":" + "sr"));
			//req.Headers.Add("Authorization", "Basic " + svcCredentials);
			//DConsole.WriteLine("Headers added");
			//using (var resp = req.GetResponse())
			//{
			//}
			//DConsole.WriteLine("The response is received");
		}

		private static void test(object sender, ResultEventArgs<WebRequest.WebRequestResult> e)
		{
			DConsole.WriteLine("START");
			if (!e.Result.Success)
			{
				DConsole.WriteLine(e.Result.Error.StatusCode.ToString());
				DConsole.WriteLine(e.Result.Error.Name);
				DConsole.WriteLine(e.Result.Error.Message);
			}
			else
			{
				DConsole.WriteLine(e.Result.Result);
			}
			DConsole.WriteLine("END");
		}

		private static void ButtonScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("ButtonScreen");
		}

		private static void CheckBoxScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("CheckBoxScreen");
		}

		private static void SomeControlsScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("SomeControlsScreen");
		}

		private static void LayoutScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("LayoutScreen");
		}

		private static void ImageScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("ImageScreen");
		}

		private static void EditTextScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("EditTextScreen");
		}

		private static void MemoEditScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("MemoEditScreen");
		}

		private static void IndicatorScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("IndicatorScreen");
		}

		private static void MediaPlayerScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("MediaPlayerScreen");
		}

		private static void ExitButton_OnClick(object sender, EventArgs e)
		{
			Application.Terminate();
		}

		private static void TestXMLScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("TestXMLScreen");
		}

		private static void WebScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("WebScreen");
		}

		private static void SwipeScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("SwipeScreen");
		}

		private static void DatabaseScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("DatabaseScreen");
		}

		private static void DialogScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("DialogScreen");
		}

		private static void CameraPhoneGps_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("CameraPhoneGpsScreen");
		}

		private static void FileSystemScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("FileSystemScreen");
		}

		private static void ComponentScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("ComponentScreen");
		}

		private static void TestBugsScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("TestBugsScreen");
		}

		private static void ApplicationScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("ApplicationScreen");
		}

		private static void PushScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("PushScreen");
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

		private static void SecondButtonScreenOnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("SecondButtonScreen");
		}
	}
}