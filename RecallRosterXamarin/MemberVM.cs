using System;
namespace RecallRosterXamarin
{
	public class MemberVM
	{
		public MemberVM()
		{
			this.FirstName = String.Empty;
			this.LastName = String.Empty;
			this.TelephoneNumber = String.Empty;
			this.Address = String.Empty;
		}

		public MemberVM(MemberVM vm)
		{
			this.FirstName = vm.FirstName;
			this.LastName = vm.LastName;
			this.TelephoneNumber = vm.TelephoneNumber;
			this.Address = vm.Address;
		}
		public int MemberId 
		{ 
			get;
			set; 
		}
		public int UserId
		{
			get;
			set;
		}
		public string FirstName
		{
			get;
			set;
		}
		public string LastName
		{
			get;
			set;
		}
		public string TelephoneNumber
		{
			get;
			set;
		}
		public string Address
		{
			get;
			set;
		}
		public bool? isActive
		{
			get;
			set;
		}
	}
}
