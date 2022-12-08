namespace MwiesStore.Models
{
    public class Bills
    {       
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
    }
}
