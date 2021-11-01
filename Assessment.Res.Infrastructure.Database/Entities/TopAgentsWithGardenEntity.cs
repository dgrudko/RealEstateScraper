using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Res.Infrastructure.Database.Entities
{
    [Table("TopAgentsWithGarden")]
    public class TopAgentsWithGardenEntity
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public AgentEntity Agent { get; set; }
        public int? NumberOfProperties { get; set; }
    }
}
