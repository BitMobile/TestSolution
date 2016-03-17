using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class CheckBoxScreen: Screen
    {
        CheckBox checkBoxTrue;
        CheckBox checkBoxFalse;
        CheckBox cssCheckBox;
        Button changeCssButton;
        CheckBox invisibleCheckBox;
       
        public override void OnLoading()
        {
            Initialize();
        }

        void Initialize()
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
        void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibleCheckBox.Visible == true)
            {
                invisibleCheckBox.Visible = false;
            }
            else if (invisibleCheckBox.Visible == false)
            {

                invisibleCheckBox.Visible = true;
            }
        }
        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();

        }
        void ChangeCssCheckBox_OnClick(object sender, EventArgs e)
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
        void ChangeCheckStatus_OnClick(object sender, EventArgs e)
        {
            if (checkBoxTrue.Checked == false)
            {
                checkBoxTrue.Checked = true;
                checkBoxFalse.Checked = true;
                cssCheckBox.Checked = true;
                invisibleCheckBox.Checked = true;
            }
            else if (checkBoxTrue.Checked == true)
            {
                checkBoxTrue.Checked = false;
                checkBoxFalse.Checked = false;
                cssCheckBox.Checked = false;
                invisibleCheckBox.Checked = false;
            }
        }
    }
}
