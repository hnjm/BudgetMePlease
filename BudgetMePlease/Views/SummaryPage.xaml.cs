using BudgetMePlease.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetMePlease
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();
            summaryPageViewModel = new SummaryPageViewModel();
        }

        private SummaryPageViewModel summaryPageViewModel
        {
            get { return BindingContext as SummaryPageViewModel;  }
            set { BindingContext = value; }
        }
    }
}
