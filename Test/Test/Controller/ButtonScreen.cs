using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ButtonScreen : Screen
    {
        private Button cssButton;
        private Button invisibleButton;
<<<<<<< HEAD


        public override void OnLoading()
        {
=======
        private Button newButton;
        private VerticalLayout vl;

        public override void OnLoading()
        {

>>>>>>> refs/remotes/origin/master
            Initialize();
        }

        private void Initialize()
        {
<<<<<<< HEAD
            var vl = new VerticalLayout();
=======
            vl = new VerticalLayout();
>>>>>>> refs/remotes/origin/master
            AddChild(vl);

            invisibleButton = new Button {Text = "HIDE ME", Visible = false};
            invisibleButton.OnClick += Visible_OnClick;

            cssButton = new Button();
            cssButton.CssClass = "CssButton";
            cssButton.Text = "CssButton";
            cssButton.OnClick += ChangeCssAndText_OnClick;
            cssButton.Id = "Id Of Invisible Button";

            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
<<<<<<< HEAD
=======

>>>>>>> refs/remotes/origin/master
            vl.AddChild(invisibleButton);
            vl.AddChild(cssButton);
            vl.AddChild(new Button("Back", Back_OnClick));
        }

<<<<<<< HEAD
=======

>>>>>>> refs/remotes/origin/master
        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibleButton.Visible)
            {
                invisibleButton.Visible = false;
                DConsole.WriteLine(string.Format(cssButton.Id));
            }
            else if (invisibleButton.Visible == false)
            {
                invisibleButton.Visible = true;
            }
        }

<<<<<<< HEAD
=======



>>>>>>> refs/remotes/origin/master
        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeCssAndText_OnClick(object sender, EventArgs e)
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
<<<<<<< HEAD
}
=======
}
>>>>>>> refs/remotes/origin/master
