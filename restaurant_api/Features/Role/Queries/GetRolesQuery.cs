using MediatR;
using Microsoft.EntityFrameworkCore;
using restaurant_api.Features.Role.Model;
using restaurant_api.Infrastructure.Persistence;

namespace restaurant_api.Features.Role.Queries
{
    public class GetRolesQuery : IRequest<List<CatRolesQueryReponse>>
    {
    }
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<CatRolesQueryReponse>>
    {
        private readonly restaurant_dbContext _context;

        public GetRolesQueryHandler(restaurant_dbContext context)
        {
            _context = context;
        }

        public Task<List<CatRolesQueryReponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken) =>
            _context.Cat_Roles
                .AsNoTracking()
                .Select(s => new CatRolesQueryReponse
                {
                    id = s.id,
                    role_name = s.role_name,
                })
                .ToListAsync();
    }
}
