using System;
using BitMobile.BusinessProcess.ClientModel;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
using Converter = BitMobile.ClientModel3.Converter;

namespace Test
{
    public class TestBugsScreen : Screen
    {
        private MemoEdit _cssMemoEdit;
        private VerticalLayout vl;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void Initialize()
        {
            vl = new VerticalLayout();
            AddChild(vl);

            _cssMemoEdit = new MemoEdit();
            _cssMemoEdit.CssClass = "CssHugeMemoEdit";
            _cssMemoEdit.Text = "CHANGE MY CSS";
            _cssMemoEdit.Id = "ID Of Css MemoEdit";
            _cssMemoEdit.AutoFocus = true;
            vl.AddChild(new Button("Back", Back_OnClick));

            vl.AddChild(_cssMemoEdit);
            //vl.AddChild(memo);
        }
    }
}