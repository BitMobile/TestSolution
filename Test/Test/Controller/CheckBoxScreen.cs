using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class CheckBoxScreen : Screen
    {
        private Button changeCssButton;
        private CheckBox checkBoxFalse;
        private CheckBox checkBoxTrue;
        private CheckBox cssCheckBox;
        private CheckBox invisibleCheckBox;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            checkBoxTrue = new CheckBox();
            checkBoxTrue.Visible = true;
            checkBoxTrue.CssClass = "CheckBox";
            checkBoxTrue.Checked = true;

            checkBoxFalse = new CheckBox();
            checkBoxFalse.Visible = true;
            checkBoxFalse.CssClass = "CheckBox";
            checkBoxFalse.Checked = false;

            cssCheckBox = new CheckBox();
            cssCheckBox.CssClass = "CheckBox";
            cssCheckBox.Id = "Id Of Css CheckBox";

            changeCssButton = new Button();
            changeCssButton.CssClass = "CssButton";
            changeCssButton.Text = "ChangeCssOfCheckBox";
            changeCssButton.OnClick += ChangeCssCheckBox_OnClick;

            invisibleCheckBox = new CheckBox();
            invisibleCheckBox.CssClass = "CheckBox";
            invisibleCheckBox.Visible = false;

            vl.AddChild(checkBoxTrue);
            vl.AddChild(checkBoxFalse);
            vl.AddChild(changeCssButton);
            vl.AddChild(cssCheckBox);
            vl.AddChild(new Button("Unhide CheckBox", Visible_OnClick));
            vl.AddChild(invisibleCheckBox);
            vl.AddChild(new Button("Change Check Status", ChangeCheckStatus_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibleCheckBox.Visible)
            {
                invisibleCheckBox.Visible = false;
                DConsole.WriteLine(string.Format(cssCheckBox.Id));
            }
            else if (invisibleCheckBox.Visible == false)
            {
                invisibleCheckBox.Visible = true;
            }
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeCssCheckBox_OnClick(object sender, EventArgs e)
        {
            if (cssCheckBox.CssClass == "CheckBox")
            {
                cssCheckBox.CssClass = "CssCheckBox";
                cssCheckBox.Refresh();
            }
            else if (cssCheckBox.CssClass == "CssCheckBox")
            {
                cssCheckBox.CssClass = "CheckBox";
                cssCheckBox.Refresh();
            }
        }

        private void ChangeCheckStatus_OnClick(object sender, EventArgs e)
        {
            if (checkBoxTrue.Checked == false)
            {
                checkBoxTrue.Checked = true;
                checkBoxFalse.Checked = true;
                cssCheckBox.Checked = true;
                invisibleCheckBox.Checked = true;
            }
            else if (checkBoxTrue.Checked)
            {
                checkBoxTrue.Checked = false;
                checkBoxFalse.Checked = false;
                cssCheckBox.Checked = false;
                invisibleCheckBox.Checked = false;
            }
        }
    }
}