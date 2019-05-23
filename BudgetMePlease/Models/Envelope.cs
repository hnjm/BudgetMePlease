using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetMePlease.Models
{
    public class Envelope
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MonthlyBudget { get; set; }
        public int Spendings { get; set; }
    }
}
