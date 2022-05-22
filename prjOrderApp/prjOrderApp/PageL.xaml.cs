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

        private void ShowList()
        {
            if(list.Count ==0) isShowingList = false;
            else if (list已訂票.Count ==0) isShowingList = true;
            lblState.Text = isShowingList ? "目前空位如下：" : "您訂的票如下：";
            listMovie.ItemsSource = isShowingList ? list : list已訂票;
        }
    }
}