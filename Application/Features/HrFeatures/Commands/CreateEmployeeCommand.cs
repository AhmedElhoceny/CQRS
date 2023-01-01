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
    public class CreateEmployeeCommand : IRequest<HrEmployee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, HrEmployee>
        {
            private IHrContext _hrContext { get; }
            public CreateEmployeeCommandHandler(IHrContext hrContext)
            {
                _hrContext = hrContext;
            }
            public async Task<HrEmployee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var newEmployee = new HrEmployee() { Address = request.Address , Name = request.Name , Phone = request.Phone };

                await _hrContext.HrEmployees.AddAsync(newEmployee);
                await _hrContext.SaveChanges();
                return newEmployee;
            }
        }
    }
}
