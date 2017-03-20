using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DatabaseScreen : Screen
    {
        public TextView _textView;
        public Database db;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _textView = new TextView("STATUS");

            vl.AddChild(new Button("Initialize Database", InitDb));
            vl.AddChild(new Button("DB PerformSync", DbPerformSync));
            vl.AddChild(new Button("DB PerformSync Async", DbPerformSyncAsync));
            vl.AddChild(new Button("DB Perform Full Sync", DbPerformFullSync));
            vl.AddChild(new Button("DB Perform Full Sync With SRM", DbPerformFullSyncSRM));
            vl.AddChild(new Button("DB Perform Full Sync Async", DbPerformFullSyncAsync));
            vl.AddChild(new Button("Send Database", SendDatabase));
            vl.AddChild(new Button("Clear Cache", ClearCache));
            vl.AddChild(new Button("Clear LOG", ClearLog));
            vl.AddChild(new Button("Status", Status));
            vl.AddChild(_textView);


            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void InitDb(object sender, EventArgs e)
        {
            db = new Database();
            db.CreateFromModel();
            DConsole.WriteLine("Initialize OK!");
        }

        private void ClearCache(object sender, EventArgs e)
        {
            Application.ClearCache();
            DConsole.WriteLine("Cache cleared");
        }

        private void ClearLog(object sender, EventArgs e)
        {
            db.ClearLog();
            DConsole.WriteLine("Log cleared");
        }

        private void SendDatabase(object sender, EventArgs e)
        {
           
                Application.SendDatabase("http://10.5.195.222/bitmobile/synchro3", "sr", "sr");
            DConsole.WriteLine("database was sent");
            
        }

        private void Status(object sender, EventArgs e)
        {
            DConsole.WriteLine(db.LastError);
            DConsole.WriteLine(db.SuccessSync.ToString());
            _textView.Text = db.SuccessSync.ToString();
        }


        private void DbPerformSync(object sender, EventArgs e)
        {
            try
            {
                db.PerformSync(@"http://10.5.195.222/bitmobile/synchro3/device", "srm", "srm", TimeSpan.FromSeconds(100), OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformSync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformSyncAsync(object sender, EventArgs e)
        {
            try
            {
                if (db.SyncIsActive == false)
                    db.PerformSyncAsync(@"http://10.5.195.222/bitmobile/synchro2/device", "Sr", "Sr", TimeSpan.FromSeconds(100), OnSyncComplete,
                        "sync complete");
                DConsole.WriteLine("DbPerformSyncAsync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformFullSyncAsync(object sender, EventArgs e)
        {
            try
            {
                db.PerformFullSyncAsync(@"http://192.168.0.152/bitmobile/synchro3/device", "Sr", "Sr", TimeSpan.FromSeconds(100), OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformFullSyncAsync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformFullSync(object sender, EventArgs e)
        {
            try
            {
                db.PerformFullSync(@"http://192.168.0.152/bitmobile/synchro2/device", "Sr", "Sr", TimeSpan.FromSeconds(100), OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformFullSync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformFullSyncSRM(object sender, EventArgs e)
        {
            try
            {
                db.PerformFullSync(@"http://192.168.0.152/bitmobile/synchro3/device", "srm", "srm", TimeSpan.FromSeconds(100), OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformFullSync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void OnSyncComplete(object sender, ResultEventArgs<bool> resultEventArgs)
        {
            DConsole.WriteLine("OnSyncComplete ok");
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}