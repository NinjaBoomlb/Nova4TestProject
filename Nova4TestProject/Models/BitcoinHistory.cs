namespace Nova4TestProject.Models
{
    public class BitcoinHistory 
    { 
            public int Id { get; set; }
            public string Source { get; set; }
            public decimal Price { get; set; }
            public DateTime Timestamp { get; set; }
    }
}
