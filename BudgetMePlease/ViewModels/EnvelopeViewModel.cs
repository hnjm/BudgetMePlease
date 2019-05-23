using System;
using System.Collections.Generic;
using System.Text;
using BudgetMePlease.Models;

namespace BudgetMePlease.ViewModels
{
    public class EnvelopeViewModel : BaseViewModel
    {
        private string _name;
        private string _monthlyBudget;
        private int _spendings;

        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue(ref _name, value); }
        }

        public string MonthlyBudget
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
            _name = env.Name;
            _monthlyBudget = env.MonthlyBudget;
            _spendings = env.Spendings;
        }
    }
}
