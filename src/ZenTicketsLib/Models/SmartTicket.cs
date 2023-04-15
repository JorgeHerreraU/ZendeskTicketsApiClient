using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Brands;
using ZenTicketsLib.Models.Groups;
using ZenTicketsLib.Models.Organizations;
using ZenTicketsLib.Models.TicketForms;
using ZenTicketsLib.Models.Tickets;
using ZenTicketsLib.Models.Users;

namespace ZenTicketsLib.Models;

public record SmartTicket : Ticket
{
    public SmartTicket(Ticket ticket, Group? group, Organization? organization, Brand? brand, TicketForm? ticketForm,
        IEnumerable<User> users)
        : base(ticket)
    {
        Group = group;
        Organization = organization;
        Brand = brand;
        TicketForm = ticketForm;
        Users = users;
    }

    [JsonPropertyName("group")]
    public Group? Group { get; init; }

    [JsonPropertyName("organization")]
    public Organization? Organization { get; init; }

    [JsonPropertyName("brand")]
    public Brand? Brand { get; init; }

    [JsonPropertyName("ticket_form")]
    public TicketForm? TicketForm { get; init; }

    [JsonPropertyName("users")]
    public IEnumerable<User> Users { get; init; }
}