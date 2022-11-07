namespace DgiiTest.Api.Controllers.Response
{
    public class BusinessResponse<T>
    {
        public BusinessResponse(T values)
        {
            Result = values;
        }
        public T Result { get; set; }
    }
}
