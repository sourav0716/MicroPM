using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity
{
    public class Workflow : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<WorkflowStep>? Steps { get; set; }

        public Workflow(string name)
        {
            Name = name;
        }
    }
}