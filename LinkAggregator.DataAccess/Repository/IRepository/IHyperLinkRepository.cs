using LinkAggregation.Models;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IHyperLinkRepository : IRepository<HyperLink>
    {
        void Update(HyperLink hyperLink);
        void Save();
        string RenderHashCode(HyperLink hyperLink);
    }
}
