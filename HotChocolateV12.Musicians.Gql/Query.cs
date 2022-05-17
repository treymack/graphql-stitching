namespace HotChocolateV12.Musicians.Gql;

public class Query
{
    public IQueryable<Musician> GetMusicians()
    {
        return (new List<Musician>{
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

    }).AsQueryable();
    }
}

public class Musician
{
    public Musician(string key, string name, string bandKey)
    {
        Key = key;
        Name = name;
        BandKey = bandKey;
    }

    [ID]
    public string Key { get; }
    public string Name { get; }
    [ID("Band")]
    public string BandKey { get; }
    public IEnumerable<Instrument> Instruments { get; private set; } = new List<Instrument>();

    public static Musician Create(string name, string bandKey) =>
        new Musician(key: name.Replace(" ", "").ToLower(), name, bandKey);

    [GraphQLIgnore]
    public Musician WithInstruments(params Instrument[] instruments)
    {
        this.Instruments = instruments;
        return this;
    }
}

public enum Instrument
{
    Vocals,
    Guitar,
    BassGuitar,
    Drums,
    Keyboard,
    Violin,
    Trumpet,
    Saxophone,
}
