using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SwipeHorizontalLayoutScreen : Screen
    {
        private HorizontalLayout _horizontalLayout;
        private Image _image;
        private Image _image2;
        private Image _image3;
        private Image _image4;
        private SwipeHorizontalLayout _swipeHorizontalLayout;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _swipeHorizontalLayout = new SwipeHorizontalLayout();
            _swipeHorizontalLayout.Visible = true;
            _swipeHorizontalLayout.CssClass = "SwipeHorizontalLayout";
            _swipeHorizontalLayout.Scrollable = true;
            _swipeHorizontalLayout.OnSwipe += SwipeIndex_OnSwipe;


            _horizontalLayout = new HorizontalLayout();
            _horizontalLayout.CssClass = "HorizontalLayout";

            _image = new Image();
            _image.Source = "Image\\cats.jpg";
            _image.Visible = true;
            _image.CssClass = "ImageForSwipeHorizontal";
            
            _image2 = new Image();
            _image2.Source = "Image\\cat2.jpg";
            _image2.Visible = true;
            _image2.CssClass = "ImageForSwipeHorizontal";

            _image3 = new Image();
            _image3.Source = "Image\\cat3.jpg";
            _image3.Visible = true;
            _image3.CssClass = "ImageForSwipeHorizontal";

            _image4 = new Image();
            _image4.Source = "Image\\cat4.jpg";
            _image4.Visible = true;
            _image4.CssClass = "ImageForSwipeHorizontal";


            _swipeHorizontalLayout.AddChild(_image);
            _swipeHorizontalLayout.AddChild(_image2);
            _swipeHorizontalLayout.AddChild(_image3);
            _swipeHorizontalLayout.AddChild(_image4);


            _horizontalLayout.AddChild(_swipeHorizontalLayout);


            vl.AddChild(new Button("Default alignment", AlignmentDefault_OnClick));
            vl.AddChild(new Button("Center alignment", AlignmentCenter_OnClick));
            vl.AddChild(new Button("Swipe To Third Image", SwipeToThird_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));

            vl.AddChild(_horizontalLayout);
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void SwipeToThird_OnClick(object sender, EventArgs e)
        {
            _swipeHorizontalLayout.Index = 2;
        }

        private void SwipeIndex_OnSwipe(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(_swipeHorizontalLayout.Index.ToString()));
        }

        private void AlignmentCenter_OnClick(object sender, EventArgs e)
        {
            _swipeHorizontalLayout.Alignment = "Center";
        }

        private void AlignmentDefault_OnClick(object sender, EventArgs e)
        {
            _swipeHorizontalLayout.Alignment = "Default";
        }
    }
}