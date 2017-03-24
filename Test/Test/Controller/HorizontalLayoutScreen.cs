using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class HorizontalLayoutScreen : Screen
    {
        private HorizontalLayout _hl;
        private TextView _textView;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _hl = new HorizontalLayout();
            _hl.CssClass = "HorizontalLayout";
            _hl.OnClick += Hl_OnClick;
            _hl.Id = "ID Of Horizontal Layout";

            _textView = new TextView();
            _textView.Text = "В онклик лейаута задана функция DoBack";
            _textView.CssClass = "CssTextView";

            vl.AddChild(new Button("Change Visibility Of HL2", ChangeVisibilityOfHL2_OnClick));
            vl.AddChild(new Button("Change CSS Of HL2", ChangeCSSofHL2_OnClick));
            vl.AddChild(_textView);
            vl.AddChild(new Button("Back", Back_OnClick));
            _hl.AddChild(new Button("BackHL", Back_OnClick));
            _hl.AddChild(new Button("BackHL2", Back_OnClick));
            vl.AddChild(_hl);
        }

        private void Hl_OnClick(object sender, EventArgs e)
        {
             BusinessProcess.DoBack();
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeVisibilityOfHL2_OnClick(object sender, EventArgs e)
        {
            if (_hl.Visible)
            {
                _hl.Visible = false;
                DConsole.WriteLine(string.Format(_hl.Id));
            }
            else if (_hl.Visible == false)
            {
                _hl.Visible = true;
            }
        }

        private void ChangeCSSofHL2_OnClick(object sender, EventArgs e)
        {
            if (_hl.CssClass == "HorizontalLayout")
            {
                _hl.CssClass = "CssHorizontalLayout";
                _hl.Refresh();
            }
            else if (_hl.CssClass == "CssHorizontalLayout")
            {
                _hl.CssClass = "HorizontalLayout";
                _hl.Refresh();
            }
        }
    }
}