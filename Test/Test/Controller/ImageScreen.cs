using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ImageScreen : Screen
    {
        Image image;
        public override void OnLoading()
        {
            initialize();
        }

        void initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            image = new Image();
            image.Source="Image\\cats.jpg";
            image.CssClass = "Image";
            

            vl.AddChild(new Button("INVISIBLE IMAGE", Visible_OnClick));
            vl.AddChild(new Button ("Change CSS Image", ChangeCssImage_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(image);
        }

        void Visible_OnClick(object sender, EventArgs e)
        {
            if (image.Visible == true)
            {
                image.Visible = false;
            }
            else if (image.Visible == false)
            {

                image.Visible = true;
            }
        }
        void ChangeCssImage_OnClick(object sender, EventArgs e)
        {
            if (image.CssClass == "Image")
            {
                image.CssClass = "CssImage";

                image.Refresh();
            }
            else if (image.CssClass == "CssImage")
            {
                image.CssClass = "Image";

                image.Refresh();
            }
        }
            void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
   }
}