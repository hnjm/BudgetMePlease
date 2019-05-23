using BudgetMePlease.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetMePlease.Models;
using BudgetMePlease.Navigation;
using BudgetMePlease.Views;
using Xamarin.Forms;

namespace BudgetMePlease.ViewModels
{
    public class SummaryPageViewModel : BaseViewModel
    {
        private bool _pageLoaded;
        private IEnvelopeService _envelopeService;
        private IPageNavigation _navigation;
        private string _total;
        public string TotalMonthlyBudget
        {
            get { return _total; }
            set { SetPropertyValue(ref _total, value); }
        }
        
        public ObservableCollection<EnvelopeViewModel> EnvelopeCollection { get; private set; } = new ObservableCollection<EnvelopeViewModel>();

        //Commands
        public ICommand AddEnvelopeCommand { get; private set; }
        public ICommand LoadPageCommand { get; private set; }

        public SummaryPageViewModel(IEnvelopeService envelopeService, IPageNavigation nav)
        {
            
            _envelopeService = envelopeService;
            _navigation = nav;

            LoadPageCommand = new Command(LoadPage);
            AddEnvelopeCommand = new Command(async () => await AddEnvelope());
        }

        private async void LoadPage()
        {
            await CalculateTotalMonthlyBudget();
            if (_pageLoaded)
                return;

            _pageLoaded = true;
            var envelopes = await _envelopeService.GetAllEnvelopes();
            foreach (Envelope env in envelopes)
            {
                EnvelopeCollection.Add(new EnvelopeViewModel(env));
            }
            await CalculateTotalMonthlyBudget();
        }

        private async Task AddEnvelope()
        {
            var addEnvelopeViewModel = new AddEnvelopePageViewModel(_envelopeService, _navigation, new EnvelopeViewModel());
            addEnvelopeViewModel.AddEnvelope += ((source, envelope) =>
            {
                EnvelopeCollection.Add(new EnvelopeViewModel(envelope));
                
            });

            await _navigation.PushAsync(new AddEnvelopePage(addEnvelopeViewModel));
        }

        private async Task CalculateTotalMonthlyBudget()
        {
            int tot = 0;
            await Task.Run(() =>
            {
                foreach (var env in EnvelopeCollection)
                {
                    tot += Int32.Parse(env.MonthlyBudget);
                }
                TotalMonthlyBudget = "$" + tot.ToString();
            });
        }
    }
}
