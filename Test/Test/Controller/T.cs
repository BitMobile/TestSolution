using System;
using BitMobile.ClientModel3;

namespace Test
{
    public class T : Thread
    {
        public T()
        {
        }
        public override void Execute()
        {
            while (true)
            { Sleep(3000); DConsole.WriteLine(DateTime.Now.ToLongTimeString()); DConsole.WriteLine(GPS.CurrentLocation.Latitude.ToString()); DConsole.WriteLine(GPS.CurrentLocation.Longitude.ToString()); }
        }
    }

}