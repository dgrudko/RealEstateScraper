namespace Assessment.Res.Core.Contracts
{
    public class PropertyOffer
    {
        public int Id { get; set; }
        public string VendorId { get; set; }
        public int AgentId { get; set; }
        public int AgentVendorId { get; set; }
        public string AgentName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool WithGarden { get; set; }
    }
}
