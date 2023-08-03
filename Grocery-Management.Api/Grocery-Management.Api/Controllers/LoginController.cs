using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grocery_Management.Api.Controllers
{
    public class LoginController : MainController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(LoginViewModel request)
        {
            var result = await _loginService.InsertAsync(request);
            return Ok(result);
        }

        [HttpGet("userId")]
        public async Task <IActionResult> GetA(int userId)
        {
            return Ok (await _loginService.GetAAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _loginService.GetAllAsync());
        }

        [HttpPut("userId")]
        public async Task<IActionResult> Update(int userId,  LoginViewModel request)
        {
            return Ok(await _loginService.UpdateAsync(userId, request));
        }

        [HttpDelete("userId")]
        public async Task<IActionResult> Delete(int userId)
        {
            return Ok(await _loginService.DeleteAsync(userId));
        }
    }
}
