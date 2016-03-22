using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestHorizontalLayoutScreen : Screen
    {
        public override void OnLoading()
        {
            var hl = new HorizontalLayout();
            for (int i = 0; i < 4; i++)
            {
                hl.AddChild(new Button(string.Format("Btn  {0}  ", i.ToString()), vl_OnClick));
            }
            AddChild(hl);
            hl.AddChild(new Button("Back", Back_OnClick));
        }

        void vl_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            DConsole.WriteLine(btn.Text);
        }


        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}