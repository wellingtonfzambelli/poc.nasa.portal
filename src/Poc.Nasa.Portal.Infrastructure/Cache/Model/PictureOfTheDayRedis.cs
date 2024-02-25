using Redis.OM.Modeling;

namespace Poc.Nasa.Portal.Infrastructure.Cache.Model;

[Document(StorageType = StorageType.Json)]
public sealed class PictureOfTheDayRedis
{
    [RedisIdField][Indexed] public Guid Id { get; set; }
    [Indexed] public string Copyright { get; set; }
    [Indexed] public DateTime PictureDate { get; set; }
    [Indexed] public string Explanation { get; set; }
    [Indexed] public string HdUrl { get; set; }
    [Indexed] public string Title { get; set; }
    [Indexed] public string Url { get; set; }
}