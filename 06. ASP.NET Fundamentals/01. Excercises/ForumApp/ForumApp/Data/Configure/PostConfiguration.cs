using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configure
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPosts();
            builder.HasData(posts);
        }

        private List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "This is my first post",
                    Content = "Momčilo Đujić (1907–1999) was a Serbian Orthodox priest and warlord who led a force of Chetniks within the Independent State of Croatia, a fascist and Axis puppet state in Yugoslavia during World War II"

                },
                new Post()
                {
                    Id = 2,
                    Title = "This is my second post",
                    Content = "that William Anders took the iconic photograph Earthrise (pictured)?"
                }
                ,
                new Post()
                {
                    Id = 3,
                    Title = "This is my third post",
                    Content = "that 17th-century freemason and alchemist Elias Ashmole attempted to invoke"
                }
            };
        }
    }
}
