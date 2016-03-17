using System;

using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class BusinessProcess
    {
        static XmlDocument doc;
        static Stack stackNodes = new Stack();
        static Stack stackScreens = new Stack();

        public static void Init()
        {
            doc = new XmlDocument();
            doc.Load(Application.GetResourceStream("BusinessProcess.BusinessProcess.xml"));

            String firstStepName = doc.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["Name"].Value;
            MoveTo(firstStepName);
        }

        private static void MoveTo(String stepName)
        {
            var n = doc.DocumentElement.SelectSingleNode(String.Format("//BusinessProcess/Workflow/Step[@Name='{0}']", stepName));
            var stepController = n.Attributes["Controller"].Value;
            var styleSheet = n.Attributes["StyleSheet"].Value;

            Screen scr = GetScreenByControllerName(stepController);

            stackScreens.Push(scr);
            stackNodes.Push(n);

            scr.LoadStyleSheet(Application.GetResourceStream(styleSheet));
            scr.Show();
        }

        public static void DoAction(String actionName)
        {
            System.Xml.XmlNode currentNode = (System.Xml.XmlNode)stackNodes.Peek();
            var n = currentNode.SelectSingleNode(String.Format("Action[@Name='{0}']", actionName));
            String stepName = n.Attributes["NextStep"].Value;
            MoveTo(stepName);
        }

        public static void DoBack()
        {
            //remove current
            stackNodes.Pop();
            stackScreens.Pop();

            Screen scr = (Screen)stackScreens.Peek();
            scr.Show();
        }

        private static Screen GetScreenByControllerName(String name)
        {
            switch (name)
            {
                case "MainScreen":
                    return new MainScreen();
                case "YandexScreen":
                    return new YandexScreen();
                case "ButtonScreen":
                    return new ButtonScreen();
                case "CheckBoxScreen":
                    return new CheckBoxScreen();
                case "SomeControlsScreen":
                    return new SomeControlsScreen();
                //case "VerticalLayoutScreen":
                //    return new VerticalLayoutScreen();
                //case "HorizontalLayoutScreen":
                //    return new HorizontalLayoutScreen();
                //case "ImageScreen":
                //    return new ImageScreen();
                case "EditTextScreen":
                    return new EditTextScreen();
                default:
                    throw new Exception(String.Format("Invalid controller name: {0}", name));
            }
        }
    }
}
