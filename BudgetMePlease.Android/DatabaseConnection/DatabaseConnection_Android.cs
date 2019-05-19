using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BudgetMePlease.DatabaseConnection;
using BudgetMePlease.Droid.DatabaseConnection;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_Android))]
namespace BudgetMePlease.Droid.DatabaseConnection
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var dbName = AppConstants.DbName + "db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}