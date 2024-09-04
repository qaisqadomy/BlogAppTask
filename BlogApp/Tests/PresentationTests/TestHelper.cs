using System.Diagnostics.CodeAnalysis;
using Application.DTOs;
using Domain.Entities;

namespace PresentationTests;

[ExcludeFromCodeCoverage]
public class TestHelper
{
    public static Article Article1() => new() { Slug = "slug1", Title = "Title1", Description = "Desc1", Body = "Body1", Tags = ["tag1"], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Favorited = false, FavoritesCount = 0, AuthorId = 1 };

    public static Article Article2() => new() { Slug = "slug2", Title = "Title2", Description = "Desc2", Body = "Body2", Tags = ["tag2"], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Favorited = true, FavoritesCount = 10, AuthorId = 2 };

        public static Article Article3() => new() { Slug = "slug3", Title = "Title3", Description = "Desc3", Body = "Body3", Tags = ["tag3"], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Favorited = true, FavoritesCount = 10, AuthorId = 3 };

    public static User User1() => new() { UserName = "User1", Email = "user1@example.com", Password = "123", Bio = "Bio1", Image = "Image1", Following = true };

    public static User User2() => new() { UserName = "User2", Email = "user2@example.com", Password = "123", Bio = "Bio2", Image = "Image2", Following = false };

    public static Comment Comment1() => new() { Body = "Comment 1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AuthorId = 1 };

    public static Comment Comment2() => new() { Body = "Comment 2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AuthorId = 2 };

    public static CommentDTO CommentDto() => new()
    {
        Body = "New Comment",
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        AuthorId = 1
    };

    public static ArticleDTO ArticleDTO() => new()
    {
        Slug = "slug1",
        Title = "Title1",
        Description = "Desc1",
        Body = "Body1",
        Tags = ["tag1"],
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        Favorited = false,
        FavoritesCount = 0,
        AuthorId = 1
    };

    public static UserDTO UserDto() => new()
    {
        UserName = "newUser",
        Email = "newuser@example.com",
        Password = "newPassword"
    };
}
