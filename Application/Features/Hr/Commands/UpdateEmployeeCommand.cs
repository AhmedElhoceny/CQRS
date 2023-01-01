using Application.Contexts;
using Domain.Hr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Hr.Commands
{
    public class UpdateEmployeeCommand : IRequest<HrEmployee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, HrEmployee>
        {
            private readonly IHrContext _hrContext;

            public UpdateEmployeeCommandHandler(IHrContext hrContext)
            {
                _hrContext = hrContext;
            }
            public async Task<HrEmployee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var searchedEmployee = await _hrContext.HrEmployees.FindAsync(request.Id);

                if (searchedEmployee == null)
                    return new HrEmployee();

                searchedEmployee.Phone = request.Phone;
                searchedEmployee.Address = request.Address;
                searchedEmployee.Name = request.Name;

                _hrContext.HrEmployees.Update(searchedEmployee);
                await _hrContext.SaveChanges();

                return searchedEmployee;
            }
        }
    }
}
