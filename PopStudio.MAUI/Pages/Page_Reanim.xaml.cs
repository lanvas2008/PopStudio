using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace PopStudio.MAUI
{
	public partial class Page_Reanim : ContentPage
	{
		public Page_Reanim()
		{
			InitializeComponent();
            CB_CMode.Items.Clear();
            CB_CMode.Items.Add("Windows,MacOS");
            CB_CMode.Items.Add("Android,iOS,Bada,BlackBerry");
            CB_CMode.Items.Add("Android,iOS");
            CB_CMode.Items.Add("WindowsPhone");
            CB_CMode.Items.Add("PS3,PSV,Xbox360");
            CB_CMode.Items.Add("AndroidTV");
            CB_CMode.SelectedIndex = 0;
        }

        private void ToggleButton_Checked(object sender, EventArgs e)
        {
            if (((Switch)sender).IsToggled)
            {
                text1.Text = "请填写被编码的文件路径";
                text2.Text = "请填写编码所得文件存放路径";
                text3.Text = "请选择编码模式";
                string temp = textbox1.Text;
                textbox1.Text = textbox2.Text;
                textbox2.Text = temp;
            }
            else
            {
                text1.Text = "请填写被解码的文件路径";
                text2.Text = "请填写解码所得文件存放路径";
                text3.Text = "请选择解码模式";
                string temp = textbox1.Text;
                textbox1.Text = textbox2.Text;
                textbox2.Text = temp;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.IsEnabled = false;
            text4.Text = "执行中......";
            bool mode = TB_Mode.IsToggled;
            string inFile = textbox1.Text;
            string outFile = textbox2.Text;
            int cmode = CB_CMode.SelectedIndex;
            new Thread(new ThreadStart(() =>
            {
                string err = null;
                try
                {
                    if (!File.Exists(inFile))
                    {
                        throw new FileNotFoundException("文件" + inFile + "不存在！");
                    }
                    if (mode)
                    {
                        API.EncodeReanim(inFile, outFile, cmode);
                    }
                    else
                    {
                        API.DecodeReanim(inFile, outFile, cmode);
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (err == null)
                    {
                        text4.Text = "执行完成";
                    }
                    else
                    {
                        text4.Text = "执行异常：" + err;
                    }
                    b.IsEnabled = true;
                });
            }))
            { IsBackground = true }.Start();
        }
    }
}