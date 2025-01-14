using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using PopStudio.GUI.Languages;

namespace PopStudio.MAUI
{
	public partial class Page_HomePage : ContentPage
	{
		public Page_HomePage()
		{
			InitializeComponent();
			Title = MAUIStr.Obj.HomePage_Title;
			label_begin.Text = MAUIStr.Obj.HomePage_Begin;
			label_function.Text = MAUIStr.Obj.HomePage_Function;
			label_agreement.Text = MAUIStr.Obj.HomePage_Agreement;
			AndroidPermission.IsVisible = !Permission.HiddenPermission();
			label_permission.Text = MAUIStr.Obj.HomePage_Permission;
			button_permission.Text = MAUIStr.Obj.HomePage_PermissionAsk;
			label_ver.Text = string.Format(MAUIStr.Obj.HomePage_Version, Str.Obj.AppVersion);
			label_author_string.Text = MAUIStr.Obj.HomePage_Author_String;
			label_author.Text = MAUIStr.Obj.HomePage_Author;
			label_thanks_string.Text = MAUIStr.Obj.HomePage_Thanks_String;
			label_thanks.Text = MAUIStr.Obj.HomePage_Thanks;
			label_qqgroup_string.Text = MAUIStr.Obj.HomePage_QQGroup_String;
			label_qqgroup.Text = MAUIStr.Obj.HomePage_QQGroup;
			label_course_string.Text = MAUIStr.Obj.HomePage_Course_String;
			label_course.Text = MAUIStr.Obj.HomePage_Course;
			label_appnewnotice_string.Text = MAUIStr.Obj.HomePage_AppNewNotice_String;
			label_appnewnotice.Text = MAUIStr.Obj.HomePage_AppNewNotice;
			
		}

        private async void button_permission_Clicked(object sender, EventArgs e)
        {
			await this.CheckAndRequestPermissionAsync();
		}
    }
}