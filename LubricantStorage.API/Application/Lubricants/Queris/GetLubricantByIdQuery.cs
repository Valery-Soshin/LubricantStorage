using MediatR;
using LubricantStorage.API.Models;

namespace LubricantStorage.API.Application.Lubricants.Queris
{
    public class GetLubricantByIdQuery : IRequest<Lubricant>
    {
        public string Id { get; set; }
    }
}