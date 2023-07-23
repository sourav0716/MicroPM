namespace ProjectService.Domain.Common;
public enum Role
{
    ProjectOwner,
    ProjectAdmin,
    User
}
public enum ProjectStatus
{
    draft,
    approved,
    rejected,
    deleted
}