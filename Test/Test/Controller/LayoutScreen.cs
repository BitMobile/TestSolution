using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class LayoutScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("VerticalLayout", VerticalLayoutScreen_OnClick));
            vl.AddChild(new Button("HorizontalLayout", HorizontalLayoutScreen_OnClick));
<<<<<<< HEAD
=======
            vl.AddChild(new Button("TestHorizontalLayoutScreen", TestHorizontalLayoutScreen_OnClick));
>>>>>>> refs/remotes/origin/master
            vl.AddChild(new Button("DockLayout", DockLayoutScreen_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void VerticalLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("VerticalLayoutScreen");
        }

        private void HorizontalLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("HorizontalLayoutScreen");
        }

<<<<<<< HEAD
=======
        private void TestHorizontalLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("TestHorizontalLayoutScreen");
        }

>>>>>>> refs/remotes/origin/master
        private void DockLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("DockLayoutScreen");
        }
    }
}