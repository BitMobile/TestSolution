using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SecondMemoEditScreen : Screen
    {
        private MemoEdit autoMemoEdit;
        private MemoEdit defaultMemoEditt;
        private MemoEdit emailMemoEdit;
        private MemoEdit numericMemoEdit;
        private MemoEdit onGetFocusMemoEdit;
        private MemoEdit onLostFocusMemoEdit;
        private MemoEdit phoneMemoEdit;
        private MemoEdit urlMemoEdit;

        public override void OnLoading()
        {
            initialize();
        }

        private void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            autoMemoEdit = new MemoEdit();
            defaultMemoEditt = new MemoEdit();
            numericMemoEdit = new MemoEdit();
            emailMemoEdit = new MemoEdit();
            urlMemoEdit = new MemoEdit();
            phoneMemoEdit = new MemoEdit();
            onGetFocusMemoEdit = new MemoEdit();
            onLostFocusMemoEdit = new MemoEdit();

            autoMemoEdit.CssClass = "MemoEdit";
            defaultMemoEditt.CssClass = "MemoEdit";
            numericMemoEdit.CssClass = "MemoEdit";
            emailMemoEdit.CssClass = "MemoEdit";
            urlMemoEdit.CssClass = "MemoEdit";
            phoneMemoEdit.CssClass = "MemoEdit";
            onGetFocusMemoEdit.CssClass = "MemoEdit";
<<<<<<< HEAD
            onLostFocusMemoEdit.CssClass = "EditText";
=======
            onLostFocusMemoEdit.CssClass = "MemoEdit";
>>>>>>> refs/remotes/origin/master

            autoMemoEdit.Keyboard = "auto";
            defaultMemoEditt.Keyboard = "default";
            numericMemoEdit.Keyboard = "numeric";
            emailMemoEdit.Keyboard = "email";
            urlMemoEdit.Keyboard = "url";
            phoneMemoEdit.Keyboard = "phone";

            autoMemoEdit.Text = "Auto Memo Edit";
            defaultMemoEditt.Text = "Default Memo Edit";
            numericMemoEdit.Text = "Numeric Memo Edit";
            emailMemoEdit.Text = "Email Memo Edit";
            urlMemoEdit.Text = "Url Memo Edit";
            phoneMemoEdit.Text = "Phone Memo Edit";
            onGetFocusMemoEdit.Text = "Get Focus And Back To MemoEdit Screen";
            onLostFocusMemoEdit.Text = "Lost Focus And Back To MemoEdit Screen";

//если вставить эту строку, невозможно будет перейти на экран
//            phoneMemoEdit.OnChange += Back_OnClick;

            onGetFocusMemoEdit.OnGetFocus += Back_OnClick;
            onLostFocusMemoEdit.OnLostFocus += Back_OnClick;

            vl.AddChild(autoMemoEdit);
            vl.AddChild(defaultMemoEditt);
            vl.AddChild(numericMemoEdit);
            vl.AddChild(emailMemoEdit);
            vl.AddChild(urlMemoEdit);
            vl.AddChild(phoneMemoEdit);
            vl.AddChild(onGetFocusMemoEdit);
            vl.AddChild(onLostFocusMemoEdit);
            vl.AddChild(new Button("Back", Back_OnClick));
        }

<<<<<<< HEAD

=======
>>>>>>> refs/remotes/origin/master
        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}