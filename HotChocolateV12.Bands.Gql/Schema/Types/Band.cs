namespace HotChocolateV12.Bands.Gql.Schema.Types;

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
