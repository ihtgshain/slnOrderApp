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
        List<C票券> list= new List<C票券>();
        int _i = 0;
        public MainPage()
        {
            InitializeComponent();
            LoadDate();
        }

        private void LoadDate()
        {
            list.Add(new C票券() { 場次 = "奇異博士2", 座位 = "8E", 日期 = "2022/06/05 12:00:00", 票券編號 = 1, 票種 = "敬老票" });
            list.Add(new C票券() { 場次 = "阿凡達Ⅱ", 座位 = "9C", 日期 = "2022/06/05 13:00:00", 票券編號 = 2, 票種 = "學生票" });
            list.Add(new C票券() { 場次 = "永恒族", 座位 = "5D", 日期 = "2022/06/05 08:30:00", 票券編號 = 3, 票種 = "一般票" });
        }

        private void btnArrow(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn == btnF) _i = 0;
            else if(btn == btnP && _i > 0) _i--;
            else if (btn == btnN && _i < list.Count-1) _i++;
            else if(btn == btnL) _i=list.Count-1;

            txtDate.Text = list[_i].日期;
            txtID.Text = list[_i].票券編號.ToString();
            txtSeat.Text = list[_i].座位;
            txt場次.Text = list[_i].場次;
            txt票種.Text = list[_i].票種;
        }
    }
}
