using AdminTemplate.Models.Entities.Abstracts;

namespace AdminTemplate.Models.Entities;

public class Product : BaseEntity<Guid>
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
