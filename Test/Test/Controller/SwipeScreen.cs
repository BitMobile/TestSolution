using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SwipeScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Swipe Horizontal Layout Screen", SwipeHorizontalLayoutScreen_OnClick));
            vl.AddChild(new Button("Swipe Vertical Layout Screen", SwipeVerticalLayoutScreen_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void SwipeHorizontalLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SwipeHorizontalLayoutScreen");
        }

        private void SwipeVerticalLayoutScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SwipeVerticalLayoutScreen");
        }
    }
}