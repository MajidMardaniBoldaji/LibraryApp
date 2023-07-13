using LibraryApp.Data;
using LibraryApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
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
            newMember.AddDate = vm.AddDate;
            newMember.BirthDate = vm.BirthDate;
            newMember.Address = vm.Address;
            newMember.Email = vm.Email;
            newMember.PhoneNumber = vm.PhoneNumber;
            _db.Members.Add(newMember);
            return await _db.SaveChangesAsync();

        }
        [HttpDelete]
        public async Task<int> Remove(int Id)
        {
            var member =await  _db.Members.FirstOrDefaultAsync(c => c.Id == Id);
            if (member != null)
            {
                _db.Members.Remove(member);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int>UpdateName(int Id,string name)
        {
            var memberItem=await _db.Members.FirstOrDefaultAsync(m=>m.Id == Id);
            if(memberItem != null) 
            {
                memberItem.FullName=name;
                return await _db.SaveChangesAsync();    

            }

            return 0;
        }
    }
}
