namespace ElectionCommission.Models
{
    public class Constituency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateDetail State { get; set; }
    }
}
