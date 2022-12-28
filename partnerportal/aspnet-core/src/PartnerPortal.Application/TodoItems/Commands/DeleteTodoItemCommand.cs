using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Events;

namespace PartnerPortal.Application.TodoItems.Commands
{
    public record DeleteTodoItemCommand(int Id) : IRequest;

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _context.TodoItems.Remove(entity);

            entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
