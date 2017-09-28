namespace FoodDelivery.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float BonusCash { get; set; }
    }
}