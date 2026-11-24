namespace Whistleblowing.Services.Shared
{
    public partial class SharedService
    {
        WhistleblowingDbContext _dbContext;

        public SharedService(WhistleblowingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
