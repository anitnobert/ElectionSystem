namespace ElectionCommission.Models
{
    public class Commissioner
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string SecretToken { get; set; } = "1234-5678";
    }
}
