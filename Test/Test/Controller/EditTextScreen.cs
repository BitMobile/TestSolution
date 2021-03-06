﻿using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class EditTextScreen : Screen
    {
        private EditText _cssEditText;
        private EditText _invisibeEditText;
        private EditText _notEnabledEditText;
        private EditText _placeholderEditText;
        private EditText _textEditText;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _invisibeEditText = new EditText();
            _invisibeEditText.CssClass = "EditText";
            _invisibeEditText.Visible = true;
            _invisibeEditText.Text = "PLEASE HIDE ME";

            _cssEditText = new EditText();
            _cssEditText.CssClass = "EditText";
            _cssEditText.Text = "CHANGE MY CSS";
            _cssEditText.Id = "ID Of Css EditText";

            _textEditText = new EditText();
            _textEditText.CssClass = "EditText";
            _textEditText.Text = "PLEASE CHANGE MY TEXT";
            _textEditText.AutoFocus = true;
            //_textEditText.Length = 2;
            //_textEditText.Required = true;

            _placeholderEditText = new EditText();
            _placeholderEditText.CssClass = "EditText";
            _placeholderEditText.Placeholder = "PLACEHOLDER CHANGE MY PLACEHOLDER";
            

            _notEnabledEditText = new EditText();
            _notEnabledEditText.Text = "NOT ENABLED EDIT TEXT";
            _notEnabledEditText.Enabled = false;
            _notEnabledEditText.CssClass = "EditText";

            vl.AddChild(new Button("Unhide Button", Visible_OnClick));
            vl.AddChild(new Button("Change CSS Of EditText", ChangeCssEditText_OnClick));
            vl.AddChild(new Button("Change Text Of EditText", ChangeTextEditText_OnClick));
            vl.AddChild(new Button("Change Placeholder Of EditText", ChangePlaceholderEditText_OnClick));
            vl.AddChild(new Button("Set Focus To Css EditText", SetFocusToEditText_OnClick));
            vl.AddChild(_invisibeEditText);
            vl.AddChild(_cssEditText);
            vl.AddChild(_textEditText);
            vl.AddChild(_placeholderEditText);
            vl.AddChild(_notEnabledEditText);
            vl.AddChild(new Button("Second Edit Text Screen", SecondEditTextScreen_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void SetFocusToEditText_OnClick(object sender, EventArgs e)
        {
            _cssEditText.SetFocus();
        }

        private void Visible_OnClick(object sender, EventArgs e)
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

        private void ChangeCssEditText_OnClick(object sender, EventArgs e)
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

        private void ChangeTextEditText_OnClick(object sender, EventArgs e)
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

        private void ChangePlaceholderEditText_OnClick(object sender, EventArgs e)
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

        private void SecondEditTextScreen_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("SecondEditTextScreen");
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}