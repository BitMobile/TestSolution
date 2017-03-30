using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class DialogScreen : Screen
	{
		public override void OnLoading()
		{
			Initialize();
		}

		private void Initialize()
		{
			var vl = new VerticalLayout();
			AddChild(vl);

			vl.AddChild(new Button("Test Dialog.Message Success", AddNewDialog_OnClick));
			vl.AddChild(new Button("Test Dialog", Dialog_OnClick));

			vl.AddChild(new Button("Back", Back_OnClick));
		}

		private void Back_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.MoveTo("MainScreen");
		}

		private void AddNewDialog_OnClick(object sender, EventArgs e)
		{
			Dialog.Message("Success");

		}

		private void Dialog_OnClick(object sender, EventArgs e)
		{
			Dialog.Alert("Test", Alert_Handler, null, "ok");
		}

		private void Alert_Handler(object sender, ResultEventArgs<int> args)
		{
			DConsole.WriteLine(args.Result.ToString());
			Dialog.Ask("Are you ok ?", Ask_Handler);
		}

		private void Ask_Handler(object sender, ResultEventArgs<Dialog.Result> args)
		{
			if (args.Result == Dialog.Result.Yes)
			{
				Console.WriteLine("That's good");
				Dialog.DateTime("What time is is ?", DateTime_Handler);
			}
			else if (args.Result == Dialog.Result.No)
			{
				Console.WriteLine("That's bad");
				Dialog.DateTime("What time is is ?", DateTime_Handler);
			}
		}

		private void DateTime_Handler(object sender, ResultEventArgs<DateTime> args)
		{
			DConsole.WriteLine(args.Result.ToShortTimeString());
		}
	}
}