using System.ComponentModel;
namespace BasicLibrary
{
    public enum BookGenre
    {
        [Description("Fiction")]
        Fiction = 1,

       [Description("Non-fiction")]
        Nonfiction,

        [Description("Thriller")]
        Thriller,

        [Description("Biography")]
        Biography,

        [Description("Autobiography")]
        Autobiography
    }
}