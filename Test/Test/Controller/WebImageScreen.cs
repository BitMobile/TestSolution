using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebImageScreen : Screen
    {
        private WebImage _webImage;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);
            //_webImage.Url = "http://goo.gl/muPIv2";
            _webImage = new WebImage();
            _webImage.Visible = true;
            _webImage.CssClass = "WebImage";
            _webImage.Id = "ID Of Web Image";
            _webImage.UrlType = "Absolute";
          
            _webImage.Url = "http://правительство.рф";

            vl.AddChild(_webImage);
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }
    }
}