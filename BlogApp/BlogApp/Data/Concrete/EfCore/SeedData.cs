using System.Data.Common;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Entity.Tag { Text = "Web Programlama", Url = "web-programlama", Color = TagColors.warning },
                        new Entity.Tag { Text = "Backend", Url = "backend", Color = TagColors.danger },
                        new Entity.Tag { Text = "Frontend", Url = "frontend", Color = TagColors.success },
                        new Entity.Tag { Text = "Fullstack", Url = "fullstack", Color = TagColors.secondary },
                        new Entity.Tag { Text = "php", Url = "php", Color = TagColors.primary }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User
                        {
                            UserName = "sadikturan",
                            Name = "Sadık Turan",
                            Email = "info@sadikturan.com",
                            Password = "123456",
                            Image = "p2.jpg"
                        },
                        new Entity.User
                        {
                            UserName = "caneraktas",
                            Name = "Caner Aktaş",
                            Email = "info@caneraktas.com",
                            Password = "123456",
                            Image = "p1.jpg"
                        }

                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Entity.Post
                        {
                            Title = "asp.net core",
                            Description = "Asp.net Core dersleri",
                            Content = "Asp.net Core dersleri",
                            Url = "asp-net-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment> {
                                new Comment{
                                    CommentText="iyi bir kurs",
                                    PublishedOn=DateTime.Now.AddDays(-20),
                                    UserId=1,
                                },
                                new Comment{
                                    CommentText="Çok iyi bir kurs",
                                    PublishedOn=DateTime.Now.AddDays(-10),
                                    UserId=2,
                                },
                            }
                        },
                        new Entity.Post
                        {
                            Title = "php",
                            Description = "php dersleri",
                            Content = "php dersleri",
                            Url = "php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserId = 1
                        },
                        new Entity.Post
                        {
                            Title = "Django",
                            Description = "Django dersleri",
                            Content = "Django dersleri",
                            Url = "django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        },
                        new Entity.Post
                        {
                            Title = "React Dersleri",
                            Description = "React Dersleri",
                            Content = "React Dersleri",
                            Url = "react-dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        },
                        new Entity.Post
                        {
                            Title = "Angular",
                            Description = "Angular dersleri",
                            Content = "Angular dersleri",
                            Url = "angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        },
                        new Entity.Post
                        {
                            Title = "Web Tasarım",
                            Description = "Web Tasarım dersleri",
                            Content = "Web Tasarım dersleri",
                            Url = "web-tasarim",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}