namespace MyWebProject.Exceptions;


public static class GlobalExceptionHandler
{
    public static (int StatusCode, string ErrorMessage) Handle(Exception ex)
    {
        return ex switch
        {
            NotFoundException => (404, ex.Message),
            BadRequestException => (400, ex.Message),
            UnauthorizedException => (401, ex.Message),
            ForbiddenException => (403, ex.Message),
            _ => (500, "An unexpected error occurred")
        };
    }
}
