using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
	public class SecondButtonScreen : Screen
	{
		private VerticalLayout _verticalLayout1;
		private VerticalLayout _verticalLayout2;
		private static EditText _cssEditText;
		private static EditText _invisibeEditText;
		private EditText _notEnabledEditText;
		private static EditText _placeholderEditText;
		private static EditText _textEditText;
		private static ScrollView _scrollView;

		public override void OnLoading()
		{
			_scrollView = new ScrollView();
			_verticalLayout1 = new VerticalLayout();
			_verticalLayout2 = new VerticalLayout();

			#region pla-1770

			var pla1770 = new TextView
			{
				Visible = true,
				CssClass = "TextView",
				Text = "PLA1770"
			};
			_verticalLayout1.AddChild(pla1770);
			_verticalLayout1.AddChild(new Button("Open valid link(txt)", OpenValidLinkOnClick));
			_verticalLayout1.AddChild(new Button("Open second valid link(tar)", OpenSecondValidLinkOnClick));
			_verticalLayout1.AddChild(new Button("Open invalid link(txt)", OpenInvalidLinkOnClick));
			_verticalLayout1.AddChild(new Button("Open two valid link(tar)", OpenTwoLinkOnClick));

			#endregion

			#region pla-1728

			var pla1728 = new TextView
			{
				Visible = true,
				CssClass = "TextView",
				Text = "PLA1728"
			};
			_verticalLayout1.AddChild(pla1728);
			_invisibeEditText = new EditText
			{
				CssClass = "EditText",
				Visible = true,
				Text = "PLEASE HIDE ME"
			};

			_cssEditText = new EditText
			{
				CssClass = "EditText",
				Text = "CHANGE MY CSS",
				Id = "Id Of Css EditText"
			};

			_textEditText = new EditText
			{
				CssClass = "EditText",
				Text = "PLEASE CHANGE MY TEXT",
				AutoFocus = true,
				NeedSecure = true
			};

			_placeholderEditText = new EditText
			{
				CssClass = "EditText",
				Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER"
			};

			_notEnabledEditText = new EditText
			{
				Text = "NOT ENABLED EDIT TEXT",
				Enabled = false,
				CssClass = "EditText"
			};

			_verticalLayout1.AddChild(new Button("Unhide Button", Visible_OnClick));
			_verticalLayout1.AddChild(new Button("Change CSS Of EditText", ChangeCssEditTextOnClick));
			_verticalLayout2.AddChild(new Button("Change Text Of EditText", ChangeTextEditTextOnClick));
			_verticalLayout2.AddChild(new Button("Change Placeholder Of EditText", ChangePlaceholderEditTextOnClick));
			_verticalLayout2.AddChild(new Button("Set Focus To Css EditText", SetFocusToEditTextOnClick));
			_verticalLayout2.AddChild(_invisibeEditText);
			_verticalLayout2.AddChild(_cssEditText);
			_verticalLayout2.AddChild(_textEditText);
			_verticalLayout2.AddChild(_placeholderEditText);
			_verticalLayout2.AddChild(_notEnabledEditText);
			_verticalLayout2.AddChild(new Button("Second Edit Text Screen", SecondEditTextScreenOnClick));

			#endregion

			_verticalLayout2.AddChild(new Button("Back", BackOnClick));

			_scrollView.AddChild(_verticalLayout1);
			AddChild(_scrollView);
		}

		private static void OpenValidLinkOnClick(object sender, EventArgs e)
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

		private static void OpenSecondValidLinkOnClick(object sender, EventArgs e)
		{
			try
			{
				Application.OpenLink("https://aur.archlinux.org/cgit/aur.git/snapshot/gnu-apl.tar.gz");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"ERROR: {exc}");
			}
		}

		private static void OpenInvalidLinkOnClick(object sender, EventArgs e)
		{
			try
			{
				Application.OpenLink("/latest/sha1sums.txt");
			}
			catch (Exception exc)
			{
				DConsole.WriteLine($"ERROR: {exc}");
			}
		}

		private static void OpenTwoLinkOnClick(object sender, EventArgs e)
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

		private static void SetFocusToEditTextOnClick(object sender, EventArgs e)
		{
			_cssEditText.SetFocus();
		}

		private static void Visible_OnClick(object sender, EventArgs e)
		{
			if (_invisibeEditText.Visible)
			{
				_invisibeEditText.Visible = false;
				DConsole.WriteLine(string.Format(_cssEditText.Id));
			}
			else if (_invisibeEditText.Visible == false)
			{
				_invisibeEditText.Visible = true;
			}
		}

		private static void ChangeCssEditTextOnClick(object sender, EventArgs e)
		{
			if (_cssEditText.CssClass == "EditText")
			{
				_cssEditText.CssClass = "CssEditText";
				_cssEditText.Refresh();
			}
			else if (_cssEditText.CssClass == "CssEditText")
			{
				_cssEditText.CssClass = "EditText";
				_cssEditText.Refresh();
			}
		}

		private static void ChangeTextEditTextOnClick(object sender, EventArgs e)
		{
			if (_textEditText.Text == "PLEASE CHANGE MY TEXT")
			{
				_textEditText.Text = "!!!!!ПОМОГИТЕ!!!!!";
			}
			else if (_textEditText.Text == "!!!!!ПОМОГИТЕ!!!!!")
			{
				_textEditText.Text = "PLEASE CHANGE MY TEXT";
			}
		}

		private static void ChangePlaceholderEditTextOnClick(object sender, EventArgs e)
		{
			if (_placeholderEditText.Placeholder == "PLACEHOLDER CHANGE MY PLACEHOLDER")
			{
				_placeholderEditText.Placeholder = "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ";
			}
			else if (_placeholderEditText.Placeholder == "ГОСУДАРСТВЕННЫЙ СЛУЖАЩИЙ")
			{
				_placeholderEditText.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";
			}
		}

		private static void SecondEditTextScreenOnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoAction("SecondEditTextScreen");
		}

		private static void BackOnClick(object sender, EventArgs e)
		{
			BusinessProcess.DoBack();
		}
	}
}