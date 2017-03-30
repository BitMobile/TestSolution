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

			_scrollView.AddChild(vl);
			_scrollView.AddChild(vl2);
			_scrollView.AddChild(vl3);
			AddChild(_scrollView);
		}

		private static void GetPushOnClick(object sender, EventArgs e)
		{
			try
			{
				LocalNotification.Notify("Test this push!", "JUST GO TO layout screen");
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc);
				throw;
			}
		}

		private static void YandexScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("YandexScreen");
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
			BusinessProcess.DoAction("ButtonScreen");
		}

		private static void CheckBoxScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("CheckBoxScreen");
		}

		private static void SomeControlsScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("SomeControlsScreen");
		}

		private static void LayoutScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("LayoutScreen");
		}

		private static void ImageScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("ImageScreen");
		}

		private static void EditTextScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("EditTextScreen");
		}

		private static void MemoEditScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("MemoEditScreen");
		}

		private static void IndicatorScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("IndicatorScreen");
		}

		private static void MediaPlayerScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("MediaPlayerScreen");
		}

		private static void ExitButton_OnClick(object sender, EventArgs e)
		{
			Application.Terminate();
		}

		private static void TestXMLScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("TestXMLScreen");
		}

		private static void WebScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("WebScreen");
		}

		private static void SwipeScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("SwipeScreen");
		}

		private static void DatabaseScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("DatabaseScreen");
		}

		private static void DialogScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("DialogScreen");
		}

		private static void CameraPhoneGps_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("CameraPhoneGpsScreen");
		}

		private static void FileSystemScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("FileSystemScreen");
		}

		private static void ComponentScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("ComponentScreen");
		}

		private static void TestBugsScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("TestBugsScreen");
		}

		private static void ApplicationScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("ApplicationScreen");
		}

		private static void PushScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("PushScreen");
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
			BusinessProcess.DoAction("SecondButtonScreen");
		}
	}
}