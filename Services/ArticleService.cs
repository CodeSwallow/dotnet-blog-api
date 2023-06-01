using DotNetAPI.Models;

namespace DotNetAPI.Services;

public class ArticleService
{
    private static List<Article> Articles { get; }
    private static int _nextId = 0;

    static ArticleService()
    {
        Articles = new List<Article> { };
    }
    
    public static List<Article> GetAll() => Articles;
    
    public static Article? Get(int id) => Articles.FirstOrDefault(a => a.Id == id);
    
    public static void Add(Article article)
    {   
        article.Id = _nextId++;
        Articles.Add(article);
    }
    
    public static void Delete(int id)
    {
        var article = Get(id);
        if (article is null)
            return;
        
        Articles.Remove(article);
    }
    
    public static void Update(Article article)
    {
        var index = Articles.FindIndex(a => a.Id == article.Id);
        if (index == -1)
            return;
        
        Articles[index] = article;
    }
}