using MediatR;
using restaurant_api.Features.Role.Model;
using restaurant_api.Infrastructure.Persistence;

namespace restaurant_api.Features.Role.Queries
{
    public class GetRoleQuery : IRequest<CatRoleQueryReponse>
    {
        public Guid RoleId { get; set; }
    }
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, CatRoleQueryReponse>
    {
        private readonly restaurant_dbContext _context;

        public GetRoleQueryHandler(restaurant_dbContext context)
        {
            _context = context;
        }
        public async Task<CatRoleQueryReponse> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Cat_Roles.FindAsync(request.RoleId);

            return new CatRoleQueryReponse
            {
                id = role.id,
                role_name = role.role_name
            };
        }
    }

}
