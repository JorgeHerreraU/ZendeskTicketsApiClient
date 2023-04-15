using ZenTicketsLib.Models.Brands;
using ZenTicketsLib.Models.Groups;
using ZenTicketsLib.Models.Organizations;
using ZenTicketsLib.Models.TicketForms;
using ZenTicketsLib.Models.Tickets;
using ZenTicketsLib.Models.Users;

namespace ZenTicketsLib.Services;

public class TicketFormSpecification : ISpecification<TicketForm>
{
    private readonly long? _formId;

    public TicketFormSpecification(long? formId)
    {
        _formId = formId;
    }

    public bool IsSatisfiedBy(TicketForm ticketForm)
    {
        return ticketForm.Id == _formId;
    }
}

public class GroupSpecification : ISpecification<Group>
{
    private readonly long? _groupId;

    public GroupSpecification(long? groupId)
    {
        _groupId = groupId;
    }

    public bool IsSatisfiedBy(Group group)
    {
        return group.Id == _groupId;
    }
}

public class OrganizationSpecification : ISpecification<Organization>
{
    private readonly long? _organizationId;

    public OrganizationSpecification(long? organizationId)
    {
        _organizationId = organizationId;
    }

    public bool IsSatisfiedBy(Organization organization)
    {
        return organization.Id == _organizationId;
    }
}

public class BrandSpecification : ISpecification<Brand>
{
    private readonly long? _brandId;

    public BrandSpecification(long? brandId)
    {
        _brandId = brandId;
    }

    public bool IsSatisfiedBy(Brand brand)
    {
        return brand.Id == _brandId;
    }
}

public class RelatedUserSpecification : ISpecification<User>
{
    private readonly Ticket _ticket;

    public RelatedUserSpecification(Ticket ticket)
    {
        _ticket = ticket;
    }

    public bool IsSatisfiedBy(User user)
    {
        return user.Id == _ticket.AssigneeId ||
               user.Id == _ticket.RequesterId ||
               user.Id == _ticket.SubmitterId;
    }
}