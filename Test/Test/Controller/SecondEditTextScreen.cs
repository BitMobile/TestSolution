using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SecondEditTextScreen : Screen
    {
        private EditText autoEditText;
        private EditText defaultEditText;
        private EditText numericEditText;
        private EditText emailEditText;
        private EditText urlEditText;
        private EditText phoneEditText;
        private EditText onGetFocusEditText;
        private EditText onLostFocusEditText;

        public override void OnLoading()
        {
            initialize();
        }

        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            autoEditText = new EditText();
            defaultEditText = new EditText();
            numericEditText = new EditText();
            emailEditText = new EditText();
            urlEditText = new EditText();
            phoneEditText = new EditText();
            onGetFocusEditText = new EditText();
            onLostFocusEditText = new EditText();


            autoEditText.CssClass = "EditText";
            defaultEditText.CssClass = "EditText";
            numericEditText.CssClass = "EditText";
            emailEditText.CssClass = "EditText";
            urlEditText.CssClass = "EditText";
            phoneEditText.CssClass = "EditText";
            onGetFocusEditText.CssClass = "EditText";
            onLostFocusEditText.CssClass = "EditText";


            autoEditText.Keyboard = "auto";
            defaultEditText.Keyboard = "default";
            numericEditText.Keyboard = "numeric";
            emailEditText.Keyboard = "email";
            urlEditText.Keyboard = "url";
            phoneEditText.Keyboard = "phone";


            autoEditText.Text = "Auto Edit Text";
            defaultEditText.Text = "Default Edit Text";
            numericEditText.Text = "Numeric Edit Text";
            emailEditText.Text = "Email Edit Text";
            urlEditText.Text = "Url Edit Text";
            phoneEditText.Text = "Phone Edit Text";
            onGetFocusEditText.Text = "Get Focus And Back To EditText Screen";
            onLostFocusEditText.Text = "Lost Focus And Back To EditText Screen";

//если вставить эту строку, невозможно будет перейти на экран
//            phoneEditText.OnChange += Back_OnClick;

            onGetFocusEditText.OnGetFocus += Back_OnClick;
            onLostFocusEditText.OnLostFocus += Back_OnClick;


            vl.AddChild(autoEditText);
            vl.AddChild(defaultEditText);
            vl.AddChild(numericEditText);
            vl.AddChild(emailEditText);
            vl.AddChild(urlEditText);
            vl.AddChild(phoneEditText);
            vl.AddChild(onGetFocusEditText);
            vl.AddChild(onLostFocusEditText);
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}