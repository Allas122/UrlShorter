namespace URLShorter.Services.ServiceLayerExceptions;

public class EntityNotFound : ServiceLayerException
{
    public EntityNotFound(string message) : base(message)
    {
    }
}