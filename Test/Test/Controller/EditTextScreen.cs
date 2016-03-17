using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class EditTextScreen : Screen
    {
        private EditText cssEditText;
        private EditText invisibeEditText;
        private EditText placeholderEditText;
        private EditText textEditText;
        private EditText notEnabledEditText;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            invisibeEditText = new EditText();
            invisibeEditText.CssClass = "EditText";
            invisibeEditText.Visible = true;
            invisibeEditText.Text = "PLEASE HIDE ME";
            

            cssEditText = new EditText();
            cssEditText.CssClass = "EditText";
            cssEditText.Text = "CHANGE MY CSS";
            

            textEditText = new EditText();
            textEditText.CssClass = "EditText";
            textEditText.Text = "PLEASE CHANGE MY TEXT";
//            textEditText.Length = 2;
//            textEditText.Required = true;

            placeholderEditText = new EditText();
            placeholderEditText.CssClass = "EditText";
            placeholderEditText.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";

            notEnabledEditText = new EditText();
            notEnabledEditText.Text = "NOT ENABLED EDIT TEXT";
            notEnabledEditText.Enabled = false;
            notEnabledEditText.CssClass = "EditText";



            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
            vl.AddChild(new Button("Change CSS Of EditText", ChangeCssEditText_OnClick));
            vl.AddChild(new Button("Change Text Of EditText", ChangeTextEditText_OnClick));
            vl.AddChild(new Button("Change Placeholder Of EditText", ChangePlaceholderEditText_OnClick));
            vl.AddChild(new Button("Set Focus To Css EditText", SetFocusToEditText_OnClick));
            vl.AddChild(invisibeEditText);
            vl.AddChild(cssEditText);
            vl.AddChild(textEditText);
            vl.AddChild(placeholderEditText);
            vl.AddChild(notEnabledEditText);
            vl.AddChild(new Button("Second Edit Text Screen", SecondEditTextScreen_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void SetFocusToEditText_OnClick(object sender, EventArgs e)
        {
            cssEditText.SetFocus();
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibeEditText.Visible)
            {
                invisibeEditText.Visible = false;
            }
            else if (invisibeEditText.Visible == false)
            {
                invisibeEditText.Visible = true;
            }
        }

        private void ChangeCssEditText_OnClick(object sender, EventArgs e)
        {
            if (cssEditText.CssClass == "EditText")
            {
                cssEditText.CssClass = "CssEditText";

                cssEditText.Refresh();
            }
            else if (cssEditText.CssClass == "CssEditText")
            {
                cssEditText.CssClass = "EditText";

                cssEditText.Refresh();
            }
        }

        private void ChangeTextEditText_OnClick(object sender, EventArgs e)
        {
            if (textEditText.Text == "PLEASE CHANGE MY TEXT")
            {
                textEditText.Text = "!!!!!ПОМОГИТЕ!!!!!";
            }
            else if (textEditText.Text == "!!!!!ПОМОГИТЕ!!!!!")
            {
                textEditText.Text = "PLEASE CHANGE MY TEXT";
            }
        }

        private void ChangePlaceholderEditText_OnClick(object sender, EventArgs e)
        {
            if (placeholderEditText.Placeholder == "PLACEHOLDER CHANGE MY PLACEHOLDER")
            {
                placeholderEditText.Placeholder = "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ";
            }
            else if (placeholderEditText.Placeholder == "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ")
            {
                placeholderEditText.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";
            }
        }

        private void SecondEditTextScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SecondEditTextScreen");
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}