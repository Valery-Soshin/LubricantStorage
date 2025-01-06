using MediatR;
using LubricantStorage.Core;

namespace LubricantStorage.API.Queris
{
    public class GetLubricantByIdQuery : IRequest<Lubricant>
    {
        public string Id { get; set; }
    }
}