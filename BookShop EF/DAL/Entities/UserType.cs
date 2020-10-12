﻿namespace DAL
{
    using System.Collections.Generic;

    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}