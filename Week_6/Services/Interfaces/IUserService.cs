public interface IUserService
{
    Task<UserResponse?> GetUserAsync(int id);
    Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest request);
}
