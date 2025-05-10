namespace Domain.Common;

public class AggregateRoot<Tid> : Entity<Tid> where Tid : notnull
{

    protected AggregateRoot(Tid id) : base(id)
    {
    }
    protected AggregateRoot()
    {

    }
    //public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    //public void ClearDomainEvents() => _domainEvents.Clear();
    //METODO PARA GENERAR UN EVENTO DE DOMINIO
    //AGREGAR UN EVENTO DE DOMINIO A LA LISTA
    //ESTE METODO ACEPTA UN DOMAINEVENT ARGUMENT (CUALQUIER CLASE QUE HEREDE IDOMAIN EVENT) EJEM => lineCreated :IDomainEvent

}
