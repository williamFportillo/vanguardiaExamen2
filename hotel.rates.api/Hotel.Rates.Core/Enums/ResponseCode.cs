namespace Hotel.Rates.Core.Enums
{
    public enum ResponseCode
    {
        Success,
        Error,
        InternalServerError = 500,
        NotFound,
        BadRequest,
    }
}
