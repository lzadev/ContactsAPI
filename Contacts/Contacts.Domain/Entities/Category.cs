namespace Contacts.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
