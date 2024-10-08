using Application.Repositories;
using Domain.Entities;
using Domain.Exeptions;

namespace RepositoriesTests;

public class ArticleRepositoryTests
{

    private readonly InMemoryDB _inMemoryDb;
    private readonly ArticleRepository _articleRepository;

    public ArticleRepositoryTests()
    {
        _inMemoryDb = new InMemoryDB();
        _articleRepository = new ArticleRepository(_inMemoryDb.DbContext);
    }

    [Fact]
    public void AddArticle_ShouldAddArticleToDatabase()
    {
        var article =TestHelper.Article1();

        _articleRepository.AddArticle(article);
        var result = _articleRepository.GetAll();

        Assert.Single(result);
        Assert.Equal(TestHelper.Article1().Title, result.First().Title);
    }

    [Fact]
    public void GetAll_ShouldReturnAllArticles()
    {
        var article1 = TestHelper.Article1();
        var article2 = TestHelper.Article2();

        _articleRepository.AddArticle(article1);
        _articleRepository.AddArticle(article2);

        var result = _articleRepository.GetAll();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, a => a.Title == TestHelper.Article1().Title);
        Assert.Contains(result, a => a.Title == TestHelper.Article2().Title);
    }

    [Fact]
    public void GetArticle_ShouldFilterByTagAuthorFavorited()
    {
        var user = new User
        {
            Id = 1,
            UserName = "qais",
            Email = "qais@gmail.com",
            Password = "123"
        };

        _inMemoryDb.DbContext.Users.Add(user);

        var article1 = new Article
        {
            Id = 1,
            Title = "Article 1",
            Tags = new List<string> { "Tech" },
            AuthorId = 1,
            Favorited = true,
            Slug = "qais",
            Description = "qais",
            Body = "dsds"
        };

        var article2 = new Article
        {
            Id = 2,
            Title = "Article 2",
            Tags = new List<string> { "Science" },
            AuthorId = 1,
            Favorited = false,
            Slug = "qais",
            Description = "qais",
            Body = "dsds"
        };

        _articleRepository.AddArticle(article1);
        _articleRepository.AddArticle(article2);

        var result = _articleRepository.GetArticle("Tech", "qais", true);

        Assert.Single(result);
        Assert.Equal("Article 1", result.First().Title);
    }

    [Fact]
    public void UpdateArticle_ShouldUpdateExistingArticle()
    {
        var article = TestHelper.Article1();

        _articleRepository.AddArticle(article);

        var updatedArticle = TestHelper.Article2();

        _articleRepository.UpdateArticle(updatedArticle, 1);
        var result = _articleRepository.GetAll().FirstOrDefault(a => a.Id == 1);

        Assert.NotNull(result);
        Assert.Equal(TestHelper.Article2().Title, result.Title);
        Assert.Equal(TestHelper.Article2().Description, result.Description);
    }

    [Fact]
    public void UpdateArticle_ShouldThrowExceptionWhenArticleNotFound()
    {
        var updatedArticle = TestHelper.Article1();
        var exception = Assert.Throws<ArticleNotFound>(() => _articleRepository.UpdateArticle(updatedArticle, 999));
        Assert.Equal("Article with the Id : 999 not found", exception.Message);
    }
    [Fact]
    public void GetArticle_ShouldThrowArticleNotFound_WhenNoArticlesMatch()
    {
        var exception = Assert.Throws<ArticleNotFound>(() => _articleRepository.GetArticle(tag: "NonExistingTag", author: null, favorited: null));
        Assert.Equal("Articles not found", exception.Message);
    }

    [Fact]
    public void DeleteArticle_ShouldRemoveArticleFromDatabase()
    {
        var article = TestHelper.Article1();

        _articleRepository.AddArticle(article);

        _articleRepository.DeleteArticle(1);
        var result = _articleRepository.GetAll();

        Assert.Empty(result);
    }

    [Fact]
    public void DeleteArticle_ShouldThrowExceptionWhenArticleNotFound()
    {
        var exception = Assert.Throws<ArticleNotFound>(() => _articleRepository.DeleteArticle(999));
        Assert.Equal("Article with the Id : 999 not found", exception.Message);
    }
}

