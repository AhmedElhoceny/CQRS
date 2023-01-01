using Application.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Hr.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IHrContext _hrContext;
            public DeleteEmployeeCommandHandler(IHrContext hrContext)
            {
                _hrContext = hrContext;
            }
            public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var searchedEmployee = await _hrContext.HrEmployees.FindAsync(request.Id);

                if (searchedEmployee == null)
                    return default;

                _hrContext.HrEmployees.Remove(searchedEmployee);
                await _hrContext.SaveChanges();

                return request.Id;
            }
        }
    }
}
