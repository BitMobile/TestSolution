using System;

using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;


namespace Test
{
    public class ButtonScreen : Screen
    {
        Button unvisibleButton;
        public override void OnLoading()
        {
            unvisibleButton = new Button();
            unvisibleButton.Text = "HIDE ME";
            unvisibleButton.Visible = false;
            var vl = new VerticalLayout();
            AddChild(vl);

         
            vl.AddChild(new Button("Unhide Button", Visible_OnClick));

            vl.AddChild(new Button("Back", back_OnClick));


            vl.AddChild(unvisibleButton);

        }

        void Visible_OnClick(object sender, EventArgs e)
        {
            if (unvisibleButton.Visible == true)
            {
                unvisibleButton.Visible = false;
            }
            else if (unvisibleButton.Visible == false)
            {

                unvisibleButton.Visible = true;
            }
        }


        void back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}
