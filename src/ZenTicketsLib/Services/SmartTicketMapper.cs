using ZenTicketsLib.Models;
using ZenTicketsLib.Models.Tickets;
using ZenTicketsLib.Responses;

namespace ZenTicketsLib.Services;

public class SmartTicketMapper : ISmartTicketMapper
{
    public IEnumerable<SmartTicket> MapResponseToSmartTickets((SearchResponse, List<TicketField>) searchResult)
    {
        var (response, ticketFields) = searchResult;
        return response.Tickets.Select(ticket =>
        {
            var users = FilterAll(response.Users, new RelatedUserSpecification(ticket));
            var group = FilterOne(response.Groups, new GroupSpecification(ticket.GroupId));
            var organization = FilterOne(response.Organizations, new OrganizationSpecification(ticket.OrganizationId));
            var brand = FilterOne(response.Brands, new BrandSpecification(ticket.BrandId));
            var ticketForm = FilterOne(response.TicketForms, new TicketFormSpecification(ticket.FormId));
            AssignDetailsToCustomFields(ticket.CustomFields, ticketFields);
            return new SmartTicket(ticket, group, organization, brand, ticketForm, users);
        });
    }

    private static T? FilterOne<T>(IEnumerable<T> items, ISpecification<T> specification)
    {
        return items.FirstOrDefault(specification.IsSatisfiedBy);
    }

    private static IEnumerable<T> FilterAll<T>(IEnumerable<T> items, ISpecification<T> specification)
    {
        return items.Where(specification.IsSatisfiedBy);
    }

    private static void AssignDetailsToCustomFields(IEnumerable<CustomField> customFields,
        IReadOnlyCollection<TicketField> ticketFields)
    {
       
        foreach (var customField in customFields)
        {
            var field = ticketFields.FirstOrDefault(t => t.Id == customField.Id);
            var isAssignable = field != null && !string.IsNullOrEmpty(customField.Value);
            if (isAssignable) customField.Details = field;
        }
    }

}