using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class SecondButtonScreen : Screen
	{
		private VerticalLayout _verticalLayout1;
		private VerticalLayout _verticalLayout2;
		private static EditText _cssEditText;
		private static EditText _invisibeEditText;
		private EditText _notEnabledEditText;
		private static EditText _placeholderEditText;
		private static EditText _textEditText;
		private static ScrollView _scrollView;
		private static ProgressBar progressBar;

		public override void OnLoading()
		{
			_verticalLayout1 = new VerticalLayout();

			progressBar = new ProgressBar
			{
				Id = "pb",
				CssClass = "Progress"
			};
			_verticalLayout1.AddChild(progressBar);

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
				progressBar.Start();
				progressBar.Max = 100;
				progressBar.Progress += 1;
				DConsole.WriteLine("start PB...");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error run progress bar\n{exc}");
			}
		}
	}
}