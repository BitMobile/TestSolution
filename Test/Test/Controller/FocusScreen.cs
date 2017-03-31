using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class FocusScreen : Screen
	{
		public override void OnLoading()
		{
			try
			{
				base.OnLoading();

				var scroll = new ScrollView();
				var vl1 = new VerticalLayout
				{
					Visible = true,
					Id = "MyVerticalLayoutOnFocusScreen",
					CssClass = "vl"
				};

				var editTextAutoFocusTrue = new EditText
				{
					Visible = true,
					CssClass = "EditText",
					Placeholder = "auto focus is enabled",
					AutoFocus = true
				};
				editTextAutoFocusTrue.OnGetFocus += EditTextOnGetFocus;
				editTextAutoFocusTrue.OnLostFocus += EditTextOnLostFocus;

				var editTextAutoFocusFalse = new EditText
				{
					Visible = true,
					CssClass = "EditText",
					Placeholder = "auto focus is disabled",
					AutoFocus = false
				};
				editTextAutoFocusFalse.OnGetFocus += EditTextOnGetFocus;
				editTextAutoFocusFalse.OnLostFocus += EditTextOnLostFocus;

				var backButton = new Button
				{
					Visible = true,
					CssClass = "CssButton",
					Id = "MyBackButtonOnFocusScreen",
					Text = "Back",
					Enabled = true
				};
				backButton.OnClick += Back;

				vl1.AddChild(editTextAutoFocusTrue);
				vl1.AddChild(editTextAutoFocusFalse);
				vl1.AddChild(backButton);

				scroll.AddChild(vl1);
				AddChild(scroll);
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.OnLoading\n" +
								$"Exception: {exc}");
			}
		}

		public override void OnShow()
		{
			try
			{
				base.OnShow();
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> FocusScreen.OnShow");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.OnShow\n" +
								$"Exception: {exc}");
			}
		}

		private static void Back(object sender, EventArgs e)
		{
			try
			{
				BusinessProcess.MoveTo("MainScreen");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.Back\n" +
								$"Exception: {exc}");
			}
		}

		private static void EditTextOnGetFocus(object sender, EventArgs e)
		{
			try
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> get focus!");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.EditTextOnLostFocus\n" +
								$"Exception: {exc}");
			}
		}

		private static void EditTextOnLostFocus(object sender, EventArgs e)
		{
			try
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> lost focus!");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.EditTextOnLostFocus\n" +
								$"Exception: {exc}");
			}
		}
	}
}