using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ImageScreen : Screen
    {
        private Image image;
<<<<<<< HEAD
=======
        //private Image poleviImage;
>>>>>>> refs/remotes/origin/master

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
<<<<<<< HEAD
            AddChild(vl);
=======

>>>>>>> refs/remotes/origin/master

            image = new Image();
            image.Source = "Image\\cats.jpg";
            image.CssClass = "Image";
            image.Id = "ID Of Image";

<<<<<<< HEAD
=======
            //poleviImage = new Image();
            //poleviImage.CssClass = "cats";

>>>>>>> refs/remotes/origin/master
            vl.AddChild(new Button("INVISIBLE IMAGE", Visible_OnClick));
            vl.AddChild(new Button("Change CSS Image", ChangeCssImage_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(image);
<<<<<<< HEAD
=======
            //vl.AddChild(poleviImage);
            //vl.OnClick += vl_OnClick;

            AddChild(vl);
>>>>>>> refs/remotes/origin/master
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (image.Visible)
            {
                image.Visible = false;
                DConsole.WriteLine(string.Format(image.Id));
            }
            else if (image.Visible == false)
            {
                image.Visible = true;
            }
        }

<<<<<<< HEAD
=======
        //private void vl_OnClick(object sender, EventArgs e)
        //{
        //    poleviImage.LoadFromStream(Application.GetResourceStream(@"Image\cats.jpg"));
        //}

>>>>>>> refs/remotes/origin/master
        private void ChangeCssImage_OnClick(object sender, EventArgs e)
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

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}