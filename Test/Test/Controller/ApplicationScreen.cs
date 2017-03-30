using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ApplicationScreen : Screen
    {
        public override void OnLoading()
        {
            var vl = new VerticalLayout();
            AddChild(vl);
  
            vl.AddChild(new Button("Resouce, Core Version", ResourceCoreVersion_OnClick));
            //vl.AddChild(new Button("Reload Data", ReloadData_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }

        internal void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.MoveTo("MainScreen");
        }
 

        internal void ResourceCoreVersion_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(Application.ResourceVersion);
            DConsole.WriteLine(Application.CoreVersion);
        }
    }
}