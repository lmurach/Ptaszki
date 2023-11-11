namespace Ptaszki.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime LastGather { get; set; }
        public int SeedCount { get; set; }

        public ICollection<Bird> Birds { get; set; }
    }
}