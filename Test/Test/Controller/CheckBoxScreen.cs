using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class CheckBoxScreen : Screen
    {
        private Button _changeCssButton;
        private CheckBox _checkBoxFalse;
        private CheckBox _checkBoxTrue;
        private CheckBox _cssCheckBox;
        private CheckBox _invisibleCheckBox;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _checkBoxTrue = new CheckBox();
            _checkBoxTrue.Visible = true;
            _checkBoxTrue.CssClass = "CheckBox";
            _checkBoxTrue.Checked = true;
            _checkBoxTrue.Enabled = false;

            _checkBoxFalse = new CheckBox();
            _checkBoxFalse.Visible = true;
            _checkBoxFalse.CssClass = "CheckBox";
            _checkBoxFalse.Checked = false;
            _checkBoxFalse.Enabled = true;

            _cssCheckBox = new CheckBox();
            _cssCheckBox.CssClass = "CheckBox";
            _cssCheckBox.Id = "Id Of Css CheckBox";

            _changeCssButton = new Button();
            _changeCssButton.CssClass = "CssButton";
            _changeCssButton.Text = "ChangeCssOfCheckBox";
            _changeCssButton.OnClick += ChangeCssCheckBox_OnClick;

            _invisibleCheckBox = new CheckBox();
            _invisibleCheckBox.CssClass = "CheckBox";
            _invisibleCheckBox.Visible = false;

            vl.AddChild(_checkBoxTrue);
            vl.AddChild(_checkBoxFalse);
            vl.AddChild(_changeCssButton);
            vl.AddChild(_cssCheckBox);
            vl.AddChild(new Button("Unhide CheckBox", Visible_OnClick));
            vl.AddChild(_invisibleCheckBox);
            vl.AddChild(new Button("Change Check Status", ChangeCheckStatus_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (_invisibleCheckBox.Visible)
            {
                _invisibleCheckBox.Visible = false;
                DConsole.WriteLine(string.Format(_cssCheckBox.Id));
            }
            else if (_invisibleCheckBox.Visible == false)
            {
                _invisibleCheckBox.Visible = true;
            }
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void ChangeCssCheckBox_OnClick(object sender, EventArgs e)
        {
            if (_cssCheckBox.CssClass == "CheckBox")
            {
                _cssCheckBox.CssClass = "CssCheckBox";
                _cssCheckBox.Enabled = false;
                _cssCheckBox.Refresh();
            }
            else if (_cssCheckBox.CssClass == "CssCheckBox")
            {
                _cssCheckBox.CssClass = "CheckBox";
                _cssCheckBox.Enabled = true;
                _cssCheckBox.Refresh();
            }
        }

        private void ChangeCheckStatus_OnClick(object sender, EventArgs e)
        {
            if (_checkBoxTrue.Checked == false)
            {
                _checkBoxTrue.Checked = true;
                _checkBoxFalse.Checked = true;
                _cssCheckBox.Checked = true;
                _invisibleCheckBox.Checked = true;
            }
            else if (_checkBoxTrue.Checked)
            {
                _checkBoxTrue.Checked = false;
                _checkBoxFalse.Checked = false;
                _cssCheckBox.Checked = false;
                _invisibleCheckBox.Checked = false;
            }
        }
    }
}