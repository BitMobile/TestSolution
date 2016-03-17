using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class HorizontalLayoutScreen : Screen
    {
        HorizontalLayout hl;
        TextView textView;

        public override void OnLoading()
        {
            Initialize();
        }

        void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            hl = new HorizontalLayout();
            hl.CssClass = "HorizontalLayout";
            hl.OnClick += Hl_OnClick;
            hl.Id = "ID Of Horizontal Layout";


            textView = new TextView();
            textView.Text = "В онклик лейаута задана функция DoBack";
            textView.CssClass = "CssTextView";

            vl.AddChild(new Button("Change Visibility Of HL2", ChangeVisibilityOfHL2_OnClick));
            vl.AddChild(new Button("Change CSS Of HL2", ChangeCSSofHL2_OnClick));
            vl.AddChild(textView);
            vl.AddChild(new Button("Back", Back_OnClick));
            hl.AddChild(new Button("BackHL", Back_OnClick));
            hl.AddChild(new Button("BackHL2", Back_OnClick));
            vl.AddChild(hl);
        }

        private void Hl_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        void ChangeVisibilityOfHL2_OnClick(object sender, EventArgs e)
        {
            if (hl.Visible)
            {
                hl.Visible = false;
                DConsole.WriteLine(String.Format(hl.Id));

            }
            else if (hl.Visible == false)
            {
                hl.Visible = true;
            }
        }

        void ChangeCSSofHL2_OnClick(object sender, EventArgs e)
        {
            if (hl.CssClass == "HorizontalLayout")
            {
                hl.CssClass = "CssHorizontalLayout";
                hl.Refresh();
            }
            else if (hl.CssClass == "CssHorizontalLayout")
            {
                hl.CssClass = "HorizontalLayout";
                hl.Refresh();
            }
        }
    }
}