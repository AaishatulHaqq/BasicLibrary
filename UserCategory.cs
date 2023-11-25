using System.ComponentModel;
namespace BasicLibrary
{
    public enum UserCategory
    {
        [Description("Author")]
        Author = 1,

       [Description("Borrower")]
        Borrower,

        [Description("Returner")]
        Returner,

        [Description("Reader")]
        Reader
    }
}