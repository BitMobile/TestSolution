using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ImageScreen : Screen
    {
        private Image _image;
        private Image _imageFromCamera;
        private Image _imageFromShared;
        private Image _imageFromPrivate;
        //private Image poleviImage;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();


            _image = new Image();
            _image.Source = "Image\\grotem.jpg";
            _image.CssClass = "Image";
            _image.Id = "ID Of Image";

            _imageFromCamera = new Image();
            _imageFromCamera.Source= @"~\private\test.jpg";

            _imageFromPrivate = new Image();
            _imageFromShared = new Image();


            _imageFromPrivate.Source = @"~\private\testprivate.jpg";
            _imageFromShared.Source = @"~\shared\catalog.accounts\0cb35078-e7c7-41c2-bc6d-b587c14b7b7f\testpict2.jpg";


            //poleviImage = new Image();
            //poleviImage.CssClass = "cats";

            //vl.AddChild(new Button("INVISIBLE IMAGE", Visible_OnClick));
            //vl.AddChild(new Button("Change CSS Image", ChangeCssImage_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
            //vl.AddChild(_imageFromCamera);
            vl.AddChild(_imageFromShared);
            vl.AddChild(_imageFromPrivate);
            //vl.AddChild(poleviImage);
            //vl.OnClick += vl_OnClick;

            AddChild(vl);
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (_image.Visible)
            {
                _image.Visible = false;
                DConsole.WriteLine(string.Format(_image.Id));
            }
            else if (_image.Visible == false)
            {
                _image.Visible = true;
            }
        }

        //private void vl_OnClick(object sender, EventArgs e)
        //{
        //    poleviImage.LoadFromStream(Application.GetResourceStream(@"Image\cats.jpg"));
        //}

        private void ChangeCssImage_OnClick(object sender, EventArgs e)
        {
            if (_image.CssClass == "Image")
            {
                _image.CssClass = "CssImage";
                _image.Refresh();
            }
            else if (_image.CssClass == "CssImage")
            {
                _image.CssClass = "Image";
                _image.Refresh();
            }
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}