using MediatR;
using MobileAppApi.Models;

namespace MobileAppApi.Data
{
    namespace CoffeeHandler
    {
        using MobileAppApi.Requests.CoffeeRequest;
        public class GetCoffeeIdHandler : IRequestHandler<GetCoffeeIdRequest, Coffee>
        {
            public Task<Coffee> Handle(GetCoffeeIdRequest request, CancellationToken cancellationToken)
            {
                Coffee out_ = new();
                foreach(Coffee coffee in CoffeeBuffer.Instance.get_coffee_list())
                {
                    if (coffee.id == request.id)
                    {
                        out_ = coffee;
                        break;
                    }
                }
                return Task.FromResult(out_);
            }
        }
        public class GetCoffeeListHandler : IRequestHandler<GetCoffeeListRequest, List<Coffee>>
        {
            public Task<List<Coffee>> Handle(GetCoffeeListRequest request, CancellationToken cancellationToken)
            {
                return Task.FromResult(CoffeeBuffer.Instance.get_coffee_list());
            }
        }
    }

}
