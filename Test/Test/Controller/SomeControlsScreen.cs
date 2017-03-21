using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class SomeControlsScreen : Screen
	{
		private HorizontalLine _horizontalLine;
		private TextView _textView;
		private EditText _textEditText;


		public override void OnLoading()
		{
			Initialize();
		}

		private void Initialize()
		{
			var vl = new VerticalLayout();
			AddChild(vl);

			_textEditText = new EditText();
			_textEditText.CssClass = "EditText";
			_textEditText.Text = "PLEASE CHANGE MY TEXT";
			_textEditText.AutoFocus = true;

			_horizontalLine = new HorizontalLine();
			_horizontalLine.Visible = true;
			_horizontalLine.CssClass = "HorizontalLine";
			_horizontalLine.Id = "ID Of Horizontal Line";

			_textView = new TextView();
			_textView.Visible = true;
			_textView.CssClass = "TextView";
			//_textView.Text = Translator.Translate("test");
			_textView.Text = "THIS";
			_textView.Id = "ID Of TextView";

			vl.AddChild(new Button("Change Css Of HL", ChangeCSSofHL_OnClick));
			vl.AddChild(_horizontalLine);
			vl.AddChild(new Button("Change Visibility Of HL", ChangeVisibilityOfHL_OnClick));
			vl.AddChild(new HorizontalLine());
			vl.AddChild(new Button("Change Css Of TextView", ChangeCssOfTextView_OnClick));
			vl.AddChild(_textView);
			vl.AddChild(new Button("Change Visibility Of TextView", ChangeVisibilityOfTextView_OnClick));
			vl.AddChild(new Button("Change Text Of TextView", ChangeTextOfTextView_OnClick));
			vl.AddChild(new Button("Back", Back_OnClick));
		}


		private void Back_OnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoBack();
		}

		private void ChangeCSSofHL_OnClick(object sender, EventArgs e)
		{
			if (_horizontalLine.CssClass == "HorizontalLine")
			{
				_horizontalLine.CssClass = "CssHorizontalLine";
				_horizontalLine.Refresh();
			}
			else if (_horizontalLine.CssClass == "CssHorizontalLine")
			{
				_horizontalLine.CssClass = "HorizontalLine";
				_horizontalLine.Refresh();
			}
		}

		private void ChangeVisibilityOfHL_OnClick(object sender, EventArgs e)
		{
			if (_horizontalLine.Visible)
			{
				_horizontalLine.Visible = false;
				DConsole.WriteLine(string.Format(_horizontalLine.Id));
			}
			else if (_horizontalLine.Visible == false)
			{
				_horizontalLine.Visible = true;
			}
		}

		private void ChangeCssOfTextView_OnClick(object sender, EventArgs e)
		{
			if (_textView.CssClass == "TextView")
			{
				_textView.CssClass = "CssTextView";

				_textView.Refresh();
			}
			else if (_textView.CssClass == "CssTextView")
			{
				_textView.CssClass = "TextView";

				_textView.Refresh();
			}
		}

		private void ChangeVisibilityOfTextView_OnClick(object sender, EventArgs e)
		{
			if (_textView.Visible)
			{
				_textView.Visible = false;
				DConsole.WriteLine(string.Format(_textView.Id));
			}
			else if (_textView.Visible == false)
			{
				_textView.Visible = true;
			}
		}

		private void ChangeTextOfTextView_OnClick(object sender, EventArgs e)
		{
			if (_textView.Text == "THIS IS TEST OF TEXTVIEW")
			{
				_textView.Text = "ВО ПОЛЕ БЕРЁЗА СТОЯЛА";
			}
			else if (_textView.Text == "ВО ПОЛЕ БЕРЁЗА СТОЯЛА")
			{
				_textView.Text = "THIS IS TEST OF TEXTVIEW";
			}
		}
	}
}