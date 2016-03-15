using System;

using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;


namespace Test
{
    public class ButtonScreen : Screen
    {
        Button invisibleButton;
        Button cssButton;
        

        public override void OnLoading()
        {
            initialize();

        }

        void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibleButton.Visible == true)
            {
                invisibleButton.Visible = false;
            }
            else if (invisibleButton.Visible == false)
            {

                invisibleButton.Visible = true;
            }
        }


        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        void ChangeCss_OnClick (object sender, EventArgs e)
        {


            if (cssButton.CssClass == "CssButton")
            {
                cssButton.CssClass = "ChangeCssButton";
                cssButton.Refresh();
            }
            else if (cssButton.CssClass == "ChangeCssButton")
            {
                cssButton.CssClass = "CssButton";
                cssButton.Refresh();
            }
        }

        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            invisibleButton = new Button { Text = "HIDE ME", Visible = false };

            cssButton = new Button();
            cssButton.CssClass = "CssButton";
            cssButton.Text = "CssButton";
            cssButton.OnClick += ChangeCss_OnClick;
            
            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
            vl.AddChild(invisibleButton);
            vl.AddChild(cssButton);

            vl.AddChild(new Button("Back", Back_OnClick));
        }

    
    }


   
}
