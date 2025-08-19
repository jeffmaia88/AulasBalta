using blog.Models;
using blog.Data;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{

    var usuario = new User
    {
        Name = "Jefferson Maia",
        Slug = "jeffersonmaia",
        Email = "jefferson.reis88@gmail.com",
        Bio = "Um Fudido",
        Image = "https://jeff.io",
        PasswordHash = "123456"
    };

    var categoria = new Category
    {
        Name = "Backend",
        Slug = "backend"
    };

    var postagem = new Post
    {
        Author = usuario,
        Category = categoria,
        Body = "<p>Hello World<p>",
        Slug = "começando-com-ef-core",
        Summary = "Neste Artigo vamos aprender EF Core",
        Title = "Começando com EF Core",
        CreateDate = DateTime.Now,
        LastUpdateDate = DateTime.Now,
    };

    context.Posts.Add(postagem);
    context.SaveChanges();


}
