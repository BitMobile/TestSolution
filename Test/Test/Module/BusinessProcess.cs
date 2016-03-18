using System;
using System.Xml;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using XmlDocument = BitMobile.ClientModel3.XmlDocument;

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
            var n =
                doc.DocumentElement.SelectSingleNode(string.Format("//BusinessProcess/Workflow/Step[@Name='{0}']",
                    stepName));
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
            var currentNode = (XmlNode) stackNodes.Peek();
            var n = currentNode.SelectSingleNode(string.Format("Action[@Name='{0}']", actionName));
            var stepName = n.Attributes["NextStep"].Value;
            MoveTo(stepName);
        }

        public static void DoBack()
        {
            //remove current
            stackNodes.Pop();
            stackScreens.Pop();

            var scr = (Screen) stackScreens.Peek();
            scr.Show();
        }

        private static Screen GetScreenByControllerName(string name)
        {
            switch (name)
            {
                case "MainScreen":
                    return new MainScreen();
                case "ButtonScreen":
                    return new ButtonScreen();
                case "CheckBoxScreen":
                    return new CheckBoxScreen();
//                case "SomeControlsScreen":
//                    return new SomeControlsScreen();
                //                case "LayoutScreen":
                //                    return new LayoutScreen();
                //                case "VerticalLayoutScreen":
                //                    return new VerticalLayoutScreen();
                //                case "HorizontalLayoutScreen":
                //                    return new HorizontalLayoutScreen();
                //                case "DockLayoutScreen":
                //                    return new DockLayoutScreen();
                //                case "ImageScreen":
                //                    return new ImageScreen();
                //                case "EditTextScreen":
                //                    return new EditTextScreen();
                case "MemoEditScreen":
                    return new MemoEditScreen();
                case "SecondMemoEditScreen":
                    return new SecondMemoEditScreen();
                //                case "SecondEditTextScreen":
                //                    return new SecondEditTextScreen();
                //                case "IndicatorScreen":
                //                    return new IndicatorScreen();
                //                case "YandexScreen":
                //                    return new YandexScreen();
                default:
                    throw new Exception(string.Format("Invalid controller name: {0}", name));
            }
        }
    }
}