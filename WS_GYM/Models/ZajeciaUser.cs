namespace WS_GYM.Models
{
    public class ZajeciaUser
    {
        public int Id { get; set; }
        public int ZajeciaId { get; set; }
        public string UserId { get; set; }

        public Zajecia? Zajecia { get; set; }

    }
}
