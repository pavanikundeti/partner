using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace PartnerPortal.Application.TodoItems.Commands
{
    public record CreateTodoItemCommand : IRequest<int>
    {
        public int ListId { get; init; }

        public string? Title { get; init; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
