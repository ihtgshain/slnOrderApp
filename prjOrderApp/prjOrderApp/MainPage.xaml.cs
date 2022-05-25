using prjOrderApp.model;
using prjOrderApp.ViewModel;
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
        public C票券ViewModel vModel;
        
        public MainPage()
        {
            InitializeComponent();
            Application.Current.Properties["page"] = this;
            vModel = new C票券ViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
            ShowDate();
        }
        private void SliderValueChanged(object sender, ValueChangedEventArgs e) => vModel.SliderValueChanged();
        private void BtnQuery(object sender, EventArgs e) => vModel.btnQuery();
        private void BtnList(object sender, EventArgs e) => vModel.btnList();
        private void BtnArrow(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn == btnF) vModel.btnArrow('F');
            else if (btn == btnP) vModel.btnArrow('P');
            else if (btn == btnN) vModel.btnArrow('N');
            else if (btn == btnL) vModel.btnArrow('L');
        }
        public void ShowDate()
        {
            if (vModel.list.Count == 0)
            {
                txtDate.Text = txtID.Text = txtSeat.Text = txt場次.Text = txt票種.Text = "抱歉票已售完";
                txtDate.TextColor = txtID.TextColor = txtSeat.TextColor = txt場次.TextColor = txt票種.TextColor = Color.Red;
            }
            else
            {
                txtDate.Text = vModel.current.日期;
                txtID.Text = vModel.current.票券編號.ToString();
                txtSeat.Text = vModel.current.座位;
                txt場次.Text = vModel.current.場次;
                txt票種.Text = vModel.current.票種;
                txtDate.TextColor = txtID.TextColor = txtSeat.TextColor = txt場次.TextColor = txt票種.TextColor = Color.Black;
            }
        }
    }
}
