namespace BLL.Validation;

public class HMSException : Exception
{
    public HMSException()
    {
    }

    public HMSException(string message)
        : base(message)
    {
    }

    public HMSException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}