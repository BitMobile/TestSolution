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
            horizontalLine.CssClass = "HorizontalLine";
            //horizontalLine.Refresh();


            vl.AddChild(new Button("Change Css Of HL", ChangeCSSofHL_OnClick));
        
            vl.AddChild(horizontalLine);
            vl.AddChild(new Button("Change Visibility Of HL", ChangeVisibilityOfHL_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }
        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();

        }
        void ChangeCSSofHL_OnClick(object sender, EventArgs e)
        {
            if (horizontalLine.CssClass == "HorizontalLine")
            {
                horizontalLine.CssClass = "CssHorizontalLine";

                horizontalLine.Refresh();
            }
            else if (horizontalLine.CssClass == "CssHorizontalLine")
            {
                horizontalLine.CssClass = "HorizontalLine";

                horizontalLine.Refresh();
            }

        }
        void ChangeVisibilityOfHL_OnClick(object sender, EventArgs e)
        {
            if (horizontalLine.Visible == true)
            {
                horizontalLine.Visible = false;
            }
             else if (horizontalLine.Visible == false)
            {
                horizontalLine.Visible = true;
            }

        }
    }
}
