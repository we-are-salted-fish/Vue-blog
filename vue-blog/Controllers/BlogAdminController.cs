using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;

namespace vue_blog.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class BlogAdminController : Controller
    {
        private AppDbContext _ctx;

        public BlogAdminController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index() => View(_ctx.Posts.ToList());

        public async Task<IActionResult> Index(string title, string body) 
        {
            _ctx.Posts.Add(new Models.Post 
            { 
                Title =title,
                Body = body
            });

            await _ctx.SaveChangesAsync();

            return RedirectToAction("Index", "BlogAdmin");
        }
    }
}
