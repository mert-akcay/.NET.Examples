using AdminTemplate.Models.Entities.Abstracts;

namespace AdminTemplate.Models.Entities;

public class Category : BaseEntity<int>
{
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public IList<Product> Products { get; set; }
}
