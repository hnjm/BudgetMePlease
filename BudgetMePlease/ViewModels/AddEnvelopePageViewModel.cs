using BudgetMePlease.Models;
using BudgetMePlease.Navigation;
using BudgetMePlease.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudgetMePlease.ViewModels
{
    public class AddEnvelopePageViewModel 
    {
        private IEnvelopeService _envelopeService;
        private IPageNavigation _pageNavigation;

        public Envelope Envelope { get; private set; }

        public ICommand SaveEnvelopeCommand { get; set; }

        public event EventHandler<Envelope> AddEnvelope;

        public AddEnvelopePageViewModel(IEnvelopeService envelopeService, IPageNavigation pageNavigation, EnvelopeViewModel envelope)
        {
            _envelopeService = envelopeService;
            _pageNavigation = pageNavigation;
            SaveEnvelopeCommand = new Command( async () => await SaveEnvelope());

            Envelope = new Envelope()
            {
                Name = envelope.Name,
                Id = envelope.Id,
                MonthlyBudget = envelope.MonthlyBudget,
                Spendings = envelope.Spendings
            };
            
        }

        private async Task SaveEnvelope()
        {
            if (Envelope.Name == null)
                return;
            if (Envelope.Id == 0)
            {
                await _envelopeService.InsertEnvelopeAsync(Envelope);
                AddEnvelope?.Invoke(this, Envelope);
            }
            
            await _pageNavigation.PopAsync();
        }
    }
}
