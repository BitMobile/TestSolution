﻿using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class HorizontalLayoutScreen : Screen
    {

        HorizontalLayout hl;
        public override void OnLoading()
        {
            initialize();
        }

        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            hl = new HorizontalLayout();
            hl.CssClass = "HorizontalLayout";
            hl.OnClick += Hl_OnClick;

            vl.AddChild(new Button("Change Visibility Of HL2", ChangeVisibilityOfHL2_OnClick));
            vl.AddChild(new Button("Change CSS Of HL2", ChangeCSSofHL2_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));

            hl.AddChild(new Button("BackHL", Back_OnClick));
            hl.AddChild(new Button("BackHL2", Back_OnClick));
            vl.AddChild(hl);
        }

        private void Hl_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
        void ChangeVisibilityOfHL2_OnClick(object sender, EventArgs e)
        {
            if (hl.Visible == true)
            {
                hl.Visible = false;
            }
            else if (hl.Visible == false)
            {
                hl.Visible = true;
            }
        }
        void ChangeCSSofHL2_OnClick(object sender, EventArgs e)
        {
            if (hl.CssClass == "HorizontalLayout")
            {
                hl.CssClass = "CssHorizontalLayout";
                hl.Refresh();
            }
            else if (hl.CssClass == "CssHorizontalLayout")
            {
                hl.CssClass = "HorizontalLayout";
                hl.Refresh();
            }
        }
    }
}