using System.ComponentModel;

namespace HotChocolateV12.Bands.Gql;

public class Query
{
    public IQueryable<Band> GetBands()
    {
        return (new List<Band>
        {
            Band.Create("Phish", Genre.Rock, "https://phish.com"),
            Band.Create("Dave Matthews Band", Genre.Alternative_Indie, "https://davematthewsband.com"),
        }).AsQueryable();
    }
}

public class Band
{
    public Band(string key, string name, Genre genre, string siteUrl)
    {
        Key = key;
        Name = name;
        Genre = genre;
        SiteUrl = siteUrl;
    }

    [ID]
    public string Key { get; }
    public string Name { get; }
    public Genre Genre { get; }
    public string SiteUrl { get; }

    public static Band Create(string name, Genre genre, string siteUrl) =>
        new Band(key: name.Replace(" ", "").ToLower(), name, genre, siteUrl);
}

public enum Genre
{
    Rock,
    [Description("Alternative/Indie")]
    Alternative_Indie,
}