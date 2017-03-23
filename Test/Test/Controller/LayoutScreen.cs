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

			var buttonWithAllEvent = new Button
			{
				Enabled = true,
				Id = "myBtn01",
				Visible = true,
				Text = "buttonWithAllEvent"
			};
			buttonWithAllEvent.OnClick += ButtonOnClick;
			buttonWithAllEvent.OnPressDown += ButtonOnPressDown;
			buttonWithAllEvent.OnPressUp += ButtonOnPressUp;

			var buttonWithAllPress = new Button
			{
				Enabled = true,
				Id = "myBtn02",
				Visible = true,
				Text = "buttonWithAllPress"
			};
			buttonWithAllPress.OnPressDown += ButtonOnPressDown;
			buttonWithAllPress.OnPressUp += ButtonOnPressUp;

			var buttonWithPressDown = new Button
			{
				Enabled = true,
				Id = "myBtn03",
				Visible = true,
				Text = "buttonWithPressDown"
			};
			buttonWithPressDown.OnPressDown += ButtonOnPressDown;

			var buttonWithPressUp = new Button
			{
				Enabled = true,
				Id = "myBtn04",
				Visible = true,
				Text = "buttonWithPressUp"
			};
			buttonWithPressUp.OnPressUp += ButtonOnPressUp;

			vl.AddChild(new Button("VerticalLayout", VerticalLayoutScreen_OnClick));
			vl.AddChild(new Button("HorizontalLayout", HorizontalLayoutScreen_OnClick));
			vl.AddChild(new Button("TestHorizontalLayoutScreen", TestHorizontalLayoutScreen_OnClick));
			vl.AddChild(new Button("DockLayout", DockLayoutScreen_OnClick));

			vl.AddChild(buttonWithAllEvent);
			vl.AddChild(buttonWithAllPress);
			vl.AddChild(buttonWithPressDown);
			vl.AddChild(buttonWithPressUp);

			vl.AddChild(new Button("Back", Back_OnClick));
		}

		private static void ButtonOnPressDown(object sender, EventArgs e)
		{
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss.ms}] -> press down btn");
		}

		private static void ButtonOnPressUp(object sender, EventArgs e)
		{
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss.ms}] -> press up btn");
		}

		private static void ButtonOnClick(object sender, EventArgs e)
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