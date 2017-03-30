using System;
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

				var verticalLayout = new VerticalLayout
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
				editTextAutoFocusTrue.OnLostFocus += EditTextOnLostFocus;

				var editTextAutoFocusFalse = new EditText
				{
					Visible = true,
					CssClass = "EditText",
					Placeholder = "auto focus is disabled",
					AutoFocus = false
				};
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

				verticalLayout.AddChild(editTextAutoFocusTrue);
				verticalLayout.AddChild(editTextAutoFocusFalse);
				verticalLayout.AddChild(backButton);

				AddChild(verticalLayout);
			}
			catch (Exception exc)
			{
				Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.OnLoading\n" +
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
				Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.Back\n" +
								$"Exception: {exc}");
			}
		}

		private static void EditTextOnLostFocus(object sender, EventArgs e)
		{
			try
			{
				Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> lost focus!");
			}
			catch (Exception exc)
			{
				Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.EditTextOnLostFocus\n" +
								$"Exception: {exc}");
			}
		}
	}
}