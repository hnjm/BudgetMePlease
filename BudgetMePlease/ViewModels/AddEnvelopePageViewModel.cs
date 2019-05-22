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
        public Envelope Envelope;

        public ICommand SaveEnvelopeCommand { get; set; }

        public event EventHandler<Envelope> AddEnvelope;

        public AddEnvelopePageViewModel(IEnvelopeService envelopeService, IPageNavigation pageNavigation, EnvelopeViewModel envelope)
        {
            _envelopeService = envelopeService;
            _pageNavigation = pageNavigation;
            SaveEnvelopeCommand = new Command(SaveEnvelope);

            Envelope = new Envelope()
            {
                Name = envelope.Name,
                Id = envelope.Id,
                MonthlyBudget = envelope.MonthlyBudget,
                Spendings = envelope.Spendings
            };
            
        }

        private void SaveEnvelope()
        {
            if (Envelope == null)
                return;
            if (Envelope.Id == 0)
            {
                _envelopeService.InsertEnvelopeAsync(Envelope);
                AddEnvelope?.Invoke(this, Envelope);
            }

            _pageNavigation.PopAsync();
        }
    }
}
