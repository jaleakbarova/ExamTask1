using BizLand.DAL;

namespace BizLand.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _appDbContext;

        public LayoutService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Dictionary<string, string> GetService()
        {
            return _appDbContext.Settings.ToList().ToDictionary(x=>x.Key, x=>x.Value);
        }
    }
}
