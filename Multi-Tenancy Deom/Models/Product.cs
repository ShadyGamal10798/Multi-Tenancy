﻿namespace Multi_Tenancy_Deom.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Rate { get; set; }
    }
}
