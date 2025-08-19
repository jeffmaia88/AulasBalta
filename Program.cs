using blog.Models;
using blog.Data;
using Microsoft.EntityFrameworkCore;

//using var context = new BlogDataContext();

// var usuario = new User
// {
//     Name = "Jefferson Maia",
//     Slug = "jeffersonmaia",
//     Email = "jefferson.reis88@gmail.com",
//     Bio = "Um Fudido",
//     Image = "https://jeff.io",
//     PasswordHash = "123456"
// };

// var categoria = new Category
// {
//     Name = "FrontEnd",
//     Slug = "frontend"
// };

// var postagem = new Post
// {
//     Author = usuario,
//     Category = categoria,
//     Body = "<p>Hello World<p>",
//     Slug = "começando-com-ef-core",
//     Summary = "Neste Artigo vamos aprender EF Core",
//     Title = "Começando com EF Core",
//     CreateDate = DateTime.Now,
//     LastUpdateDate = DateTime.Now,
// };

// context.Posts.Add(postagem);
// context.SaveChanges();

// var postagens = context.Posts.AsNoTracking().Include(x => x.Author).OrderByDescending(x => x.LastUpdateDate).ToList();
// foreach (var post in postagens)
// {
//     Console.WriteLine($"{post.Title}escrito por {post.Author?.Name}");
// }


// var postagem = context
//                .Posts
//                .Include(x => x.Author)
//                .Include(x => x.Category)
//                .OrderByDescending(x => x.LastUpdateDate)
//                .FirstOrDefault();

// postagem.Author.Name = "Teste";
// context.Posts.Update(postagem);
// context.SaveChanges();


// var postagem = context.Posts.AsNoTracking().Include(x => x.Author).Include(x => x.Category).ToList();

// foreach (var post in postagem)
// {
//     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
// }


using var context = new BlogDataContext();

// context.Users.Add(new User
// {

//     Name = "Jefferson Reis",
//     Slug = "jeffmaia",
//     Email = "jefferson.reis88@hotmail.com",
//     Bio = "Um Merdalhoca",
//     Image = "https://jeff.io",
//     PasswordHash = "123456789"

// });

// context.SaveChanges();

var usuario = context.Users.FirstOrDefault();

var postagem = new Post
{
    Author = usuario,
    Body = "My Article",
    Category = new Category
    {
        Name = "FullStack",
        Slug = "fullstack"
    },
    CreateDate = System.DateTime.Now,
    Slug = "meu-article",
    Summary = "Neste artigo vamos conferir...",
    Title = "Meu Artigo",
};

context.Posts.Add(postagem);
context.SaveChanges();


