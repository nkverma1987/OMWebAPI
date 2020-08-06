namespace OrderManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
    }

    public class OrderLink
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductClassification { get; set; }
        public int AccountNumber { get; set; }
    }
}
