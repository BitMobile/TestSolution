using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class VerticalLayoutScreen : Screen
    {
        private TextView _textView;
        private VerticalLayout _vl2;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _vl2 = new VerticalLayout();
            _vl2.CssClass = "vl";
            _vl2.OnClick += Vl2_OnClick;
            _vl2.Id = "ID Of Second Vertical Layout";

            _textView = new TextView();
            _textView.Text = "В онклик лейаута задана функция DoBack";
            _textView.CssClass = "CssTextView";

            vl.AddChild(new Button("Change Visibility Of VL2", ChangeVisibilityOfVL2_OnClick));
            vl.AddChild(new Button("Change CSS Of VL2", ChangeCSSofVL2_OnClick));
            vl.AddChild(_textView);
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(_vl2);
            _vl2.AddChild(new TextView("ALLOHA VL2"));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void Vl2_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void ChangeVisibilityOfVL2_OnClick(object sender, EventArgs e)
        {
            if (_vl2.Visible)
            {
                _vl2.Visible = false;
                DConsole.WriteLine(string.Format(_vl2.Id));
            }
            else if (_vl2.Visible == false)
            {
                _vl2.Visible = true;
            }
        }

        private void ChangeCSSofVL2_OnClick(object sender, EventArgs e)
        {
            if (_vl2.CssClass == "vl")
            {
                _vl2.CssClass = "CssVerticalLayout";
                _vl2.Refresh();
            }
            else if (_vl2.CssClass == "CssVerticalLayout")
            {
                _vl2.CssClass = "vl";
                _vl2.Refresh();
            }
        }
    }
}