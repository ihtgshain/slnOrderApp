using prjOrderApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prjOrderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageL : ContentPage
    {
        MainPage mp = Application.Current.Properties["page"] as MainPage;
        List<C票券> list;
        List<C票券> list已訂票;
       
        bool isShowingList = true;
        public PageL()
        {
            InitializeComponent();
            list = mp.list;
            list已訂票 = mp.list已訂票;
            ShowList();

        }

        private void BtnChang(object sender, EventArgs e)
        {
            isShowingList = !isShowingList;
            ShowList();
        }
        private void BtnHome(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ShowList()
        {
            if (list已訂票.Count == 0)
            {
                lblCondition.Text = "(您目前尚未訂票)";
                isShowingList = true;
            }   
            else if (list.Count == 0)
            {
                lblCondition.Text = "(目前已無空位)";
                isShowingList = false;
            }
            else
            {
                lblCondition.Text = "";
            }

            listMovie.ItemsSource = null;
            if (isShowingList)
            {
                lblState.Text = "目前空位如下，點擊可訂票：";
                lblState.TextColor=Color.BlueViolet;
                listMovie.ItemsSource = list;
            }
            else
            {
                lblState.Text = "您訂的票如下，點擊可退票：";
                lblState.TextColor = Color.Blue;
                listMovie.ItemsSource = list已訂票;
            }
        }

        private async void listMovie_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as C票券;
            string strAct = item.尚未訂票 ? "訂票" : "退票";
            bool result = await DisplayAlert($"{strAct}確認", $"請確認{strAct}內容是否正確：" +
                $"\r\n{item.日期}的「{item.場次}」" +
                $"\r\n座位 {item.座位} ({item.票種})", $"我要{strAct}", $"不{strAct}");

            if (result && item.尚未訂票)
            {
                mp.ReserveTicket(item);
                ShowList();
            }
            else if(result && !item.尚未訂票)
            {
                mp.RefundTicket(item);
                ShowList();
            }
        }

        private void listMovie_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<C票券> listForSearch = isShowingList ? list : list已訂票;
            listMovie.ItemsSource = listForSearch.Where(s => s.EN.ToUpper().Contains(e.NewTextValue.ToUpper())
                                                || s.場次.Contains(e.NewTextValue));
        }
    }
}