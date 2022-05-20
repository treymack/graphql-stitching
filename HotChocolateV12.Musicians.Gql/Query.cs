using HotChocolateV12.Musicians.Gql.Repositories;
using HotChocolateV12.Musicians.Gql.Schema.Types;

namespace HotChocolateV12.Musicians.Gql;

public class Query
{
    public Task<IQueryable<Musician>> GetMusicians(
        [Service] IMusicianRepository musicianRepository
    )
    {
        return musicianRepository.AllMusicians();
    }

    public Task<IEnumerable<Musician>> GetMusiciansByBandKeyAsync(
        [Service] IMusicianRepository musicianRepository,
        [ID] string bandKey
    ) => musicianRepository.GetMusiciansByBandKeyAsync(bandKey);
}
