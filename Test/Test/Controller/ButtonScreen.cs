using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ButtonScreen : Screen
    {
        private Button _cssButton;
        private Button _invisibleButton;
        private Button _newButton;
        private Button _textButton;
        private VerticalLayout _vl1;
		private VerticalLayout _vl2;

		private ScrollView _scrollView;

		private readonly Thread thread = new Thread();


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
			_scrollView = new ScrollView();
			_vl1 = new VerticalLayout();
			_vl2 = new VerticalLayout();
            
			_scrollView.Id = "Id Of ScrollView";
            _scrollView.OnScroll += ScrollIndex_OnScroll;


            //var dialog = new Dialog();
            //dialog.Date();


            _invisibleButton = new Button {Text = "HIDE ME", Visible = false};
            _invisibleButton.OnClick += Visible_OnClick;

            _cssButton = new Button();
            _cssButton.CssClass = "CssButton";
            _cssButton.Text = "CssButton";
            _cssButton.OnClick += ChangeCssAndText_OnClick;
            _cssButton.Id = "Id Of Invisible Button";

            _textButton = new Button();
            _textButton.Text = "TextButton";
            _textButton.OnClick += ChangeText_OnClick;
            
            _vl1.AddChild(new Button("Unhide Button", Visible_OnClick));

            _vl1.AddChild(_invisibleButton);
            _vl1.AddChild(_cssButton);
            _vl1.AddChild(_textButton);
            _vl1.AddChild(new Button("Add New Button, EditText and Image", AddNewButton_OnClick));
            _vl1.AddChild(new Button("Remove", Remove_OnClick));
            _vl1.AddChild(new Button("Test Dialog", AddNewDialog_OnClick));
            _vl1.AddChild(new Button("Back", Back_OnClick));
            _vl1.AddChild(new Button("Wait", Wait_OnClick));
            _vl1.AddChild(new Button("Snackbar", Snackbar_OnClick));
            _vl1.AddChild(new Button("Toast", Toast_OnClick));
			_vl2.AddChild(new Button("OpenValidLink", OpenValidLinkOnClick));
			_vl2.AddChild(new Button("OpenInvalidLink", OpenInvalidLinkOnClick));
			_vl2.AddChild(new Button("OpenTwoLink", OpenTwoLinkOnClick));

			_scrollView.AddChild(_vl1);
			_scrollView.AddChild(_vl2);

			AddChild(_scrollView);
		}

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (_invisibleButton.Visible)
            {
                _invisibleButton.Visible = false;
                DConsole.WriteLine(string.Format(_cssButton.Id));
            }
            else if (_invisibleButton.Visible == false)
            {
                _invisibleButton.Visible = true;
            }
        }

		private void OpenValidLinkOnClick(object sender, EventArgs e)
		{
			try
			{
				Application.OpenLink("http://mirror.yandex.ru/archlinux/iso/latest/sha1sums.txt");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"ERROR: {exc}");
			}
		}

		private void OpenInvalidLinkOnClick(object sender, EventArgs e)
		{
			try
			{
				Application.OpenLink("/mirror.yandex.ru/archlinux/iso/latest/sha1sums.txt");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"ERROR: {exc}");
			}
		}

		private void OpenTwoLinkOnClick(object sender, EventArgs e)
		{
			try
			{
				Application.OpenLink("https://aur.archlinux.org/cgit/aur.git/snapshot/gnu-apl.tar.gz");
				Application.OpenLink("https://aur.archlinux.org/cgit/aur.git/snapshot/tilix.tar.gz");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"ERROR: {exc}");
			}
		}

		private void Wait_OnClick(object sender, EventArgs e)
        {
            thread.Sleep(3000);
        }
		private void Remove_OnClick(object sender, EventArgs e)
        {
            _vl1.RemoveChild(5);
        }

        private void Snackbar_OnClick(object sender, EventArgs e)
        {
            Toast.MakeSnackbar("Some text", "OK", SnackBar_OnOkButtonClickedHandler, "OK");
        } private void Toast_OnClick(object sender, EventArgs e)
        {
            Toast.MakeToast("TEST TOAST");
        }
        private void SnackBar_OnOkButtonClickedHandler(object sender, ResultEventArgs<bool> resultEventArgs)
        {
            Toast.MakeToast(sender + " button clicked on snackbar");
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeCssAndText_OnClick(object sender, EventArgs e)
        {
            if (_cssButton.CssClass == "CssButton")
            {
                _cssButton.CssClass = "ChangeCssButton";
                _cssButton.Text = "ChangeCss";
                _cssButton.Refresh();
            }
            else if (_cssButton.CssClass == "ChangeCssButton")
            {
                _cssButton.CssClass = "CssButton";
                _cssButton.Text = "CssButton";
                _cssButton.Refresh();
            }
        }

        private void AddNewButton_OnClick(object sender, EventArgs e)
        {
            _newButton = new Button("My name is NewButton", Back_OnClick);
            var text = new EditText();
            text.Text = "New EditText";
            var image = new Image();
            image.Source = "Image\\cats.jpg";
            _vl1.AddChild(_newButton);
            _vl1.AddChild(text);
            _vl1.AddChild(image);
            _vl1.Refresh();
        }

        private void ChangeText_OnClick(object sender, EventArgs e)
        {
            if (_textButton.Text == "TextButton")
            {
                _textButton.Text = "Change Text Of TextButton";
            }
            else if (_textButton.Text == "Change Text Of TextButton")
            {
                _textButton.Text = "TextButton";
            }
        }

        private void AddNewDialog_OnClick(object sender, EventArgs e)
        {
            /* DConsole.WriteLine($"{string.Empty.Length}");*/ // тихонько падает
            DConsole.WriteLine(string.Empty); // выполняется корректно (пропускается строка)
            DConsole.WriteLine($"{"".Length}"); // выводит 0
        }

		private void ScrollIndex_OnScroll(object sender, EventArgs e)
		{
			DConsole.WriteLine(string.Format(_scrollView.ScrollIndex.ToString()));
		}
	}
}