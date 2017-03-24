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

		private static void MoveTo(string stepName)
		{
			if (doc.DocumentElement == null) return;

			var n = doc.DocumentElement.SelectSingleNode($"//BusinessProcess/Workflow/Step[@Name='{stepName}']");
			var stepController = n.Attributes["Controller"].Value;
			var styleSheet = n.Attributes["StyleSheet"].Value;

			var scr = GetScreenByControllerName(stepController);

			stackScreens.Push(scr);
			stackNodes.Push(n);

			scr.LoadStyleSheet(Application.GetResourceStream(styleSheet));
			scr.Show();
		}

		public static void DoAction(string actionName)
		{
			var currentNode = (XmlNode)stackNodes.Peek();
			var n = currentNode.SelectSingleNode(string.Format("Action[@Name='{0}']", actionName));
			var stepName = n.Attributes["NextStep"].Value;
			MoveTo(stepName);
		}

		public static void DoBack()
		{
			try
			{
				stackNodes.Pop();
				stackScreens.Pop();

				var scr = (Screen)stackScreens.Peek();
				scr.Show();
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"[{DateTime.Now:HH:mm:ss}] -> error while go back...\n{exc}");
			}
		}

		private static Screen GetScreenByControllerName(string name)
		{
			Screen scr = (Screen)Application.CreateInstance("Test." + name);
			Stream s = null;
			var path = string.Format(@"Screen\{0}.xml", name);
			try
			{
				s = Application.GetResourceStream(path);
			}
			catch
			{
				DConsole.WriteLine(string.Format("Resource {0} has not been found", path));
			}

			if (s != null)
			{
				scr.LoadFromStream(s);
			}

			return scr;
		}
	}
}