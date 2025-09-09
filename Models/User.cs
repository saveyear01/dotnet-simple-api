namespace AuthApi.Models
{
    public class User
    {
        public int Id { get; set; }               // Primary key
        public string Username { get; set; } = ""; // Required
        public string Password { get; set; } = ""; // Will store hashed password
    }
}
