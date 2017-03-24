using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class MemoEditScreen : Screen
    {
        private MemoEdit _cssMemoEdit;
        private MemoEdit _invisibeMemoEdit;
        private MemoEdit _notEnabledMemoEdit;
        private MemoEdit _placeholderMemoEdit;
        private MemoEdit _textMemoEdit;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _invisibeMemoEdit = new MemoEdit();
            _invisibeMemoEdit.CssClass = "CssMemoEdit";
            _invisibeMemoEdit.Visible = true;
            _invisibeMemoEdit.Text = "PLEASE HIDE ME";

            _cssMemoEdit = new MemoEdit();
            _cssMemoEdit.CssClass = "MemoEdit";
            _cssMemoEdit.Text = "CHANGE MY CSS";
            _cssMemoEdit.Id = "ID Of Css MemoEdit";

            _cssMemoEdit.SetFocus();

            _textMemoEdit = new MemoEdit();
            _textMemoEdit.CssClass = "MemoEdit";
            _textMemoEdit.Text = "PLEASE CHANGE MY TEXT";

            //_textMemoEdit.AutoFocus = true;
            //            _textMemoEdit.Length = 2;
            //            _textMemoEdit.Required = true;

            _placeholderMemoEdit = new MemoEdit();
            _placeholderMemoEdit.CssClass = "CssMemoEdit";
            _placeholderMemoEdit.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";

            _notEnabledMemoEdit = new MemoEdit();
            _notEnabledMemoEdit.Text = "NOT ENABLED MEMO EDIT";
            _notEnabledMemoEdit.Enabled = false;
            _notEnabledMemoEdit.CssClass = "MemoEdit";

            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
            vl.AddChild(new Button("Change CSS Of MemoEdit", ChangeCssMemoEdit_OnClick));
            vl.AddChild(new Button("Change Text Of MemoEdit", ChangeTextMemoEdit_OnClick));
            vl.AddChild(new Button("Change Placeholder Of MemoEdit", ChangePlaceholderMemoEdit_OnClick));
            vl.AddChild(new Button("Set Focus To Css MemoEdit", SetFocusToMemoEdit_OnClick));
            vl.AddChild(_invisibeMemoEdit);
            vl.AddChild(_cssMemoEdit);
            vl.AddChild(_textMemoEdit);
            vl.AddChild(_placeholderMemoEdit);
            vl.AddChild(_notEnabledMemoEdit);
            vl.AddChild(new Button("Second MemoEdit Screen", SecondMemoEditScreen_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void SetFocusToMemoEdit_OnClick(object sender, EventArgs e)
        {
            _cssMemoEdit.SetFocus();
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (_invisibeMemoEdit.Visible)
            {
                _invisibeMemoEdit.Visible = false;
                DConsole.WriteLine(string.Format(_cssMemoEdit.Id));
            }
            else if (_invisibeMemoEdit.Visible == false)
            {
                _invisibeMemoEdit.Visible = true;
            }
        }

        private void ChangeCssMemoEdit_OnClick(object sender, EventArgs e)
        {
            if (_cssMemoEdit.CssClass == "MemoEdit")
            {
                _cssMemoEdit.CssClass = "CssMemoEdit";
                _cssMemoEdit.Refresh();
            }
            else if (_cssMemoEdit.CssClass == "CssMemoEdit")
            {
                _cssMemoEdit.CssClass = "MemoEdit";
                _cssMemoEdit.Refresh();
            }
        }

        private void ChangeTextMemoEdit_OnClick(object sender, EventArgs e)
        {
            if (_textMemoEdit.Text == "PLEASE CHANGE MY TEXT")
            {
                _textMemoEdit.Text = "!!!!!ПОМОГИТЕ!!!!!";
            }
            else if (_textMemoEdit.Text == "!!!!!ПОМОГИТЕ!!!!!")
            {
                _textMemoEdit.Text = "PLEASE CHANGE MY TEXT";
            }
        }

        private void ChangePlaceholderMemoEdit_OnClick(object sender, EventArgs e)
        {
            if (_placeholderMemoEdit.Placeholder == "PLACEHOLDER CHANGE MY PLACEHOLDER")
            {
                _placeholderMemoEdit.Placeholder = "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ";
            }
            else if (_placeholderMemoEdit.Placeholder == "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ")
            {
                _placeholderMemoEdit.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";
            }
        }

        private void SecondMemoEditScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SecondMemoEditScreen");
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}