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
            Initialize();
        }

        void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            invisibleButton = new Button {Text = "HIDE ME", Visible = false};
            invisibleButton.OnClick += Visible_OnClick;

            cssButton = new Button();
            cssButton.CssClass = "CssButton";
            cssButton.Text = "CssButton";
            cssButton.OnClick += ChangeCssAndText_OnClick;
            cssButton.Id = "Id Of Invisible Button";
            

            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
            vl.AddChild(invisibleButton);
            vl.AddChild(cssButton);
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibleButton.Visible)
            {
                invisibleButton.Visible = false;
                DConsole.WriteLine(String.Format(cssButton.Id));
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

        void ChangeCssAndText_OnClick(object sender, EventArgs e)
        {
            if (cssButton.CssClass == "CssButton")
            {
                cssButton.CssClass = "ChangeCssButton";
                cssButton.Text = "ChangeCss";
                cssButton.Refresh();
            }
            else if (cssButton.CssClass == "ChangeCssButton")
            {
                cssButton.CssClass = "CssButton";
                cssButton.Text = "CssButton";
                cssButton.Refresh();
            }
        }
    }
}