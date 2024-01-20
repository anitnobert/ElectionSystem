namespace ElectionCommission.Models
{
    public class Voter
    {
        public string Id { get; set; }

        public string Name { get; set; }    

        public string Address { get; set; }
        public bool Approved { get; set; } 
    }
}
