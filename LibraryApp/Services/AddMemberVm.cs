namespace LibraryApp.Services
{
    public class AddMemberVm
    {
        //FullName, BirthDate, PhoneNumber, Address, Email, AddDate, UpdateDate
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }



    }
}
