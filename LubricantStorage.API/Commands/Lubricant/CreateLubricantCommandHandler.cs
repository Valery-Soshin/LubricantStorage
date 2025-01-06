using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using LubricantStorage.Core;

namespace LubricantStorage.API.Commands
{
    public class CreateLubricantCommandHandler : IRequestHandler<CreateLubricantCommand>
    {
        private readonly IMongoCollection<Lubricant> _lubricantCollection;

        public CreateLubricantCommandHandler(IOptions<DatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var database = client.GetDatabase(options.Value.DatabaseName);
            _lubricantCollection = database.GetCollection<Lubricant>(options.Value.LubricantsCollectionName);
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
