using HotChocolateV12.Musicians.Gql.Schema.Types;

namespace HotChocolateV12.Musicians.Gql.Repositories;

public interface IMusicianRepository
{
    Task<IQueryable<Musician>> AllMusicians();
    Task<IEnumerable<Musician>> GetMusiciansByBandKeyAsync(string bandKey);
}

public class MusicianRepository : IMusicianRepository
{
    List<Musician> musicians = new List<Musician>
    {
        Musician.Create("Trey Anastasio", "phish")
            .WithInstruments(Instrument.Guitar, Instrument.Vocals),
        Musician.Create("Jon Fishman", "phish")
            .WithInstruments(Instrument.Drums),
        Musician.Create("Mike Gordon", "phish")
            .WithInstruments(Instrument.BassGuitar),
        Musician.Create("Page McConnell", "phish")
            .WithInstruments(Instrument.Keyboard),

        Musician.Create("Dave Matthews", "davematthewsband")
            .WithInstruments(Instrument.Vocals, Instrument.Guitar),
        Musician.Create("Boyd Tinsley", "davematthewsband")
            .WithInstruments(Instrument.Violin),
        Musician.Create("Carter Beauford", "davematthewsband")
            .WithInstruments(Instrument.Drums),
        Musician.Create("Stefan Lessard", "davematthewsband")
            .WithInstruments(Instrument.BassGuitar),
        Musician.Create("Tim Reynolds", "davematthewsband")
            .WithInstruments(Instrument.Guitar),
        Musician.Create("Rashawn Ross", "davematthewsband")
            .WithInstruments(Instrument.Trumpet),
        Musician.Create("LeRoi Moore", "davematthewsband")
            .WithInstruments(Instrument.Saxophone),
    };

    public async Task<IQueryable<Musician>> AllMusicians()
    {
        await Task.Delay(800);
        return musicians.AsQueryable();
    }

    public async Task<IEnumerable<Musician>> GetMusiciansByBandKeyAsync(string bandKey)
    {
        await Task.Delay(800);
        return musicians.Where(x => x.BandKey == bandKey);
    }
}
