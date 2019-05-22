using System;
using System.Collections.Generic;
using System.Text;
using BudgetMePlease.Models;

namespace BudgetMePlease.ViewModels
{
    public class EnvelopeViewModel : BaseViewModel
    {
        private int id;
        private string _name;
        private int _monthlyBudget;
        private int _spendings;

        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue(ref _name, value); }
        }

        public int MonthlyBudget
        {
            get { return _monthlyBudget; }
            set { SetPropertyValue(ref _monthlyBudget, value); }
        }

        public int Spendings
        {
            get { return _spendings; }
            set { SetPropertyValue(ref _spendings, value); }
        }

        public EnvelopeViewModel()
        {

        }

        public EnvelopeViewModel(Envelope env)
        {
            Id = env.Id;
            Name = env.Name;
            MonthlyBudget = env.MonthlyBudget;
            Spendings = env.Spendings;
        }
    }
}
