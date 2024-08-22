using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(long id);
    Task<List<User>> GetAllAsync();
    Task<long> AddAsync(User user);
    Task<long> UpdateAsync(User user);
    Task<bool> DeleteAsync(long id);
}