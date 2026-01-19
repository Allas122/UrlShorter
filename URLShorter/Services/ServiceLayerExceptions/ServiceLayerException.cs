namespace URLShorter.Services.ServiceLayerExceptions;

public class ServiceLayerException : Exception
{
    public ServiceLayerException(string message) : base(message)
    {
    }
}