namespace TheLibrary.Core.DTOs.Response
{
    public class Response<T>
    {
        public Response()
        {
            StatusCode = 200;
            AnErrorOcurred = false;
            ErrorMessage = null;
        }

        public int StatusCode { get; set; }
        public bool AnErrorOcurred { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
