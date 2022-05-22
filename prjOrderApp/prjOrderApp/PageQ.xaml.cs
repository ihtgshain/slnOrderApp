using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using prjOrderApp.model;

namespace prjOrderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageQ : ContentPage
    {
        MainPage mp= Application.Current.Properties["page"] as MainPage;
        List<C票券> list;// = Application.Current.Properties["page"] as List<C票券>;
        int index = 0;
        public PageQ(int indexFomnMainPage)
        {
            index = indexFomnMainPage;
            list = mp.list;
            InitializeComponent();
            ShowImage();
            ShowWords();
            CheckBtnVisable();
        }

        private void ShowWords()
        { 
            var ml = list[index];
            txtDescription.Text = $"{ml.場次}：{ml.概要}";
            txtInfo.Text = $"{ml.日期} {ml.座位} {ml.票種}";
            txtNavi.Text = $"{index+1}/{list.Count}";
        }

        private void ShowImage()
        {
            //movieImage.Source = Application.Current.Properties["ImgSource"].ToString();

            Uri u =null;

            try
            {
                u = new Uri(list[index].urlIma.ToString());
                //u = new Uri("Nothing");
            }
            catch { u = null; } ;

            if (u == null)
            {
                movieImage.Source = "errorlarge.jpg";
            }
            else
            {
                movieImage.Source = new UriImageSource  //store in Cache
                {
                    Uri = u,
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(2, 0, 0, 0)
                };
            }
        }

        private void btnsClicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn == btnH)
            {
                Navigation.PopToRootAsync();
            }
            else if (btn == btnP && index > 0)
            {
                index--;
                mp.index = index;
                mp.ChangeSliderValueFromPageQ(index);
            }
            else if (btn == btnN && index < list.Count - 1) {
                index++;
                mp.ChangeSliderValueFromPageQ(index);
            }
            
            ShowImage();
            ShowWords();
            CheckBtnVisable();
        }
        private void CheckBtnVisable()
        {
            btnP.IsEnabled = btnN.IsEnabled = true;
            if(index==0) btnP.IsEnabled = false;
            else if(index == list.Count-1) btnN.IsEnabled = false;
        }

        private async void btnCart(object sender, EventArgs e)
        {
            C票券 item = list[index];
            bool result = await DisplayAlert("訂票確認", $"請確認以下內容是否正確：" +
                $"\r\n{item.日期}的「{item.場次}」" +
                $"\r\n座位 {item.座位} ({item.票種})", $"我要訂票", $"不訂票");
            if (result)
            {
                mp.ReserveTicket(list[index]);
                await Navigation.PopToRootAsync();
            }
            
        }
    }
}