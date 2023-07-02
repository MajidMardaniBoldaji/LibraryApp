using LibraryApp.Data;
using LibraryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public class MemberService
    {
        private readonly AppDbContext _db;
        public MemberService(AppDbContext appDb)
        {
            _db = appDb;
        }
        public async Task<List<Member>> GetAll()
        {
            return await _db.Members.ToListAsync();
        }

        public async Task<int> Add(AddMemberVm vm)
        {
            var newMember = new Member();
            newMember.FullName = vm.FullName;
            newMember.AddDate = DateTime.Now;
            newMember.BirthDate = vm.BirthDate;
            newMember.Address = vm.Address;
            newMember.Email = vm.Email;
            newMember.PhoneNumber = vm.PhoneNumber;
            _db.Members.Add(newMember);
            return await _db.SaveChangesAsync();


        }
    }
}
