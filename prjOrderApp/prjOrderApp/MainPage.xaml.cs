using prjOrderApp.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace prjOrderApp
{
    public partial class MainPage : ContentPage
    {
        public List<C票券> list= new List<C票券>();
        public int index = 0;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            LoadDate();
            ShowDate();
            Application.Current.Properties["list"] = list;
        }

        private void LoadDate()
        {
            list.Add(new C票券() { 場次 = "奇異博士Ⅱ", 座位 = "8E", 日期 = "2022/06/05 12:00:00", 
                票券編號 = 1, 票種 = "敬老票" , 概要= "失控的多元宇宙",
                uriImg= "https://www.niusnews.com/upload/imgs/default/202202_Haru/DS2/doctorstrangeinthemultiverseofmadness_teaser2_printed_1-sht_v4_lg.jpeg"});
            list.Add(new C票券() { 場次 = "鋼鐵人Ⅲ", 座位 = "9C", 日期 = "2022/06/06 13:00:00", 
                票券編號 = 2, 票種 = "學生票", 概要= "覺醒的東尼史塔克！",
                uriImg="https://miro.medium.com/max/800/0*8jiWoPKSAxGT-u_b"});
            list.Add(new C票券() { 場次 = "復仇者聯盟Ⅳ", 座位 = "5D", 日期 = "2022/06/07 08:30:00", 
                票券編號 = 3, 票種 = "一般票", 概要= "終局之戰",
                uriImg = "https://cdn2.ettoday.net/images/4017/d4017811.jpg"});
            list.Add(new C票券() { 場次 = "奇異博士Ⅱ", 座位 = "12A", 日期 = "2022/06/08 12:00:00", 
                票券編號 = 4, 票種 = "敬老票", 概要= "失控的多元宇宙",
            uriImg = "https://www.niusnews.com/upload/imgs/default/202202_Haru/DS2/doctorstrangeinthemultiverseofmadness_teaser2_printed_1-sht_v4_lg.jpeg"});
            list.Add(new C票券() { 場次 = "鋼鐵人Ⅲ", 座位 = "13F", 日期 = "2022/06/09 13:00:00", 
                票券編號 = 5, 票種 = "學生票", 概要= "覺醒的東尼史塔克！",
                uriImg = "https://miro.medium.com/max/800/0*8jiWoPKSAxGT-u_b"});
            list.Add(new C票券() { 場次 = "復仇者聯盟Ⅳ", 座位 = "6B", 日期 = "2022/06/10 08:30:00", 
                票券編號 = 6, 票種 = "一般票", 概要= "終局之戰",
                uriImg="https://cdn2.ettoday.net/images/4017/d4017811.jpg"});
            
            naviSlider.Maximum = list.Count-1;
            txt共幾張票.Text = $"{list.Count} 張票";
        }

        private void BtnArrow(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn == btnF) index = 0;
            else if(btn == btnP && index > 0) index--;
            else if (btn == btnN && index < list.Count-1) index++;
            else if(btn == btnL) index=list.Count-1;
            naviSlider.Value= index;
        }

        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            index =(int)naviSlider.Value;
            ShowDate();
        }

        private void ShowDate()
        {
            txtDate.Text = list[index].日期;
            txtID.Text = list[index].票券編號.ToString();
            txtSeat.Text = list[index].座位;
            txt場次.Text = list[index].場次;
            txt票種.Text = list[index].票種;
        }

        private void BtnQuery(object sender, EventArgs e)
        {
            Application.Current.Properties["moveList"] = list[index].uriImg;
            Navigation.PushAsync(new PageQ(index));
        }

    }
}
