using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SecondEditTextScreen : Screen
    {
        private EditText _autoEditText;
        private EditText _defaultEditText;
        private EditText _emailEditText;
        private EditText _numericEditText;
        private EditText _onGetFocusEditText;
        private EditText _onLostFocusEditText;
        private EditText _phoneEditText;
        private EditText _urlEditText;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _autoEditText = new EditText();
            _defaultEditText = new EditText();
            _numericEditText = new EditText();
            _emailEditText = new EditText();
            _urlEditText = new EditText();
            _phoneEditText = new EditText();
            _onGetFocusEditText = new EditText();
            _onLostFocusEditText = new EditText();

            _autoEditText.CssClass = "EditText";
            _defaultEditText.CssClass = "EditText";
            _numericEditText.CssClass = "EditText";
            _emailEditText.CssClass = "EditText";
            _urlEditText.CssClass = "EditText";
            _phoneEditText.CssClass = "EditText";
            _onGetFocusEditText.CssClass = "EditText";
            _onLostFocusEditText.CssClass = "EditText";

            _autoEditText.Keyboard = "auto";
            _defaultEditText.Keyboard = "default";
            _numericEditText.Keyboard = "numeric";
            _emailEditText.Keyboard = "email";
            _urlEditText.Keyboard = "url";
            _phoneEditText.Keyboard = "phone";

            //_autoEditText.Text = "Auto Edit Text";

            _defaultEditText.Text = "Default Edit Text";
            _numericEditText.Text = "Numeric Edit Text";
            _emailEditText.Text = "Email Edit Text";
            _urlEditText.Text = "Url Edit Text";
            _phoneEditText.Text = "Phone Edit Text";
            _onGetFocusEditText.Text = "Get Focus And Back To EditText Screen";
            _onLostFocusEditText.Text = "Lost Focus And Back To EditText Screen";

//если вставить эту строку, невозможно будет перейти на экран
//            _phoneEditText.OnChange += Back_OnClick;

            _onGetFocusEditText.OnGetFocus += Back_OnClick;
            _onLostFocusEditText.OnLostFocus += ChangeCss;

            _autoEditText.Placeholder = "MORE THAN 5 CHARACTERS";

            _autoEditText.Length = 5;
            _defaultEditText.Length = 5;
            _emailEditText.Length = 5;
            //_numericEditText = 5;
            _phoneEditText.Length = 5;
            _urlEditText.Length = 5;
            
           

            vl.AddChild(_autoEditText);
            vl.AddChild(_defaultEditText);
            vl.AddChild(_numericEditText);
            vl.AddChild(_emailEditText);
            vl.AddChild(_urlEditText);
            vl.AddChild(_phoneEditText);
            vl.AddChild(_onGetFocusEditText);
            vl.AddChild(_onLostFocusEditText);
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeCss(object sender, EventArgs e)
        {
            if (_autoEditText.CssClass== "EditText")
            {
                _autoEditText.CssClass = "CssEditText";
                _autoEditText.Refresh();
            }
            else
            {
                _autoEditText.CssClass = "EditText";
                               _autoEditText.Refresh();

            }
        }
    }
}