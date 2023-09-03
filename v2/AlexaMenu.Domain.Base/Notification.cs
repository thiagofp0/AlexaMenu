namespace AlexaMenu.Domain.Base
{
    public class Notification
    {
        public string Message { get; }
        public Notification(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return Message;
        }

        public static implicit operator Notification(string message)
        {
            return new Notification(message);
        }

        public static implicit operator string(Notification notification)
        {
            return notification.Message;
        }
    }
}