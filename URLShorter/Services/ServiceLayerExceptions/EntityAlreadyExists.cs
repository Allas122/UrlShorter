namespace URLShorter.Services.ServiceLayerExceptions;

public class EntityAlreadyExists : ServiceLayerException
{
    public EntityAlreadyExists(string message) : base(message)
    {
    }
}