using MediatR;

namespace LubricantStorage.API.Commands
{
    public class CreateLubricantCommand : IRequest
    {
        public string Name { get; set; }
    }
}