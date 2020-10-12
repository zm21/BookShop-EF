namespace DAL
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Reservs = new HashSet<Reserv>();
            this.Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswdHash { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<Reserv> Reservs { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}