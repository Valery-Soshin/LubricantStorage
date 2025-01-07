using MediatR;

namespace LubricantStorage.API.Application.Lubricants.Commands
{
    public class CreateLubricantCommand : IRequest
    {
        public string Name { get; set; }
    }
}