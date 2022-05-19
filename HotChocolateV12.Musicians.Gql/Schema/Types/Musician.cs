namespace HotChocolateV12.Musicians.Gql.Schema.Types;

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
