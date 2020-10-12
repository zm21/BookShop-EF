namespace BLL
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public int UserTypeId { get; set; }
    }
}
