using DAL.Repository;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork.Interfaces;
using DAL.Data;

namespace DAL.UnitOfWork;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork, IDisposable
{
    private readonly AppDbContext dbContext = dbContext;
    private IUserRepository? userRepository;

    public IUserRepository Users => userRepository ??= new UserRepository(dbContext);

    public void Save()
    {
        dbContext.SaveChanges();
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
                dbContext.Dispose();
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}