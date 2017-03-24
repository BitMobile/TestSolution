using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebViewScreen : Screen
    {
        private WebView _webView;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _webView = new WebView();
            _webView.CssClass = "WebView";
            _webView.Visible = true;
            _webView.Url = "http://правительство.рф";

            

            vl.AddChild(_webView);
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}