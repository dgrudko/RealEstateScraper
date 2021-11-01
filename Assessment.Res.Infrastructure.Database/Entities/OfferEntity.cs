using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Res.Infrastructure.Database.Entities
{
    [Table("Offers")]
    public class OfferEntity
    {
        public int Id { get; set; }
        public string VendorId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool WithGarden { get; set; }
        public int AgentId { get; set; }
        public AgentEntity Agent { get; set; }
    }
}
