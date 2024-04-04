namespace Applikation_med_API.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string OpenIDIssuer { get; set; }
        public string OpenIDSubject { get; set; }
        public string Name { get; set; }

        //public List<Product> Products { get; set; }
    }
}
