using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class MemoEditScreen : Screen
    {
        private MemoEdit cssMemoEdit;
        private MemoEdit invisibeMemoEdit;
        private MemoEdit notEnabledMemoEdit;
        private MemoEdit placeholderMemoEdit;
        private MemoEdit textMemoEdit;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            invisibeMemoEdit = new MemoEdit();
            invisibeMemoEdit.CssClass = "MemoEdit";
            invisibeMemoEdit.Visible = true;
            invisibeMemoEdit.Text = "PLEASE HIDE ME";

            cssMemoEdit = new MemoEdit();
            cssMemoEdit.CssClass = "MemoEdit";
            cssMemoEdit.Text = "CHANGE MY CSS";
            cssMemoEdit.Id = "ID Of Css MemoEdit";

            textMemoEdit = new MemoEdit();
            textMemoEdit.CssClass = "MemoEdit";
            textMemoEdit.Text = "PLEASE CHANGE MY TEXT";

            //            textMemoEdit.AutoFocus = true;
            //            textMemoEdit.Length = 2;
            //            textMemoEdit.Required = true;

            placeholderMemoEdit = new MemoEdit();
            placeholderMemoEdit.CssClass = "MemoEdit";
            placeholderMemoEdit.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";

            notEnabledMemoEdit = new MemoEdit();
            notEnabledMemoEdit.Text = "NOT ENABLED MEMO EDIT";
            notEnabledMemoEdit.Enabled = false;
            notEnabledMemoEdit.CssClass = "MemoEdit";

            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
            vl.AddChild(new Button("Change CSS Of MemoEdit", ChangeCssMemoEdit_OnClick));
            vl.AddChild(new Button("Change Text Of MemoEdit", ChangeTextMemoEdit_OnClick));
            vl.AddChild(new Button("Change Placeholder Of MemoEdit", ChangePlaceholderMemoEdit_OnClick));
            vl.AddChild(new Button("Set Focus To Css MemoEdit", SetFocusToMemoEdit_OnClick));
            vl.AddChild(invisibeMemoEdit);
            vl.AddChild(cssMemoEdit);
            vl.AddChild(textMemoEdit);
            vl.AddChild(placeholderMemoEdit);
            vl.AddChild(notEnabledMemoEdit);
            vl.AddChild(new Button("Second MemoEdit Screen", SecondMemoEditScreen_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void SetFocusToMemoEdit_OnClick(object sender, EventArgs e)
        {
            cssMemoEdit.SetFocus();
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibeMemoEdit.Visible)
            {
                invisibeMemoEdit.Visible = false;
                DConsole.WriteLine(string.Format(cssMemoEdit.Id));
            }
            else if (invisibeMemoEdit.Visible == false)
            {
                invisibeMemoEdit.Visible = true;
            }
        }

        private void ChangeCssMemoEdit_OnClick(object sender, EventArgs e)
        {
            if (cssMemoEdit.CssClass == "MemoEdit")
            {
                cssMemoEdit.CssClass = "CssMemoEdit";
                cssMemoEdit.Refresh();
            }
            else if (cssMemoEdit.CssClass == "CssMemoEdit")
            {
                cssMemoEdit.CssClass = "MemoEdit";
                cssMemoEdit.Refresh();
            }
        }

        private void ChangeTextMemoEdit_OnClick(object sender, EventArgs e)
        {
            if (textMemoEdit.Text == "PLEASE CHANGE MY TEXT")
            {
                textMemoEdit.Text = "!!!!!ПОМОГИТЕ!!!!!";
            }
            else if (textMemoEdit.Text == "!!!!!ПОМОГИТЕ!!!!!")
            {
                textMemoEdit.Text = "PLEASE CHANGE MY TEXT";
            }
        }

        private void ChangePlaceholderMemoEdit_OnClick(object sender, EventArgs e)
        {
            if (placeholderMemoEdit.Placeholder == "PLACEHOLDER CHANGE MY PLACEHOLDER")
            {
                placeholderMemoEdit.Placeholder = "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ";
            }
            else if (placeholderMemoEdit.Placeholder == "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ")
            {
                placeholderMemoEdit.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";
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