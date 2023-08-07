using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grocery_Management.Api.Controllers
{
    public class RegisterController : MainController
    {
        private readonly ILoginService _registerService;

        public RegisterController(ILoginService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(LoginViewModel requestData)
        {
            var result = await _registerService.InsertAsync(requestData);
            return Ok(result);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetA(int userId)
        {
            return Ok(await _registerService.GetAAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _registerService.GetAllAsync());
        }

        [HttpPut("userId")]
        public async Task<IActionResult> Update(int userId, LoginViewModel requestData)
        {
            return Ok(await _registerService.UpdateAsync(userId, requestData));
        }

        [HttpDelete("userId")]
        public async Task<IActionResult> Delete(int userId)
        {
            return Ok(await _registerService.DeleteAsync(userId));
        }
    }
}
