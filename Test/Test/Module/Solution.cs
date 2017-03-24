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
			try
			{
				base.OnCreate();
				BusinessProcess.Init();
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error on create: {exc}");
			}
		}

		public override void OnPushMessage(string message, string additionalInfo)
		{
			try
			{
				base.OnPushMessage(message, additionalInfo);
				LocalNotification.Notify($"msg = {message}", $"info = {additionalInfo}");
				Toast.MakeToast($"msg = {message}");
				DConsole.WriteLine($"msg = {message}");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error on push msg: {exc}");
			}
		}

		public override void OnShake()
		{
			base.OnShake();
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> shake");
		}

		public override void OnRestore()
		{
			base.OnRestore();
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> restore");
		}

		public override void OnBackground()
		{
			base.OnBackground();
			DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> background");
		}

		//public override void OnLocalNotificationClicked(string message)
		//{
		//	base.OnLocalNotificationClicked(message);
		//	DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> click notification");
		//}
	}
}