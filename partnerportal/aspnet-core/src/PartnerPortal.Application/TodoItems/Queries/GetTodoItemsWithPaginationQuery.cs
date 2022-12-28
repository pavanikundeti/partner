using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Application.Common.Models;

namespace PartnerPortal.Application.TodoItems.Queries
{
    public record GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
    {
        public int ListId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Where(x => x.ListId == request.ListId)
                .OrderBy(x => x.Title)
                .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
