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
        public List<C票券> list已訂票 = new List<C票券>();
        public int index = 0;
        
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            LoadDate();
            ShowDate();
            //Application.Current.Properties["list"] = list;
            Application.Current.Properties["page"] = this;
        }

        private void LoadDate()
        {
            list.Add(new C票券() { 場次 = "奇異博士Ⅱ", 座位 = "8E", 日期 = "2022/06/05 12:00",
                票券編號 = 1, 票種 = "敬老票", 概要 = "失控的多元宇宙", 尚未訂票 = true, EN= "Dr. Strange 2",
                urlIma = "https://www.niusnews.com/upload/imgs/default/202202_Haru/DS2/doctorstrangeinthemultiverseofmadness_teaser2_printed_1-sht_v4_lg.jpeg" });
            list.Add(new C票券() { 場次 = "鋼鐵人Ⅲ", 座位 = "9C", 日期 = "2022/06/06 13:00", 
                票券編號 = 2, 票種 = "學生票", 概要= "覺醒的東尼史塔克！",尚未訂票 = true, EN= "Iron Man 3",
                urlIma="https://miro.medium.com/max/800/0*8jiWoPKSAxGT-u_b"});
            list.Add(new C票券() { 場次 = "復仇者聯盟Ⅳ", 座位 = "5D", 日期 = "2022/06/07 08:30", 
                票券編號 = 3, 票種 = "一般票", 概要= "終局之戰",尚未訂票 = true,EN= "Avengers 4",
                urlIma = "https://cdn2.ettoday.net/images/4017/d4017811.jpg"});
            list.Add(new C票券() { 場次 = "奇異博士Ⅱ", 座位 = "12A", 日期 = "2022/06/08 12:00", 
                票券編號 = 4, 票種 = "兒童票", 概要= "失控的多元宇宙",尚未訂票 = true,EN= "Dr Strange 2",
                urlIma = "https://www.niusnews.com/upload/imgs/default/202202_Haru/DS2/doctorstrangeinthemultiverseofmadness_teaser2_printed_1-sht_v4_lg.jpeg"});
            list.Add(new C票券() { 場次 = "鋼鐵人Ⅲ", 座位 = "13F", 日期 = "2022/06/09 13:00", 
                票券編號 = 5, 票種 = "特惠票", 概要= "覺醒的東尼史塔克！",尚未訂票 = true,EN= "Iron Man 3",
                urlIma = "https://miro.medium.com/max/800/0*8jiWoPKSAxGT-u_b"});
            list.Add(new C票券() { 場次 = "復仇者聯盟Ⅳ", 座位 = "6B", 日期 = "2022/06/10 08:30", 
                票券編號 = 6, 票種 = "早鳥票", 概要= "終局之戰",尚未訂票 = true,EN= "Avengers 4",
                urlIma="https://cdn2.ettoday.net/images/4017/d4017811.jpg"});

            SetNumOfTickets();
        }

        private void SetNumOfTickets()
        {
            if(list.Count <2)
            {
                naviSlider.IsEnabled = false;
                naviSlider.Maximum = 1;
            }
            else
            {
                naviSlider.Maximum = list.Count - 1;
            }

            txt共幾張票.Text = list.Count==0 ? "抱歉票已售完" : $" 共{list.Count}筆資料";
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
            if (index < 0 || index >= list.Count) return;
            ShowDate();
        }

        public void ChangeSliderValueFromPageQ(int i)
        {
            naviSlider.Value= i;
        }

        public void ReserveTicket(C票券 item)
        {
            item.尚未訂票 = false;
            list已訂票.Add(item);
            list.Remove(item);
            AdjustIndex();
        }
        public void RefundTicket(C票券 item)
        {
            item.尚未訂票 = true;
            list.Add(item);
            list已訂票.Remove(item);
            AdjustIndex();
        }

        public void AdjustIndex()
        {
            SetNumOfTickets();
            index = 0;
            naviSlider.Value = index;
            ShowDate();
        }

        private void ShowDate()
        {
            if (list.Count == 0) 
            {
                txtDate.Text = txtID.Text= txtSeat.Text = txt場次.Text = txt票種.Text = "抱歉票已售完";
                txtDate.TextColor = txtID.TextColor = txtSeat.TextColor = txt場次.TextColor = txt票種.TextColor = Color.Red;
            }
            else
            {
                txtDate.Text = list[index].日期;
                txtID.Text = list[index].票券編號.ToString();
                txtSeat.Text = list[index].座位;
                txt場次.Text = list[index].場次;
                txt票種.Text = list[index].票種;
                txtDate.TextColor = txtID.TextColor = txtSeat.TextColor = txt場次.TextColor = txt票種.TextColor = Color.Black;
            }
        }

        private void BtnQuery(object sender, EventArgs e)
        {
            if(list.Count == 0) return;
            Navigation.PushAsync(new PageQ(index));
        }

        private void BtnList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageL());
        }
    }
}
