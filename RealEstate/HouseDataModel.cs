namespace RealEstate
{
    public class HouseDataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public decimal Price { get; set; }
        public Distribution[] Distributions { get; set; }
        public decimal BuildUpArea { get; set; }
        public decimal Yard { get; set; }

        public class Distribution
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Section[] Sections { get; set; }

            public class Section
            {
                public string Name { get; set; }
                public decimal Area { get; set; }
            }            
        }        
    }    
}
