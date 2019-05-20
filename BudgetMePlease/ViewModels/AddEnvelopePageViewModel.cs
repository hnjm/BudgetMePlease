using BudgetMePlease.Models;
using BudgetMePlease.Navigation;
using BudgetMePlease.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudgetMePlease.ViewModels
{
    public class AddEnvelopePageViewModel 
    {
        private IEnvelopeService _envelopeService;
        private IPageNavigation _pageNavigation;
        private Envelope _envelope;

        public ICommand SaveEnvelopeCommand { get; set; }

        public event EventHandler<Envelope> AddEnvelope;

        public AddEnvelopePageViewModel(IEnvelopeService envelopeService, IPageNavigation pageNavigation, EnvelopeViewModel envelope)
        {
            _envelopeService = envelopeService;
            _pageNavigation = pageNavigation;
            SaveEnvelopeCommand = new Command(() => SaveEnvelope());

            _envelope = new Envelope()
            {
                Name = envelope.Name,
                Id = envelope.Id,
                MonthlyBudget = envelope.MonthlyBudget,
                Spendings = envelope.Spendings
            };
            
        }

        private void SaveEnvelope()
        {
            if (_envelope == null)
                return;
            if (_envelope.Id == 0)
            {
                _envelopeService.InsertEnvelopeAsync(_envelope);
                AddEnvelope?.Invoke(this, _envelope);
            }

            _pageNavigation.PopAsync();
        }
    }
}
