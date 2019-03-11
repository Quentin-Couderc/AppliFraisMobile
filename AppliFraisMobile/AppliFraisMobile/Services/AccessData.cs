using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace AppliFraisMobile.Services
{
    public static class AccessData
    {
        static public SQLiteConnection db;
        static public WebService ws;
        static public void Init()
        {
            db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalFrais.db"));
        }
    }
}
