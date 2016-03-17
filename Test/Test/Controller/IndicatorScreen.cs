using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class IndicatorScreen : Screen
    {
        private Indicator cssIndicator;
        private Indicator invisibleIndicator;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            invisibleIndicator = new Indicator();
            invisibleIndicator.CssClass = "Indicator";

            cssIndicator = new Indicator();
            cssIndicator.CssClass = "Indicator";
            cssIndicator.Visible = true;
            cssIndicator.Id = "ID Of Css Indicator";

            vl.AddChild(new Button("Hide invisibleIndicator", Visible_OnClick));
            vl.AddChild(invisibleIndicator);
            vl.AddChild(new Button("Change Css Of Indicator", ChangeCssIndicator_OnClick));
            vl.AddChild(cssIndicator);
            vl.AddChild(new Button("Start Indicators", Start_OnClick));
            vl.AddChild(new Button("Stop Indicators", Stop_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (invisibleIndicator.Visible)
            {
                invisibleIndicator.Visible = false;
                DConsole.WriteLine(string.Format(cssIndicator.Id));
            }
            else if (invisibleIndicator.Visible == false)
            {
                invisibleIndicator.Visible = true;
            }
        }

        private void ChangeCssIndicator_OnClick(object sender, EventArgs e)
        {
            if (cssIndicator.CssClass == "Indicator")
            {
                cssIndicator.CssClass = "CssIndicator";

                cssIndicator.Refresh();
            }
            else if (cssIndicator.CssClass == "CssIndicator")
            {
                cssIndicator.CssClass = "Indicator";

                cssIndicator.Refresh();
            }
        }

        private void Start_OnClick(object sender, EventArgs e)
        {
            invisibleIndicator.Start();
            cssIndicator.Start();
        }

        private void Stop_OnClick(object sender, EventArgs e)
        {
            cssIndicator.Stop();
            invisibleIndicator.Stop();
        }
    }
}