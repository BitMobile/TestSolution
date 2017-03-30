using System;
using System.IO;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class FileSystemScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);


            vl.AddChild(new Button("LastError", LastError_OnClick));

            vl.AddChild(new Button("Sync shared", SyncShared_OnClick));

            vl.AddChild(new Button("Upload Private", UploadPrivate_OnClick));

            vl.AddChild(new Button("Delete Private And Shared", ClearPrivateShared_OnClick));

            vl.AddChild(new Button("Create Directory", CreateDirectory_OnClick));

            vl.AddChild(new Button("Delete Directory", DeleteDirectory_OnClick));

            vl.AddChild(new Button("Exists Directory", ExistsDirectory_OnClick));

            vl.AddChild(new Button("Create Text File", CreateTextFile_OnClick));
            vl.AddChild(new Button("Open Text File", OpenTextFile_OnClick));

            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void SyncShared_OnClick(object sender, EventArgs e)
        {
            try
            {
                FileSystem.SyncShared("http://192.168.0.152/bitmobile/synchro3/", "sr", "sr");
                //FileSystem.HandleLastError("ERROR");
                DConsole.WriteLine("SYNC SHARED OK");
            }
            catch (Exception)
            {
               FileSystem.HandleLastError("НЕ УДАЛОСЬ СИНХРОНИЗИРОВАТЬСЯ");
            }
        
        }

        private void UploadPrivate_OnClick(object sender, EventArgs e)
        {
            FileSystem.UploadPrivate("http://192.168.0.152/bitmobile/synchro3/", "sr", "sr");
            //FileSystem.HandleLastError("ERROR");
            DConsole.WriteLine("UPLOAD PRIVATE OK");

        }

        private void ClearPrivateShared_OnClick(object sender, EventArgs e)
        {
            FileSystem.ClearPrivate();
            FileSystem.ClearShared();
            DConsole.WriteLine("CLEAR PRIVATE AND SHARED DONE");
        }

        private void LastError_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(FileSystem.LastError);
            DConsole.WriteLine(FileSystem.SuccessSync.ToString());
            DConsole.WriteLine(FileSystem.LastSyncTime.ToString());
        }

        private void CreateDirectory_OnClick(object sender, EventArgs e)
        {
            try
            {
                FileSystem.CreateDirectory("/private/Document.Visit");
            }
            catch (IOException ex)
            {
                DConsole.WriteLine("IOException");
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DeleteDirectory_OnClick(object sender, EventArgs e)
        {
            FileSystem.Delete("/private/Document.Visit");
        }

        private void ExistsDirectory_OnClick(object sender, EventArgs e)
        {
            if (FileSystem.Exists("/private/Document.Visit"))
            {
                DConsole.WriteLine("EXISTS");
            }
            else
            {
                DConsole.WriteLine("NOT EXITSTS");
            }
        }

        private void CreateTextFile_OnClick(object sender, EventArgs e)
        {
            FileSystem.CreateTextFile("private/msg.text", "TextFileMSG");
        }

        private void OpenTextFile_OnClick(object sender, EventArgs e)
        {
           var m = FileSystem.OpenTextFile("private/msg.text");
            DConsole.WriteLine(m);
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            
            BusinessProcess.MoveTo("MainScreen");
        }
    }
}