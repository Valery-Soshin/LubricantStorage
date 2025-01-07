using MediatR;
using MongoDB.Driver;
using LubricantStorage.API.Models;

namespace LubricantStorage.API.Application.Lubricants.Commands
{
    public class CreateLubricantCommandHandler : IRequestHandler<CreateLubricantCommand>
    {
        private readonly IMongoCollection<Lubricant> _lubricantCollection;

        public CreateLubricantCommandHandler(IMongoCollection<Lubricant> lubricantCollection)
        {
            _lubricantCollection = lubricantCollection;
        }

        public async Task Handle(CreateLubricantCommand request, CancellationToken cancellationToken)
        {
            var lubricant = new Lubricant()
            {
                Name = request.Name
            };

            await _lubricantCollection.InsertOneAsync(lubricant, cancellationToken: cancellationToken);
        }
    }
}