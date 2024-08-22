using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<long> AddAsync(User user)
    {
        return await _unitOfWork.Users.AddAsync(user);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _unitOfWork.Users.DeleteAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _unitOfWork.Users.GetWithFilterAsync(_ => true);
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _unitOfWork.Users.GetById(id);
    }

    public async Task<long> UpdateAsync(User user)
    {
        return await _unitOfWork.Users.UpdateAsync(user);
    }
}
