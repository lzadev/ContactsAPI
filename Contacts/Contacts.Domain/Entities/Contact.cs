namespace Contacts.Domain.Entities
{
    public class Contact : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
