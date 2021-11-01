using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Res.Infrastructure.Database.Entities
{
    [Table("Agents")]
    public class AgentEntity
    {
        public int Id { get; set; }
        public string VendorId { get; set; }
        public string Name { get; set; }
    }
}
