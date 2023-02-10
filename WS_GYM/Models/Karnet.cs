namespace WS_GYM.Models
{
    public class Karnet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool Active
        {
            get => DateTime.Now>= Start && DateTime.Now<= End;
        }
    }
}
