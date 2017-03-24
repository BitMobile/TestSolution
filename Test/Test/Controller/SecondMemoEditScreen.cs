using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SecondMemoEditScreen : Screen
    {
        private MemoEdit _autoMemoEdit;
        private MemoEdit _defaultMemoEditt;
        private MemoEdit _emailMemoEdit;
        private MemoEdit _numericMemoEdit;
        private MemoEdit _onGetFocusMemoEdit;
        private MemoEdit _onLostFocusMemoEdit;
        private MemoEdit _phoneMemoEdit;
        private MemoEdit _urlMemoEdit;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _autoMemoEdit = new MemoEdit();
            _defaultMemoEditt = new MemoEdit();
            _numericMemoEdit = new MemoEdit();
            _emailMemoEdit = new MemoEdit();
            _urlMemoEdit = new MemoEdit();
            _phoneMemoEdit = new MemoEdit();
            _onGetFocusMemoEdit = new MemoEdit();
            _onLostFocusMemoEdit = new MemoEdit();

            _autoMemoEdit.CssClass = "MemoEdit";
            _defaultMemoEditt.CssClass = "MemoEdit";
            _numericMemoEdit.CssClass = "MemoEdit";
            _emailMemoEdit.CssClass = "MemoEdit";
            _urlMemoEdit.CssClass = "MemoEdit";
            _phoneMemoEdit.CssClass = "MemoEdit";
            _onGetFocusMemoEdit.CssClass = "MemoEdit";
            _onLostFocusMemoEdit.CssClass = "MemoEdit";

            _autoMemoEdit.Keyboard = "auto";
            _defaultMemoEditt.Keyboard = "default";
            _numericMemoEdit.Keyboard = "numeric";
            _emailMemoEdit.Keyboard = "email";
            _urlMemoEdit.Keyboard = "url";
            _phoneMemoEdit.Keyboard = "phone";

            _autoMemoEdit.Text = "Auto Memo Edit";
            _defaultMemoEditt.Text = "Default Memo Edit";
            _numericMemoEdit.Text = "Numeric Memo Edit";
            _emailMemoEdit.Text = "Email Memo Edit";
            _urlMemoEdit.Text = "Url Memo Edit";
            _phoneMemoEdit.Text = "Phone Memo Edit";
            _onGetFocusMemoEdit.Text = "Get Focus And Back To MemoEdit Screen";
            _onLostFocusMemoEdit.Text = "Lost Focus And Back To MemoEdit Screen";

//если вставить эту строку, невозможно будет перейти на экран
//            _phoneMemoEdit.OnChange += Back_OnClick;

            _onGetFocusMemoEdit.OnGetFocus += Back_OnClick;
            _onLostFocusMemoEdit.OnLostFocus += Back_OnClick;

            vl.AddChild(_autoMemoEdit);
            vl.AddChild(_defaultMemoEditt);
            vl.AddChild(_numericMemoEdit);
            vl.AddChild(_emailMemoEdit);
            vl.AddChild(_urlMemoEdit);
            vl.AddChild(_phoneMemoEdit);
            vl.AddChild(_onGetFocusMemoEdit);
            vl.AddChild(_onLostFocusMemoEdit);
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}