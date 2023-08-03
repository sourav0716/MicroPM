using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity;
public class Component : AuditableEntity
{
    public Guid Id { get; private set; }
    public Details Details { get; private set; }

    public Component(Details details)
    {
        Id = Guid.NewGuid();
        Details = details;
    }

    public void UpdateDetails(Details details,Guid id)
    {
        Id=id;
        Details =  details;
    }
}