using BlogWebApp.Data;
using BlogWebApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogWebApp.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
           BlogPosts = blogDbContext.BlogPosts.ToList();
        }
    }
}
