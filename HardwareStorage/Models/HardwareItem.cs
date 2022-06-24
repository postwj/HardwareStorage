namespace HardwareStorage.Models
{
    public class HardwareItem
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string? Vendor { get; set; }
        public string? Description { get; set; }
        public HardWareGroup Group { get; set; }
    }
}
