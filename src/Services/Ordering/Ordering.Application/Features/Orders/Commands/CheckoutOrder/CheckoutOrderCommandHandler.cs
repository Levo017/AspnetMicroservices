using MediatR;

namespace Ordering.Usecase.Features.Orders.Commands.CheckoutOrder
{
    internal class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        public Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
