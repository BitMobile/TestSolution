using System;
using BitMobile.ClientModel3;
using ClientModel3.MD;

namespace Test
{
	public class Solution : Application
	{
		private readonly Thread thread = new Thread();

		public override void OnCreate()
		{
			BusinessProcess.Init();
			DConsole.WriteLine(Translator.Translate("greeting"));
			try
			{
				OnPushMessage(Translator.Translate("greeting"), Translator.Translate("test"));
			}
			catch (Exception)
			{
				DConsole.WriteLine("SOME EXCEPTION");
				OnPushMessage("nope", "nope");
			}
		}

		public override void OnPushMessage(string message, string additionalInfo)
		{
			try
			{
				base.OnPushMessage(message, additionalInfo);
				LocalNotification.Notify($"NEW MESSAGE = {message}", $"NEW INFO = {additionalInfo}");
				Toast.MakeToast($"NEW MESSAGE = {message}");
				DConsole.WriteLine($"NEW MESSAGE = {message}");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error on push msg: {exc}");
			}
		}

		private void DconsoleWriteLine(object sender, ResultEventArgs<bool> args)
		{
			DConsole.WriteLine(args.Result.ToString());
		}
		public override void OnShake()
		{
			DConsole.WriteLine("on shake");
		}

		public override void OnRestore()
		{
			DConsole.WriteLine("on restore");
		}

		public override void OnBackground()
		{
			DConsole.WriteLine("on background");
		}
	}
}