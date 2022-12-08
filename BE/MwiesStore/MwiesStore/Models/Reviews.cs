namespace MwiesStore.Models
{
    public class Reviews
    {   
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }     
        public int User_id { get; set; }
        public int Product_id { get; set; }
    }
}
