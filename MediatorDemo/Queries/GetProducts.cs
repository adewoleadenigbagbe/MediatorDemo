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
    public static class GetProducts
    {
        public class Query : IRequest<Result>
        {

        }

        public class Result
        {
            public IEnumerable<Product> Products { get; set; }
        }

        public class Handler : IRequestHandler<GetProducts.Query, GetProducts.Result>
        {
            private readonly FakeDataStore _fakeDataStore;
            public Handler(FakeDataStore fakeDataStore)
            {
                _fakeDataStore = fakeDataStore;
            }
            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _fakeDataStore.GetAllProducts();
                var result = new Result
                {
                    Products = products
                };

                return result;
            }
        }
    }
}
