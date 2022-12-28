using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.Common.Security;
using System.Data;

namespace PartnerPortal.Application.TodoLists.Commands
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public record PurgeTodoListsCommand : IRequest;

    public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeTodoListsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.RemoveRange(_context.TodoLists);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
