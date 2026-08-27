public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserResponse?> GetUserAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserResponse { Id = user.Id, Username = user.Username, Email = user.Email, Role = user.Role };
    }

    public async Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest request)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");

        user.Username = request.Username;
        user.Email = request.Email;
        user.Role = request.Role;

        await _repository.UpdateAsync(user);

        return new UserResponse { Id = user.Id, Username = user.Username, Email = user.Email, Role = user.Role };
    }
}
