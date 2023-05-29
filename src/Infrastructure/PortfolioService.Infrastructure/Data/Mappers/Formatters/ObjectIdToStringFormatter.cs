using AutoMapper;
using MongoDB.Bson;

namespace PortfolioService.Infrastructure.Data.Mappers.Formatters
{
    public class ObjectIdToStringFormatter : IValueConverter<ObjectId, string>
    {
        public string Convert(ObjectId sourceMember, ResolutionContext context)
        {
            return sourceMember.ToString();
        }
    }
}
