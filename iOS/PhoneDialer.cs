using System;
using Foundation;
using RecallRosterXamarin.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace RecallRosterXamarin.iOS
{
	public class PhoneDialer : IDialer
	{

		public PhoneDialer()
		{

		}

		public void Dial(string number)
		{
			
			UIApplication.SharedApplication.OpenUrl(new NSUrl(@"tel://" + number));

		}
	}
}

