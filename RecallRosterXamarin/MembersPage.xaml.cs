using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace RecallRosterXamarin
{

	public partial class MembersPage : ContentPage
	{

		public MembersPage(IList<MemberVM> names)

		{
			//var names = JsonConvert.DeserializeObject<IList<MemberVM>>(memberData);
			InitializeComponent();
			ListView1.ItemsSource = names;
			NavigationPage.SetHasBackButton(this, false);
			this.Title = "List Of Members";

		}


		public async void OnPhoneTapped(object sender, EventArgs e)
		{
			//https://forums.xamarin.com/discussion/44152/get-id-button-in-a-click-event
			Button callbtn = (Button)sender;
			var number = callbtn.Text.ToString();

			if (await this.DisplayAlert(
							 "Dial a Number",
							 "Call " + number + " ?",
							 "Yes",
							 "No"))
			{
				var dialer = DependencyService.Get<IDialer>();

				if (dialer != null)
				{
					dialer.Dial(number);
				}
			}
		}

		//Note
		//https://forums.xamarin.com/discussion/73163/close-application-ios-from-a-button
		//Was going to close App but against Apple Policy to close within app

	}
}
