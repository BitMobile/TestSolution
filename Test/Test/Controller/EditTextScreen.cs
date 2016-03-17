using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class EditTextScreen : Screen
    {

        public override void OnLoading()
        {
            initialize();
        }

        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Back", Back_OnClick));
        }


        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

    }
}