	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;
	using ModernHttpClient;
	using Newtonsoft.Json;
	using Xamarin.Forms;

	namespace RecallRosterXamarin
	{
	

		public partial class RecallRosterXamarinPage : ContentPage
		{
		
			public RecallRosterXamarinPage()
			{
				InitializeComponent();
				this.Title = "Recall Roster";
			}

			public async void Post(object sender, EventArgs e)
			{

			SpinnerIcon.IsVisible = true;
			SpinnerIcon.IsRunning = true;
			SpinnerIcon.IsEnabled = true;
			LoginBtn.IsVisible = false;

				var un = UserName.Text.ToString().Trim();
				var pw = PassWord.Text.ToString().Trim();

			using (var client = new HttpClient(new NativeMessageHandler()))
			{

				var values = new Dictionary<string, string>
					{
						{"UserName", un},
						{"PassWord", pw}
					};

				var content = new FormUrlEncodedContent(values);
				client.BaseAddress = new Uri(@"https://afrctools.afrc.af.mil/RRAPI/api/users/login/");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.PostAsync(client.BaseAddress, content);
				var responseNumber = response.StatusCode.ToString();

				var responseString = await response.Content.ReadAsStringAsync();
				if (responseNumber == "OK")
				{
					var names = JsonConvert.DeserializeObject<IList<MemberVM>>(responseString);

					var MembersPage = new MembersPage(names);
					MembersPage.BindingContext = names;
					await Navigation.PushAsync(MembersPage);
					SpinnerIcon.IsVisible = false;
					SpinnerIcon.IsRunning = false;
					SpinnerIcon.IsEnabled = false;
					LoginBtn.IsVisible = true;
				}
				else {
					await Navigation.PushAsync(new ErrorMembersPage());
					SpinnerIcon.IsVisible = false;
					SpinnerIcon.IsRunning = false;
					SpinnerIcon.IsEnabled = false;
					LoginBtn.IsVisible = true;
				}
			}
		}
	}
}
