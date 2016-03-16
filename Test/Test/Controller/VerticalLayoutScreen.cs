using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class VerticalLayoutScreen : Screen
    {
        VerticalLayout vl2;
        public override void OnLoading()
        {
            initialize();
        }
      
        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }   
        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl2 = new VerticalLayout();
            vl2.CssClass = "vl";
            vl2.OnClick += Vl2_OnClick;

            vl.AddChild(new Button("Change Visibility Of VL2", ChangeVisibilityOfVL2_OnClick));
            vl.AddChild(new Button("Change CSS Of VL2", ChangeCSSofVL2_OnClick));
            vl.AddChild(new Button("Back3", Back_OnClick));
            vl.AddChild(vl2);

            vl2.AddChild(new TextView("ALLOHA VL2"));
        }
        void Vl2_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
        void ChangeVisibilityOfVL2_OnClick(object sender, EventArgs e)
        {
            if(vl2.Visible == true)
            {
                vl2.Visible = false;
            }
            else if (vl2.Visible==false)
            {
                vl2.Visible = true;
            }
        }
        void ChangeCSSofVL2_OnClick (object sender, EventArgs e)
        {
            if (vl2.CssClass == "vl")
            {
                vl2.CssClass = "CssVerticalLayout";
                vl2.Refresh();
            }
            else if (vl2.CssClass == "CssVerticalLayout")
            {
                vl2.CssClass = "vl";
                vl2.Refresh();
            }
        }
      
    }
}
