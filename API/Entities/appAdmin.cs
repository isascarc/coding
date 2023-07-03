namespace API.Entities
{
    public class AppAdmin
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Create { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string City { get; set; }
        public string Country { get; set; }
    }
}