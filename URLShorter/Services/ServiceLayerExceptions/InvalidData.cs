namespace URLShorter.Services.ServiceLayerExceptions;

public class InvalidData : ServiceLayerException
{
    public InvalidData(string message) : base(message)
    {
    }
}