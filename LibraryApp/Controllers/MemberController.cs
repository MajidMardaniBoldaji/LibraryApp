using LibraryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public readonly MemberService _MemberService;
        public MemberController(MemberService memberController)
        {
            _MemberService = memberController;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_MemberService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add (AddMemberVm memberVm)
        {
            return Ok (await(_MemberService.Add(memberVm)));    

        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id,string fullName)
        {
            return Ok(await (_MemberService.UpdateName(Id,fullName)));
        }
    }
}
