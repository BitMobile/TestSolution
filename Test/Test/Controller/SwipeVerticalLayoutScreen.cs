using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SwipeVerticalLayoutScreen : Screen
    {
        private VerticalLayout _verticalLayout;
        private Image _image;
        private Image _image2;
        private Image _image3;
        private Image _image4;

       

        private SwipeVerticalLayout _swipeVerticalLayout;
        

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);


            _swipeVerticalLayout = new SwipeVerticalLayout();
            _swipeVerticalLayout.Visible = true;
            _swipeVerticalLayout.CssClass = "SwipeVerticalLayout";
            _swipeVerticalLayout.Scrollable = true;
            _swipeVerticalLayout.OnSwipe += SwipeIndex_OnSwipe;

            _verticalLayout = new VerticalLayout();
            _verticalLayout.CssClass = "VlForSwipeVertical";


            _image = new Image();
            _image.Source = "Image\\cats.jpg";
            _image.Visible = true;
            _image.CssClass = "ImageForSwipeVertical";

            _image2 = new Image();
            _image2.Source = "Image\\cat2.jpg";
            _image2.Visible = true;
            _image2.CssClass = "ImageForSwipeVertical";

            _image3 = new Image();
            _image3.Source = "Image\\cat3.jpg";
            _image3.Visible = true;
            _image3.CssClass = "ImageForSwipeVertical";

            _image4 = new Image();
            _image4.Source = "Image\\cat4.jpg";
            _image4.Visible = true;
            _image4.CssClass = "ImageForSwipeVertical";


    
            _verticalLayout.AddChild(_swipeVerticalLayout);

            vl.AddChild(new Button("Default alignment", AlignmentDefault_OnClick));
            vl.AddChild(new Button("Center alignment", AlignmentCenter_OnClick));
            vl.AddChild(new Button("Swipe To Third Image", SwipeToThird_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));

            _swipeVerticalLayout.AddChild(_image);
            _swipeVerticalLayout.AddChild(_image2);
            _swipeVerticalLayout.AddChild(_image3);
            _swipeVerticalLayout.AddChild(_image4);


            vl.AddChild(_verticalLayout);

          
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void SwipeToThird_OnClick(object sender, EventArgs e)
        {
            _swipeVerticalLayout.Index = 2;
        }

        private void SwipeIndex_OnSwipe(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(_swipeVerticalLayout.Index.ToString()));
        }

        private void AlignmentCenter_OnClick(object sender, EventArgs e)
        {
            _swipeVerticalLayout.Alignment = "Center";
        }

        private void AlignmentDefault_OnClick(object sender, EventArgs e)
        {
            _swipeVerticalLayout.Alignment = "Default";
        }
    }
}