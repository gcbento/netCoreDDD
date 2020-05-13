namespace JogosAPI.Application.Models.Response
{
    public class ResponseModel<T>
    {
        public bool Success
        {
            get
            {
                return Data != null;
            }
        }
        public T Data { get; set; }
        public string[] Messages { get; set; }

        public static ResponseModel<T> GetResponse(T result)
        {
            var response = new ResponseModel<T>();
            response.Data = result;
            return response;
        }

        public static ResponseModel<T> GetResponse(string[] errors)
        {
            var response = new ResponseModel<T>();
            response.Messages = errors;
            return response;
        }

        public static ResponseModel<T> GetErrorResponse()
        {
            var response = new ResponseModel<T>();
            response.Messages = new string[] { "Ocorreu um erro ao executar" };
            return response;
        }
    }
}
