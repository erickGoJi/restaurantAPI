using MediatR;
using restaurant_api.Domain;
using restaurant_api.Infrastructure.Persistence;

namespace restaurant_api.Features.Role.Commands
{
    public class CreateRoleCommand : IRequest
    {
        public Guid id { get; set; }
        public string role_name { get; set; }
    }
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly restaurant_dbContext _context;

        public CreateRoleCommandHandler(restaurant_dbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Cat_Role()
            {
                role_name = request.role_name,
                id = request.id
            };

            _context.Cat_Roles.Add(newProduct);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
