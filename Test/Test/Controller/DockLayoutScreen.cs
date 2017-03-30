using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DockLayoutScreen : Screen
    {
        private DockLayout _dl;
        //private TextView _textView;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            //var vl = new VerticalLayout();
            //AddChild(vl);

            _dl = new DockLayout();
            _dl.Id = "ID Of DockLayout";
            _dl.OnClick += dl_OnClick;
            _dl.AddChild(new Button("Back", Back_OnClick));
            AddChild(_dl);
            //vl.AddChild(new Button("Change Visibility Of DL", ChangeVisibilityOfDL_OnClick));
            //vl.AddChild(new Button("Back", Back_OnClick));
            //vl.AddChild(_dl);

            //_dl.AddChild(new TextView("ALLOHA DL"));
            //_dl.AddChild(new TextView("ALLOHA DL2"));

            //отображается только две текствьюхи

            //_dl.AddChild(new TextView("ALLOHA DL3"));
            //_dl.AddChild(new TextView("ALLOHA DL4"));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void dl_OnClick(object sender, EventArgs e)
        {
            var dl = (DockLayout) sender;
            dl.CssClass = "DockLayout2";
            dl.Refresh();
        }

        //private void ChangeVisibilityOfDL_OnClick(object sender, EventArgs e)
        //{
        //    if (_dl.Visible)
        //    {
        //        _dl.Visible = false;
        //        DConsole.WriteLine(string.Format(_dl.Id));
        //    }
        //    else if (_dl.Visible == false)
        //    {
        //        _dl.Visible = true;
        //    }
    }
}

