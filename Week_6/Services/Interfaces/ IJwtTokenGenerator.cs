using MyWebProject.Models;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
