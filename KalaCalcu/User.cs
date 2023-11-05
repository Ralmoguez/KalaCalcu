using SQLite;

namespace KalaCalcu
{
    public class User
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
    }
}
