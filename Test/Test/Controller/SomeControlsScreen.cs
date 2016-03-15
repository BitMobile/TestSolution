using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SomeControlsScreen : Screen
    {
        HorizontalLine horizontalLine;

        public override void OnLoading()
        {
            initialize();
        }

        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            horizontalLine = new HorizontalLine();
            horizontalLine.Visible = true;


            vl.AddChild(new Button("Back", Back_OnClick));

            vl.AddChild(new Button("Back2", Back_OnClick));
        }
        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();

        }
    }
}
