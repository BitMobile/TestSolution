using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class SecondButtonScreen : Screen
	{
		private VerticalLayout _verticalLayout1;
		private static ProgressBar _progressBar;

		public override void OnLoading()
		{
			_verticalLayout1 = new VerticalLayout();

			_progressBar = new ProgressBar
			{
				Id = "pb",
				CssClass = "Progress",
				Visible = true
			};
			_verticalLayout1.AddChild(_progressBar);

			var testProgressBar = new Button
			{
				CssClass = "CssButton",
				Text = "Test Progress Bar",
				Id = "tpb",
				Visible = true,
				Enabled = true
			};
			testProgressBar.OnClick += RunProgressBarOnClick;


			_verticalLayout1.AddChild(testProgressBar);

			AddChild(_verticalLayout1);
		}

		private void RunProgressBarOnClick(object sender, EventArgs e)
		{
			try
			{
				_progressBar.Start();
				_progressBar.Percent += 3;
				DConsole.WriteLine("start PB...");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error run progress bar\n{exc}");
			}
		}
	}
}