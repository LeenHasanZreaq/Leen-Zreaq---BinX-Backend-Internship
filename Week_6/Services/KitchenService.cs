public class KitchenService : IKitchenService
{
    private readonly IKitchenRepository _repository;

    public KitchenService(IKitchenRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<KitchenTicketResponse>> GetKitchenTicketsAsync()
    {
        var tickets = await _repository.GetAllAsync();
        return tickets.Select(t => new KitchenTicketResponse
        {
            Id = t.Id,
            OrderId = t.OrderId,
            Status = t.Status
        });
    }

    public async Task<KitchenTicketResponse> UpdateKitchenStatusAsync(int id, UpdateKitchenStatusRequest request)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket == null) throw new Exception("Ticket not found");

        ticket.Status = request.Status;
        await _repository.UpdateAsync(ticket);

        return new KitchenTicketResponse { Id = ticket.Id, OrderId = ticket.OrderId, Status = ticket.Status };
    }
}
