using System.IO;
using System.Xml;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using XmlDocument = BitMobile.ClientModel3.XmlDocument;
using System;

namespace Test
{
	public class BusinessProcess
	{
		private static XmlDocument doc;
		private static readonly Stack stackNodes = new Stack();
		private static readonly Stack stackScreens = new Stack();

		public static void Init()
		{
			doc = new XmlDocument();
			doc.Load(Application.GetResourceStream("BusinessProcess.BusinessProcess.xml"));

			var firstStepName = doc.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["Name"].Value;
			MoveTo(firstStepName);
		}

		public static void MoveTo(string stepName)
		{
			var n = doc.DocumentElement?.SelectSingleNode($"//BusinessProcess/Workflow/Step[@Name='{stepName}']");
			if (n?.Attributes == null) return;
			var stepController = n.Attributes["Controller"].Value;
			var styleSheet = n.Attributes["StyleSheet"].Value;

			var scr = (Screen)Application.CreateInstance("Test." + stepController);

			stackScreens.Push(scr);
			stackNodes.Push(n);

			scr.LoadStyleSheet(Application.GetResourceStream(styleSheet));
			scr.Show();
		}
	}
}