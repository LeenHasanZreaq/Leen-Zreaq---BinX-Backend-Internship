// using Microsoft.AspNetCore.Mvc;

// namespace ErrorHandlingApi.Middleware;

// public class GlobalExceptionMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly ILogger<GlobalExceptionMiddleware> _logger;

//     public GlobalExceptionMiddleware(
//         RequestDelegate next,
//         ILogger<GlobalExceptionMiddleware> logger)
//     {
//         _next = next;
//         _logger = logger;
//     }

//     public async Task InvokeAsync(HttpContext context)
//     {
//         try
//         {
//             await _next(context);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(
//                 ex,
//                 "Unhandled exception occurred while processing {Method} {Path}",
//                 context.Request.Method,
//                 context.Request.Path);

//             context.Response.StatusCode = 500;
//             context.Response.ContentType = "application/problem+json";

//             var problem = new ProblemDetails
//             {
//                 Title = "An unexpected error occurred.",
//                 Status = 500,
//                 Detail = "Something went wrong. Please try again later.",
//                 Instance = context.Request.Path
//             };

//             await context.Response.WriteAsJsonAsync(problem);
//         }
//     }
// }