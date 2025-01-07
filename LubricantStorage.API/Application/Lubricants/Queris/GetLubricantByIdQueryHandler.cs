using LubricantStorage.API.Models;
using MediatR;
using MongoDB.Driver;

namespace LubricantStorage.API.Application.Lubricants.Queris
{
    public class GetLubricantByIdQueryHandler : IRequestHandler<GetLubricantByIdQuery, Lubricant>
    {
        private readonly IMongoCollection<Lubricant> _lubricantCollection;

        public GetLubricantByIdQueryHandler(IMongoCollection<Lubricant> lubricantCollection)
        {
            _lubricantCollection = lubricantCollection;
        }

        public async Task<Lubricant> Handle(GetLubricantByIdQuery request, CancellationToken cancellationToken)
        {
            return await _lubricantCollection.Find(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}