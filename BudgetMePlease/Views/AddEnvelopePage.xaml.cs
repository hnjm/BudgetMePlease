using BudgetMePlease.Navigation;
using BudgetMePlease.Services;
using BudgetMePlease.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetMePlease.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEnvelopePage : ContentPage
    {
        public AddEnvelopePage(IPageNavigation pageNav, IEnvelopeService envService, EnvelopeViewModel envVm)
        {
            InitializeComponent();
            BindingContext = new AddEnvelopePageViewModel(envService, pageNav, envVm);
        }
    }
}