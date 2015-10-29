namespace br.com.bemcomum.domain.Entities
{
    public class Donor : User
    {
        public string Document { get; set; }

        public Address Address { get; set; }
    }
}
