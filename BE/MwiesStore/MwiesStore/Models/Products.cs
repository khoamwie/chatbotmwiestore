namespace MwiesStore.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Kg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Category_id { get; set; }
        public int Brand_id { get; set; }

    }
}
