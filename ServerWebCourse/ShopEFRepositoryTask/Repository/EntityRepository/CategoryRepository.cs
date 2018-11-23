using System.Data.Entity;

namespace ShopEFRepositoryTask
{
    internal class CategoryRepository : BaseEfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }
    }
}
