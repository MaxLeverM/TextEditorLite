using System.Data.Entity;

namespace TextEditorLite
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        { }
        public DbSet<TextFile> TextFiles { get; set; }
    }
}
