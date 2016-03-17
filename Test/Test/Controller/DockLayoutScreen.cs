using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DockLayoutScreen : Screen
    {
        DockLayout dl;
        private TextView textView;

        public override void OnLoading()
        {
            Initialize();
        }

        void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            dl = new DockLayout();
            dl.CssClass = "DockLayout";
            dl.Id = "ID Of DockLayout";
            
            vl.AddChild(new Button("Change Visibility Of DL", ChangeVisibilityOfDL_OnClick));    
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(dl);
            dl.AddChild(new TextView("ALLOHA DL"));
            dl.AddChild(new TextView("ALLOHA DL2"));
            //отображается только две текствьюхи
            dl.AddChild(new TextView("ALLOHA DL3"));
            dl.AddChild(new TextView("ALLOHA DL4"));
        }

        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

   
        void ChangeVisibilityOfDL_OnClick(object sender, EventArgs e)
        {
            if (dl.Visible)
            {
                dl.Visible = false;
                DConsole.WriteLine(String.Format(dl.Id));

            }
            else if (dl.Visible == false)
            {
                dl.Visible = true;
            }
        }
        }
    }
