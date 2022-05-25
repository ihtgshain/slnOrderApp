using prjOrderApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace prjOrderApp.ViewModel
{
    public class C票券ViewModel
    {
        MainPage mp;
        public List<C票券> list = new List<C票券>();
        public List<C票券> list已訂票 = new List<C票券>();
        public int index = 0;

        public C票券ViewModel()
        {
            mp = Application.Current.Properties["page"] as MainPage;
            LoadDate();
        }
        public C票券 current
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
        public List<C票券> all
        {
            get { return list; }
            set { list = value; }
        }


        public void btnArrow(char a)
        {
            if (a == 'F')
            {
                index = 0;
            }
            else if (a == 'P')
            {
                if (index > 0) index--;
            }
            else if (a == 'N')
            {
                if(index < list.Count-1)  index++;
            }
            else if(a =='L')
            {
                index = list.Count - 1;
            }
       
            mp.naviSlider.Value = index;
            mp.ShowDate();
        }

        public void btnQuery()
        {
            if (list.Count == 0) return;
            mp.Navigation.PushAsync(new PageQ(index));
        }

        public void btnList()
        {
            mp.Navigation.PushAsync(new PageL());
        }

        public void SliderValueChanged()
        {
            index = (int)mp.naviSlider.Value;
            if (index < 0) index = 0;
            else if(index > list.Count-1) index=list.Count-1;
            mp.ShowDate();
        }

        public void ChangeSliderValueFromPageQ(int i)
        {
            mp.naviSlider.Value = i;
        }

        public void ReserveTicket(C票券 item)
        {
            item.尚未訂票 = false;
            list已訂票.Add(item);
            var temp = list已訂票.OrderBy(x => x.票券編號).ToList();
            list已訂票.Clear();
            list已訂票 = temp;
            list.Remove(item);
            AdjustIndex();
        }
        public void RefundTicket(C票券 item)
        {
            item.尚未訂票 = true;
            list.Add(item);
            var temp = list.OrderBy(x => x.票券編號).ToList();
            list.Clear();
            list = temp;
            list已訂票.Remove(item);
            AdjustIndex();
        }

        public void AdjustIndex()
        {
            if(index==list.Count) index= list.Count==0? 0:list.Count-1;
            SetNumOfTickets();
            mp.naviSlider.Value = index;
            mp.ShowDate();
        }

        public void LoadDate()
        {
            list.Add(new C票券()
            {
                場次 = "復仇者聯盟Ⅲ",座位 = "5D",日期 = "2022/06/07 08:30",票券編號 = 1,票種 = "一般票",
                概要 = "無限之戰",尚未訂票 = true,EN = "Avengers 3",
                urlIma = "https://img.toy-people.com/member/161582346794.jpg"});
            list.Add(new C票券()
            {
                場次 = "奇異博士",座位 = "8E",日期 = "2022/06/05 12:00",票券編號 = 2,票種 = "敬老票",
                概要 = "一個外科醫師的故事",尚未訂票 = true,EN = "Dr. Strange 1",
                urlIma = "https://upload.wikimedia.org/wikipedia/zh/8/8d/Doctor_Strange_2016_Poster.jpg"
            });
            list.Add(new C票券()
            {
                場次 = "鋼鐵人Ⅱ",座位 = "9C",日期 = "2022/06/06 13:00",票券編號 = 3,票種 = "學生票",
                概要 = "失意的東尼史塔克！",尚未訂票 = true,EN = "Iron Man 2",
                urlIma = "https://char.tw/wp-content/uploads/2017/08/1503017756-aabe0dc8f74b52800c15bda357fe04d9.jpg"
            });
            list.Add(new C票券()
            {
                場次 = "復仇者聯盟Ⅳ",座位 = "6B",日期 = "2022/06/10 08:30",票券編號 = 4,票種 = "早鳥票",
                概要 = "終局之戰",尚未訂票 = true,EN = "Avengers 4",
                urlIma = "https://cdn2.ettoday.net/images/4017/d4017811.jpg"
            });
            list.Add(new C票券()
            {
                場次 = "奇異博士Ⅱ",座位 = "12A",日期 = "2022/06/08 12:00",票券編號 = 5,票種 = "兒童票",
                概要 = "失控的多元宇宙",尚未訂票 = true,EN = "Dr Strange 2",
                urlIma = "https://www.niusnews.com/upload/imgs/default/202202_Haru/DS2/doctorstrangeinthemultiverseofmadness_teaser2_printed_1-sht_v4_lg.jpeg"
            });
            list.Add(new C票券()
            {
                場次 = "鋼鐵人Ⅲ",座位 = "13F",日期 = "2022/06/09 13:00",票券編號 = 6,票種 = "特惠票",
                概要 = "覺醒的東尼史塔克！",尚未訂票 = true,EN = "Iron Man 3",
                urlIma = "https://miro.medium.com/max/800/0*8jiWoPKSAxGT-u_b"
            });
            SetNumOfTickets();
        }
        private void SetNumOfTickets()
        {
            if (list.Count <= 1)
            {
                mp.naviSlider.IsEnabled = false;
                mp.naviSlider.Maximum = 1;
            }
            else
            {
                mp.naviSlider.Maximum = list.Count - 1;
            }
            mp.txt共幾張票.Text = list.Count == 0 ? "抱歉票已售完" : $" 共{list.Count}筆資料";
        }
    }

}




    


