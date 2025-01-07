using LubricantStorage.API.Models;
using MediatR;

namespace LubricantStorage.API.Application.Lubricants.Queris
{
    public class GetAllLubricantQuery : IRequest<IEnumerable<Lubricant>>
    {

    }
}