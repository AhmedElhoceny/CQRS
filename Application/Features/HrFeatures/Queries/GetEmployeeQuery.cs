using Application.Contexts;
using Domain.Hr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Hr.Queries
{
    public class GetEmployeeQuery : IRequest<HrEmployee>
    {
        public int Id { get; set; }

        public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, HrEmployee>
        {
            private readonly IHrContext _hrContext;
            public GetEmployeeQueryHandler(IHrContext hrContext)
            {
                _hrContext = hrContext;
            }
            public async Task<HrEmployee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
            {
                var searchedEmployee = await _hrContext.HrEmployees.FindAsync(request.Id);

                if (searchedEmployee == null)
                    return new HrEmployee();

                return searchedEmployee;
            }
        }
    }
}
