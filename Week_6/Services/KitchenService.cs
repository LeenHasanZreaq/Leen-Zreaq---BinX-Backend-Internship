using MyWebProject.DTOs;

public class KitchenService : IKitchenService
{
    private readonly IKitchenRepository _repository;

    public KitchenService(IKitchenRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<KitchenTicketResponse>>
        GetKitchenTicketsAsync()
    {
        var tickets = await _repository.GetAllAsync();

        return tickets.Select(t => new KitchenTicketResponse
        {
            Id = t.Id,
            OrderId = t.OrderId,
            Status = t.Status
        });
    }

    public async Task<KitchenTicketResponse?>
        GetKitchenTicketByIdAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);

        if (ticket == null)
            return null;

        return new KitchenTicketResponse
        {
            Id = ticket.Id,
            OrderId = ticket.OrderId,
            Status = ticket.Status
        };
    }

    public async Task<IEnumerable<KitchenTicketResponse>>
        GetKitchenTicketsByStatusAsync(string status)
    {
        var tickets = await _repository.GetAllAsync();

        return tickets
            .Where(t =>
                t.Status.Equals(
                    status,
                    StringComparison.OrdinalIgnoreCase))
            .Select(t => new KitchenTicketResponse
            {
                Id = t.Id,
                OrderId = t.OrderId,
                Status = t.Status
            });
    }

    public async Task<KitchenTicketResponse?>
        UpdateKitchenStatusAsync(
            int id,
            UpdateKitchenStatusRequest request)
    {
        var ticket = await _repository.GetByIdAsync(id);

        if (ticket == null)
            return null;

        ticket.Status = request.Status;

        await _repository.UpdateAsync(ticket);

        return new KitchenTicketResponse
        {
            Id = ticket.Id,
            OrderId = ticket.OrderId,
            Status = ticket.Status
        };
    }

    public async Task<bool> DeleteKitchenTicketAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);

        if (ticket == null)
            return false;

        await _repository.DeleteAsync(ticket);

        return true;
    }

    public async Task<KitchenStatistics>
        GetKitchenStatisticsAsync()
    {
        var tickets = await _repository.GetAllAsync();

        return new KitchenStatistics
        {
            TotalTickets = tickets.Count(),

            PendingTickets = tickets.Count(t =>
                t.Status.Equals(
                    "Pending",
                    StringComparison.OrdinalIgnoreCase)),

            PreparingTickets = tickets.Count(t =>
                t.Status.Equals(
                    "Preparing",
                    StringComparison.OrdinalIgnoreCase)),

            ReadyTickets = tickets.Count(t =>
                t.Status.Equals(
                    "Ready",
                    StringComparison.OrdinalIgnoreCase)),

            CompletedTickets = tickets.Count(t =>
                t.Status.Equals(
                    "Completed",
                    StringComparison.OrdinalIgnoreCase))
        };
    }
}