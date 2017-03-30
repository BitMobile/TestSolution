using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebMapGoogleScreen : Screen
    {
        private WebMapGoogle _webMapGoogle;
        private HorizontalLayout hl;
        private VerticalLayout vl;


        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            vl = new VerticalLayout();
            AddChild(vl);
            hl = new HorizontalLayout();

            vl.AddChild(hl);
            vl.AddChild(new Button("ID", ID_OnClick));
            vl.AddChild(new Button("Stop GPS", StopGPS_OnClick));
            vl.AddChild(new Button("Start GPS", StartTracking_OnClick));
            vl.AddChild(new Button("Add Web Map Google", Add_WebMap_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }

        private void StopGPS_OnClick(object sender, EventArgs e)
        {
          
            GPS.StopTracking();
        }

        private void ID_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(_webMapGoogle.Id));
            
        }

        private void Add_WebMap_OnClick(object sender, EventArgs e)
        {
            _webMapGoogle = new WebMapGoogle();
            _webMapGoogle.Visible = true;
            _webMapGoogle.CssClass = "WebMapGoogle";
            _webMapGoogle.Id = "ID OF WEB MAP GOOGLE";
            
            hl.AddChild(_webMapGoogle);
            hl.Refresh();
            vl.Refresh();
            
        }

        private void StartTracking_OnClick(object sender, EventArgs e)
        {
            if (GPS.StartTracking())
            {
                DConsole.WriteLine("GPS tracking started");
                new T().Start();
            }
        }
    }
}