using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestXMLScreen : Screen
    {
        private readonly Button _textButton = null; //this variable will be assigned via screen xml template
        private readonly Button _visibleButton = null; //this variable will be assigned via screen xml template
        //private readonly Button _onEvent = null; //this variable will be assigned via screen xml template
        //private EditText _edit;
        //private TextView _text;

        public override void OnLoading()
        {
            //((Button)GetControl("_textButton", true)).OnClick += ChangeText_OnClick;
            //((Button)GetControl("_visibleButton", true)).OnClick += ChangeVisibility_OnClick;
            //((Button)GetControl("_changeVisibilityButton", true)).OnClick += ChangeVisibility_OnClick;
            ((Button)GetControl("_onEvent", true)).OnClick += Back_OnClick;
            //((Button)GetControl("_onEvent", true)).OnEvent = "Back";

            //text = (TextView)GetControl("_firstTextView", true);
            //edit = (EditText)GetControl("_firstEditText", true);
            //DConsole.WriteLine(string.Format(text.Text));
            //DConsole.WriteLine(string.Format(edit.Placeholder));
        }


        private void ChangeText_OnClick(object sender, EventArgs e)
        {
            /*можно в onLoading убрать инициализацию и менять текст таким образом*/

            //((Button)sender).Text = "TEST";

            //Indicator indicator = ((Indicator)GetControl("_firstIndicator", true));
            //indicator.Visible = true;

            if (_textButton.Text == "TextButton")
            {
                _textButton.Text = "Change Text Of TextButton";
            }
            else if (_textButton.Text == "Change Text Of TextButton")
            {
                _textButton.Text = "TextButton";
            }
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ExitButton_OnClick(object sender, EventArgs e)
        {
            Application.Terminate();
        }

        private void ChangeVisibility_OnClick(object sender, EventArgs e)
        {
            if (_visibleButton.Visible)
            {
                _visibleButton.Visible = false;
            }
            else if (_visibleButton.Visible == false)
            {
                _visibleButton.Visible = true;
            }
        }

        private void dl_OnClick(object sender, EventArgs e)
        {
            var dl = (DockLayout) sender;
            dl.CssClass = "DockLayout2";
            dl.Refresh();
        }

        private void ShowTextView_OnClick(object sender, EventArgs e)
        {
            var text = (TextView) GetControl("_firstTextView", true);
            DConsole.WriteLine(string.Format(text.Text));
        }


        private string[] GetControls()
        {
            return new[]
            {"One", "Two", "Three"}
                ;
        }


    }
}