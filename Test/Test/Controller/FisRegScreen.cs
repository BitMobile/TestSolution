using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using ClientModel3.MD;

namespace Test
{
	public class FisRegScreen : Screen
	{
		public override void OnLoading()
		{
			try
			{
				base.OnLoading();
				DConsole.WriteLine($"GetDate: {FiscalRegistrator.GetProviderInstance().GetDate()}");
				DConsole.WriteLine($"GetTime: {FiscalRegistrator.GetProviderInstance().GetTime()}");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error in action: FocusScreen.OnLoading\n" +
								$"Exception: {exc}");
			}
		}
	}
}