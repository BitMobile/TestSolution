using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class YandexScreen : Screen
    {
        Button syncButton;
        public override void OnLoading()
        {
            var vl = new VerticalLayout();
            AddChild(vl);
            syncButton = new Button();
            syncButton.OnClick += SyncButton_OnClick;

            vl.AddChild(syncButton);
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
            syncButton.Text = String.Format("Sync {0} yandex photos", DB.GetCountOfUnsyncedPhotos());
        }
        void SyncButton_OnClick(object sender, EventArgs e)
        {
            YandexPhoto.SyncPhotos();
            UpdateSyncButton();
        }
        void btn_OnClick(object sender, EventArgs e)
        {
            Guid id = Guid.NewGuid();
            String fileName = String.Format("shared/{0}", id.ToString());
            Camera.MakeSnapshot(fileName, 500,
                delegate(object sender2, EventArgs e2)
                {
                    Test.Model.Document.Photos photo = new Model.Document.Photos();
                    photo.Id = id;
                    photo.FileName = fileName;
                    photo.Save();
                    
                }
            );
        }
        void back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}
