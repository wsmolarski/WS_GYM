using System.ComponentModel.DataAnnotations;

namespace WS_GYM.Models
{
    public class Karnet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Ważny od:")]
        public DateTime Start { get; set; }
        [Display(Name = "Ważny do:")]
        public DateTime End { get; set; }

        public bool Active
        {
            get => DateTime.Now>= Start && DateTime.Now<= End;
        }
    }
}
