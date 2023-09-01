namespace ProductApi.Data.Repositories;

public class BaseRepository : IDisposable
{
    protected readonly ApiDbContext _context;

    public BaseRepository(ApiDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
