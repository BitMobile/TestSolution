using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class CameraPhoneGpsScreen : Screen
    {
        private EditText editText;
        private TextView text;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            text = new TextView();
            text.Text = "89119901150";

            editText = new EditText();


            vl.AddChild(text);
            vl.AddChild(new Button("Make Call", Phone_OnClick));
            vl.AddChild(new Button("Camera MakeSnapshot", Camera_OnClick));
            vl.AddChild(editText);
            vl.AddChild(new Button("Copy To Clipboard", CopyToClipboard_OnClick));
            vl.AddChild(new Button("From Clipboard To DDConsole", FromClipboardToDConsole_OnClick));
            vl.AddChild(new Button("Gallery", Gallery_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void CopyToClipboard_OnClick(object sender, EventArgs e)
        {
            Clipboard.SetString(editText.Text);
        }

        private void FromClipboardToDConsole_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(Clipboard.HasStringValue.ToString()));
            DConsole.WriteLine(Clipboard.GetString());
        }

        private void Phone_OnClick(object sender, EventArgs e)
        {
            Phone.Call(text.Text);
        }

        private void DDConsoleWriteLine(object sender, ResultEventArgs<bool> args)
        {
            DConsole.WriteLine(args.Result.ToString());
        }

      

        private void Camera_OnClick(object sender, EventArgs e)
        {

            Camera.MakeSnapshot("//private//testPrivate.jpg", 820, DDConsoleWriteLine);
        }

        private void Gallery_OnClick(object sender, EventArgs e)
        {
            Gallery.Size = 100;
            Gallery.Copy("//shared//");
        }
    }
}