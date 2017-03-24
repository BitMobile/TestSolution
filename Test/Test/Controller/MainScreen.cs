using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using ClientModel3.MD;

namespace Test
{
	public class MainScreen : Screen
	{
		public override void OnLoading()
		{
			try
			{
				base.OnLoading();
				var verticalLayout = new VerticalLayout();

				var notificationButton = new Button
				{
					Id = "tstBtn01",
					CssClass = "CssButton",
					Text = "Test Push"
				};
				notificationButton.OnClick += NotificationButtonOnClick;

				verticalLayout.AddChild(notificationButton);

				AddChild(verticalLayout);
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error on loading main screen\n{exc}");
			}
		}

		public override void OnShow()
		{
			try
			{
				base.OnShow();
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error on show main screen\n{exc}");
			}
		}

		private static void NotificationButtonOnClick(object sender, EventArgs eventArgs)
		{
			try
			{
				LocalNotification.Notify($"msg = {Translator.Translate("hello")}", $"info = {Translator.Translate("world")}");
				Toast.MakeToast($"msg = {Translator.Translate("hello")} {Translator.Translate("world")}");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error on push msg:\n{exc}");
			}
		}
	}
}