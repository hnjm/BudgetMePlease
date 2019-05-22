using BudgetMePlease.Services;
using BudgetMePlease.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMePlease.Dao;
using BudgetMePlease.Navigation;
using Xamarin.Forms;

namespace BudgetMePlease
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class SummaryPage : ContentPage
    {
        private IEnvelopeService _envelopeService;
        private IPageNavigation nav;
        public SummaryPage()
        {
            InitializeComponent();
            _envelopeService = new EnvelopeServiceImp(new EnvelopeDaoImp());
            nav = new PageNavigation();
            summaryPageViewModel = new SummaryPageViewModel(_envelopeService, nav);
        }

        protected override void OnAppearing()
        {
            summaryPageViewModel.LoadPageCommand.Execute(null);
            base.OnAppearing();
        }

        private SummaryPageViewModel summaryPageViewModel
        {
            get { return BindingContext as SummaryPageViewModel;  }
            set { BindingContext = value; }
        }
    }
}
