using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetMePlease.Navigation
{
    public class PageNavigation : IPageNavigation
    {
        public async Task<Page> PopAsync()
        {
            return await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void DisplayAlert(string title, string message, string ok, string cancel)
        {
            Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }
    }
}
