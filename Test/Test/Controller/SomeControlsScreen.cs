using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SomeControlsScreen : Screen
    {
        private HorizontalLine horizontalLine;
        private TextView textView;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            horizontalLine = new HorizontalLine();
            horizontalLine.Visible = true;
            horizontalLine.CssClass = "HorizontalLine";
            horizontalLine.Id = "ID Of Horizontal Line";

            textView = new TextView();
            textView.Visible = true;
            textView.CssClass = "TextView";
            textView.Text = "THIS IS TEST OF TEXTVIEW";
            textView.Id = "ID Of TextView";

            vl.AddChild(new Button("Change Css Of HL", ChangeCSSofHL_OnClick));
            vl.AddChild(horizontalLine);
            vl.AddChild(new Button("Change Visibility Of HL", ChangeVisibilityOfHL_OnClick));
            vl.AddChild(new HorizontalLine());
            vl.AddChild(new Button("Change Css Of TextView", ChangeCssOfTextView_OnClick));
            vl.AddChild(textView);
            vl.AddChild(new Button("Change Visibility Of TextView", ChangeVisibilityOfTextView_OnClick));
            vl.AddChild(new Button("Change Text Of TextView", ChangeTextOfTextView_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeCSSofHL_OnClick(object sender, EventArgs e)
        {
            if (horizontalLine.CssClass == "HorizontalLine")
            {
                horizontalLine.CssClass = "CssHorizontalLine";
                horizontalLine.Refresh();
            }
            else if (horizontalLine.CssClass == "CssHorizontalLine")
            {
                horizontalLine.CssClass = "HorizontalLine";
                horizontalLine.Refresh();
            }
        }

        private void ChangeVisibilityOfHL_OnClick(object sender, EventArgs e)
        {
            if (horizontalLine.Visible)
            {
                horizontalLine.Visible = false;
                DConsole.WriteLine(string.Format(horizontalLine.Id));
            }
            else if (horizontalLine.Visible == false)
            {
                horizontalLine.Visible = true;
            }
        }

        private void ChangeCssOfTextView_OnClick(object sender, EventArgs e)
        {
            if (textView.CssClass == "TextView")
            {
                textView.CssClass = "CssTextView";

                textView.Refresh();
            }
            else if (textView.CssClass == "CssTextView")
            {
                textView.CssClass = "TextView";

                textView.Refresh();
            }
        }

        private void ChangeVisibilityOfTextView_OnClick(object sender, EventArgs e)
        {
            if (textView.Visible)
            {
                textView.Visible = false;
                DConsole.WriteLine(string.Format(textView.Id));
            }
            else if (textView.Visible == false)
            {
                textView.Visible = true;
            }
        }

        private void ChangeTextOfTextView_OnClick(object sender, EventArgs e)
        {
            if (textView.Text == "THIS IS TEST OF TEXTVIEW")
            {
                textView.Text = "ВО ПОЛЕ БЕРЁЗА СТОЯЛА";
            }
            else if (textView.Text == "ВО ПОЛЕ БЕРЁЗА СТОЯЛА")
            {
                textView.Text = "THIS IS TEST OF TEXTVIEW";
            }
        }
    }
}