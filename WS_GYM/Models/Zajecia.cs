namespace WS_GYM.Models
{
    public class Zajecia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ICollection<ZajeciaUser>? ZajeciaUsers { get; set; }
    }
}
