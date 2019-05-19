using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BudgetMePlease.DatabaseConnection
{
    public interface IDatabaseConnection
    {
        SQLiteAsyncConnection GetConnection();
    }
}
