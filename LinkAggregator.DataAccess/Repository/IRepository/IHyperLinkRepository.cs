using LinkAggregation.Models;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IHyperLinkRepository : IRepository<HyperLink>
    {
        void Update(HyperLink hyperLink);
        void Save();
        void IsValidHyperLinks(IEnumerable<HyperLink> hyperLinks);
    }
}
