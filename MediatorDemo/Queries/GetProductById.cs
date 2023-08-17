using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatorDemo.DataStore;
using MediatorDemo.Models;

using MediatR;

namespace MediatorDemo.Queries
{
    public static class GetProductById
    {
        public class Query : IRequest<Result>
        {
            public int Id { get; set; }
        }

        public class Result 
        {
            public Product Product { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly FakeDataStore _fakeDataStore;
            public Handler(FakeDataStore fakeDataStore)
            {
                _fakeDataStore = fakeDataStore;
            }
            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _fakeDataStore.GetProduct(request.Id);
                var result = new Result
                {
                    Product = product
                };

                return result;
            }
        }
    }
}
