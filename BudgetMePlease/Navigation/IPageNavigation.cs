using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetMePlease.Navigation
{
    public interface IPageNavigation
    {
        void DisplayAlert(string title, string message, string ok, string cancel);

        Task PushAsync(Page page);

        Task<Page> PopAsync();
    }
}
