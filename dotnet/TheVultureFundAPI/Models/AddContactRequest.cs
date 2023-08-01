namespace TheVultureFundAPI.Models
{
    public class AddContactRequest
    {
        public required string FullName { get; set; }
        public required string Position { get; set; }
        public required string Email { get; set; }
        public long Phone { get; set; }
        public required string Address { get; set; }
    }
}