﻿
namespace GameNet
{
    using System;

    public class ServerInfo : IDisposable
    {
        public string ip { get; set; }
        public int port { get; set; }
        public string domain { get; set; }
        public void Dispose()
        {

        }
    }
}