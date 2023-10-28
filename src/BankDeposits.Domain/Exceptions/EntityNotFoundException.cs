namespace BankDeposits.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entity) : base($"Entity {entity} not found")
    {
    }
}