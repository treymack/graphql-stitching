using System.ComponentModel;

namespace HotChocolateV12.Bands.Gql.Schema.Types;

public enum Genre
{
    Rock,
    [Description("Alternative/Indie")]
    Alternative_Indie,
}