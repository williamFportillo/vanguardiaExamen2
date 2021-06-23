using Hotel.Rates.Core.Enums;

namespace Hotel.Rates.Core
{
    public class ServiceResult<T>
    {
        public ServiceResult(ResponseCode responseCode, string error, T result)
        {
            ResponseCode = responseCode;
            Error = error;
            Result = result;
        }
        public ResponseCode ResponseCode { get; }

        public string Error { get; }

        public T Result { get; }

        public static ServiceResult<T> ErrorResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.Error, error, default(T));
        }

        public static ServiceResult<T> BadRequestResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.BadRequest, error, default(T));
        }

        public static ServiceResult<T> SuccessResult(T entity)
        {
            return new ServiceResult<T>(ResponseCode.Success, string.Empty, entity);
        }
    }
}
