using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository;

public class UserRepository(DbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
    
}