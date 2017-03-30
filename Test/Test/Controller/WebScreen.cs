using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Web View", WebView_OnClick));
            vl.AddChild(new Button("Web Map Google", WebMapGoogle_OnClick));
            vl.AddChild(new Button("Web Image", WebImage_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void WebView_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("WebViewScreen");
        }

        private void WebMapGoogle_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("WebMapGoogleScreen");

        }

        private void WebImage_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("WebImageScreen");

        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }
    }
}