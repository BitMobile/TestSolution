﻿using System;

using BitMobile.ClientModel3;

namespace Test
{
    public class Solution : Application
    {
        public override void OnCreate()
        {
            DB.Init();
            BusinessProcess.Init();
        }
    }
}
