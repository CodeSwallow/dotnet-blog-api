using DotNetAPI.Models;
using DotNetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    public ArticleController()
    {
    }
    
    [HttpGet]
    public ActionResult<List<Article>> GetAll() => ArticleService.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<Article?> Get(int id)
    {
        var article = ArticleService.Get(id);
        if (article is null)
            return new NotFoundResult();
        
        return article;
    }
    
    [HttpPost]
    public IActionResult Create(Article article)
    {
        ArticleService.Add(article);
        return new CreatedAtRouteResult("Get", new { id = article.Id }, article);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, Article article)
    {
        if (id != article.Id)
            return new BadRequestResult();
        
        var existingArticle = ArticleService.Get(id);
        if (existingArticle is null)
            return new NotFoundResult();
        
        ArticleService.Update(article);
        return new NoContentResult();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var article = ArticleService.Get(id);
        if (article is null)
            return new NotFoundResult();
        
        ArticleService.Delete(id);
        return new NoContentResult();
    }
}