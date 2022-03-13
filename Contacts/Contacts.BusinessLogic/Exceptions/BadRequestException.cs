namespace Contacts.BusinessLogic.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {

        }

        public BadRequestException(string name) : base(name)
        {

        }

        public BadRequestException(string name, Exception exception) : base(name, exception)
        {

        }
    }


}
