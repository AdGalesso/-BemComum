using System;

namespace br.com.bemcomum.domain.Entities
{
    public class Address : BaseEntity<Guid>
    {
        public string Street { get; set; }

        public string District { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public void UpdateGeolocation()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Number, Street, District, City, State, ZipCode);
        }
    }
}
