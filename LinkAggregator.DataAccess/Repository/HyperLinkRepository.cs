using LinkAggregation.Models;
using LinkAggregator.DataAccess.DBContext;
using LinkAggregator.DataAccess.Repository.IRepository;

namespace LinkAggregator.DataAccess.Repository
{
    public class HyperLinkRepository : Repository<HyperLink>, IHyperLinkRepository
    {
        private readonly ApplicationDbContext _db;
        public HyperLinkRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public string RenderHashCode(HyperLink hyperLink)
        {
            string hashCode = (hyperLink.ValidFrom.ToString() + hyperLink.Id.ToString())
                .Replace(':', '(').Replace('/', '^').Replace(' ', '!');
            return hashCode;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(HyperLink hyperLink)
        {
            var hyperLinkFromDb = _db.HyperLink.FirstOrDefault(u => u.Id == hyperLink.Id);
            hyperLinkFromDb.Name = hyperLink.Name;
            hyperLinkFromDb.Url = hyperLink.Url;
            hyperLinkFromDb.HashCode = hyperLink.HashCode;
            hyperLinkFromDb.ValidFrom = hyperLink.ValidFrom;
            hyperLinkFromDb.ValidTo = hyperLink.ValidTo;
        }

        public void IsValidHyperLinks(IEnumerable<HyperLink> hyperLinks)
        {
            bool HasChanges = false;

            foreach (var hyperLink in hyperLinks)
            {
                if (hyperLink.IsValid)
                {
                    if ((DateTime.Now - hyperLink.ValidTo > TimeSpan.Zero))
                    {
                        if (!HasChanges)
                        {
                            HasChanges = true;
                        }
                        hyperLink.IsValid = false;
                    }
                    else continue;
                }
                else continue;
            }

            if (HasChanges)
            {
                this.Save();
            }

        }
    }
}
