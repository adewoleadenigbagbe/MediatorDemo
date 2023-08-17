using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatorDemo.DataStore;
using MediatorDemo.Models;

using MediatR;

namespace MediatorDemo.Commands
{
    public static class CreateProduct
    {
        public class Command : IRequest<Result>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class Result
        {
            public int Status { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly FakeDataStore _fakeDataStore;
            public Handler(FakeDataStore fakeDataStore)
            {
                _fakeDataStore = fakeDataStore;
            }
            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Id = request.Id,
                    Name = request.Name
                };

                
                await _fakeDataStore.AddProduct(product);

                var result = new Result
                {
                    Status = 1
                };

                return result;

            }
        }
    }
}
