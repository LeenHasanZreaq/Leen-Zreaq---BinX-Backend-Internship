// using Microsoft.AspNetCore.Mvc;

// namespace ErrorHandlingApi.Controllers;

// [ApiController]
// [Route("api/test")]
// public class TestController : ControllerBase
// {
//     [HttpGet("success")]
//     public IActionResult Success()
//     {
//         return Ok(new
//         {
//             message = "Everything is working!"
//         });
//     }

//     [HttpGet("error")]
//     public IActionResult Error()
//     {
//         throw new InvalidOperationException(
//             "This is a test exception.");
//     }
// }