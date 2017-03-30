using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;
//using Test.Model.Document;

namespace Test
{
    public class YandexScreen : Screen
    {
        private Button _syncButton;

        public override void OnLoading()
        {
            var vl = new VerticalLayout();
            AddChild(vl);
            _syncButton = new Button();
            _syncButton.OnClick += SyncButton_OnClick;

            vl.AddChild(_syncButton);
            var btn = new Button();
            btn.Text = "Make snapshot";
            btn.OnClick += btn_OnClick;

            vl.AddChild(btn);

            vl.AddChild(new Button("Back", back_OnClick));
        }

        public override void OnShow()
        {
            UpdateSyncButton();
        }

        private void UpdateSyncButton()
        {
            _syncButton.Text = string.Format("Sync {0} yandex photos", DB.GetCountOfUnsyncedPhotos());
        }

        private void SyncButton_OnClick(object sender, EventArgs e)
        {
            YandexPhoto.SyncPhotos();
            UpdateSyncButton();
        }

        private void btn_OnClick(object sender, EventArgs e)
        {
            var id = Guid.NewGuid();
            var fileName = string.Format("shared/{0}", id);
            Camera.MakeSnapshot(fileName, 500,
                delegate
                {
                    //var photo = new Photos();
                    //photo.Id = id;
                    //photo.FileName = fileName;
                    //photo.Save();
                   UpdateSyncButton();
                }
                );
        }

        private void back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }
    }
}