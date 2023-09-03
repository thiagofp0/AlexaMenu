using System.Runtime.Serialization;

namespace AlexaMenu.Domain.Base.Exceptions
{
    [Serializable]
    public class InvalidDomainStateException : Exception
    {
        public List<Notification> Notifications { get; private set; } = new();

        public InvalidDomainStateException(string message) : base(message)
        {
            Notifications.Add(message);
        }
        public InvalidDomainStateException(List<Notification> notifications)
        {
            Notifications = notifications;
        }
        protected InvalidDomainStateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
