using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BudgetMePlease.DatabaseConnection;
using BudgetMePlease.iOS.DatabaseConnection;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_iOS))]
namespace BudgetMePlease.iOS.DatabaseConnection
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var dbName = AppConstants.DbName + ".db3";
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "../", "Library");
            var path = Path.Combine(libraryPath, dbName);

            return new SQLiteAsyncConnection(path);
        }
    }
}