using HotChocolateV12.Bands.Gql.Schema.Types;

namespace HotChocolateV12.Bands.Gql.Repositories;

public interface IBandsRepository
{
    Task<IQueryable<Band>> GetBands();
    Task<Band?> GetBand(string key);
}

public class BandsRepository : IBandsRepository
{
    public List<Band> bands = new List<Band>
        {
            Band.Create("Phish", Genre.Rock, "https://phish.com"),
            Band.Create("Dave Matthews Band", Genre.Alternative_Indie, "https://davematthewsband.com"),
        };

    public async Task<Band?> GetBand(string key)
    {
        await Task.Delay(200);
        return bands.Where(x => x.Key == key).FirstOrDefault();
    }

    public async Task<IQueryable<Band>> GetBands()
    {
        await Task.Delay(200);
        return bands.AsQueryable();
    }
}