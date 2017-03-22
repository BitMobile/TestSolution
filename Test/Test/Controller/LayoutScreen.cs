using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class LayoutScreen : Screen
	{
		private Button _textButton;

		public override void OnLoading()
		{
			Initialize();
		}

		private void Initialize()
		{
			var vl = new VerticalLayout();
			AddChild(vl);

			_textButton = new Button {Text = "TextButton" };
			_textButton.OnClick += TestButton_OnClick;
			_textButton.OnPressDown += TestButton_OnPressDown;
			_textButton.OnPressUp += TestButton_OnPressUp;

			vl.AddChild(new Button("VerticalLayout", VerticalLayoutScreen_OnClick));
			vl.AddChild(new Button("HorizontalLayout", HorizontalLayoutScreen_OnClick));
			vl.AddChild(new Button("TestHorizontalLayoutScreen", TestHorizontalLayoutScreen_OnClick));
			vl.AddChild(new Button("DockLayout", DockLayoutScreen_OnClick));

			vl.AddChild(_textButton);

			vl.AddChild(new Button("Back", Back_OnClick));
		}

		private static void TestButton_OnPressDown(object sender, EventArgs e)
		{
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss.ms}] -> press down btn");
		}

		private static void TestButton_OnPressUp(object sender, EventArgs e)
		{
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss.ms}] -> press up btn");
		}

		private static void TestButton_OnClick(object sender, EventArgs e)
		{
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss.ms}] -> click on btn");
		}

		private static void Back_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoBack();
		}

		private static void VerticalLayoutScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("VerticalLayoutScreen");
		}

		private static void HorizontalLayoutScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("HorizontalLayoutScreen");
		}

		private static void TestHorizontalLayoutScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("TestHorizontalLayoutScreen");
		}

		private static void DockLayoutScreen_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("DockLayoutScreen");
		}
	}
}