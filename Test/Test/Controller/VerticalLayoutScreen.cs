using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class VerticalLayoutScreen : Screen
    {
        private TextView textView;
        private VerticalLayout vl2;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl2 = new VerticalLayout();
            vl2.CssClass = "vl";
            vl2.OnClick += Vl2_OnClick;
            vl2.Id = "ID Of Second Vertical Layout";

            textView = new TextView();
            textView.Text = "В онклик лейаута задана функция DoBack";
            textView.CssClass = "CssTextView";

            vl.AddChild(new Button("Change Visibility Of VL2", ChangeVisibilityOfVL2_OnClick));
            vl.AddChild(new Button("Change CSS Of VL2", ChangeCSSofVL2_OnClick));
            vl.AddChild(textView);
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(vl2);
            vl2.AddChild(new TextView("ALLOHA VL2"));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void Vl2_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeVisibilityOfVL2_OnClick(object sender, EventArgs e)
        {
            if (vl2.Visible)
            {
                vl2.Visible = false;
                DConsole.WriteLine(string.Format(vl2.Id));
            }
            else if (vl2.Visible == false)
            {
                vl2.Visible = true;
            }
        }

        private void ChangeCSSofVL2_OnClick(object sender, EventArgs e)
        {
            if (vl2.CssClass == "vl")
            {
                vl2.CssClass = "CssVerticalLayout";
                vl2.Refresh();
            }
            else if (vl2.CssClass == "CssVerticalLayout")
            {
                vl2.CssClass = "vl";
                vl2.Refresh();
            }
        }
    }
}