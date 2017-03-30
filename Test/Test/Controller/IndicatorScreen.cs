using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class IndicatorScreen : Screen
    {
        private Indicator _cssIndicator;
        private Indicator _invisibleIndicator;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _invisibleIndicator = new Indicator();
            _invisibleIndicator.CssClass = "Indicator";
            _invisibleIndicator.Visible=true;

            _cssIndicator = new Indicator();
            _cssIndicator.CssClass = "Indicator";
            _cssIndicator.Visible = true;
            _cssIndicator.Id = "ID Of Css Indicator";

            vl.AddChild(new Button("Hide _invisibleIndicator", Visible_OnClick));
            vl.AddChild(_invisibleIndicator);
            vl.AddChild(new Button("Change Css Of Indicator", ChangeCssIndicator_OnClick));
            vl.AddChild(_cssIndicator);
            vl.AddChild(new Button("Start Indicators", Start_OnClick));
            vl.AddChild(new Button("Stop Indicators", Stop_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (_invisibleIndicator.Visible)
            {
                _invisibleIndicator.Visible = false;
                DConsole.WriteLine(string.Format(_cssIndicator.Id));
            }
            else if (_invisibleIndicator.Visible == false)
            {
                _invisibleIndicator.Visible = true;
            }
        }

        private void ChangeCssIndicator_OnClick(object sender, EventArgs e)
        {
            if (_cssIndicator.CssClass == "Indicator")
            {
                _cssIndicator.CssClass = "CssIndicator";

                _cssIndicator.Refresh();
            }
            else if (_cssIndicator.CssClass == "CssIndicator")
            {
                _cssIndicator.CssClass = "Indicator";

                _cssIndicator.Refresh();
            }
        }

        private void Start_OnClick(object sender, EventArgs e)
        {
            _invisibleIndicator.Start();
            _cssIndicator.Start();
        }

        private void Stop_OnClick(object sender, EventArgs e)
        {
            _cssIndicator.Stop();
            _invisibleIndicator.Stop();
        }
    }
}