using MediatR;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record DeleteTodoListCommand(int Id) : IRequest;

    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            _context.TodoLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
