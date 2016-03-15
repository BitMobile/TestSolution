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


        void back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }



        void initialize()
        {
            invisibleButton = new Button { Text = "HIDE ME", Visible = false };
            var vl = new VerticalLayout();
            AddChild(vl);


            vl.AddChild(new Button("Unhide Button", Visible_OnClick));

            vl.AddChild(new Button("Back", back_OnClick));


            vl.AddChild(invisibleButton);
        }

    }


   
}
