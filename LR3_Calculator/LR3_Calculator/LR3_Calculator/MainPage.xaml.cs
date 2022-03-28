using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LR3_Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Button_0.Clicked += Button_0_Clicked;
            Button_1.Clicked += Button_1_Clicked;
            Button_2.Clicked += Button_2_Clicked;
            Button_3.Clicked += Button_3_Clicked;
            Button_4.Clicked += Button_4_Clicked;
            Button_5.Clicked += Button_5_Clicked;
            Button_6.Clicked += Button_6_Clicked;
            Button_7.Clicked += Button_7_Clicked;
            Button_8.Clicked += Button_8_Clicked;
            Button_9.Clicked += Button_9_Clicked;
            Button_clear.Clicked += Button_clear_Clicked;
            Button_open.Clicked += Button_open_Clicked;
            Button_close.Clicked += Button_close_Clicked;
            Button_erase.Clicked += Button_erase_Clicked;
            Button_div.Clicked += Button_div_Clicked;
            Button_mul.Clicked += Button_mul_Clicked;
            Button_sub.Clicked += Button_sub_Clicked;
            Button_add.Clicked += Button_add_Clicked;
            Button_com.Clicked += Button_com_Clicked;
            Button_eq.Clicked += Button_eq_Clicked;


        }

        private void Button_eq_Clicked(object sender, EventArgs e)
        {
            List<object> list = CalculatorConverter.StringToList(Label_bot.Text);
            List<object> polandList = CalculatorConverter.ListToPolandList(list);
            double result = CalculatorConverter.CalculatePolandList(polandList);

            Label_top.Text = result.ToString();
        }

        private void Button_com_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += ",";
        }

        private void Button_add_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "+";
        }

        private void Button_sub_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "-";
        }

        private void Button_mul_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "*";
        }

        private void Button_div_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "/";
        }

        private void Button_erase_Clicked(object sender, EventArgs e)
        {
            string str = Label_bot.Text;
            if (str == null || str == "")
                return;
            str = str.Substring(0, str.Length - 1);
            Label_bot.Text = str;
        }

        private void Button_open_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "(";
        }

        private void Button_close_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += ")";
        }

        private void Button_clear_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text = "";
            Label_top.Text = "";
        }

        private void Button_0_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "0";
        }

        private void Button_1_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "1";
        }

        private void Button_2_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "2";
        }

        private void Button_3_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "3";
        }

        private void Button_4_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "4";
        }

        private void Button_5_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "5";
        }

        private void Button_6_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "6";
        }

        private void Button_7_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "7";
        }

        private void Button_8_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "8";
        }

        private void Button_9_Clicked(object sender, EventArgs e)
        {
            Label_bot.Text += "9";
        }
    }
}
