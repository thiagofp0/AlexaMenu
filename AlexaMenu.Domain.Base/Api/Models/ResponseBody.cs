namespace AlexaMenu.Domain.Base.Api.Models
{
    public class ResponseBody<T>
    {
        public T Data { get; private set; }
        public ResponseBody(T data)
        {
            Data = data;
        }
        public static implicit operator ResponseBody<T>(T data)
        {
            return new ResponseBody<T>(data);
        }
    }
}
