using C_Sharp_CRUD.Data;
using C_Sharp_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace C_Sharp_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public HomeController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        // get all posts and display them.
        public IActionResult GetPostListArray()
        {
            var AllPost = _dbContext.BlogPosts.ToList();
            return View("Index", AllPost);
        }
        //[HttpGet("{Id}")]
        public IActionResult GetPostById(int Id)
        {
            BlogPost post = _dbContext.BlogPosts.Find(Id);
            if (post != null)
            {
                ViewData["Id"] = post.Id;
                ViewData["Title"] = post.Title;
                ViewData["Description"] = post.Description;
                ViewData["Author"] = post.Author;
            }
            return View("SinglePost");
        }
        // create a post
        public IActionResult GoToAddPage()
        {
            return View("AddPost");
        }
        [HttpPost]
        public IActionResult AddPost(BlogPost blogPost)
        {
            _dbContext.BlogPosts.Add(blogPost);
            _dbContext.SaveChanges();
            return Redirect("/Home/GetPostListArray");
        }
		// update a post
		public IActionResult GoToEditPage(int Id)
		{
			BlogPost post = _dbContext.BlogPosts.Find(Id);
			if (post != null)
			{
				ViewData["Id"] = post.Id;
				ViewData["Title"] = post.Title;
				ViewData["Description"] = post.Description;
				ViewData["Author"] = post.Author;
			}
			return View("EditPost");
		}
		[HttpPost]
        public IActionResult UpdatePostById(int id, BlogPost blogPost)
        {
            BlogPost blog =  _dbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            if(blog != null)
            {
                blog.Title = blogPost.Title;
                blog.Description = blogPost.Description;
                blog.Author = blogPost.Author;
                _dbContext.SaveChanges();
            }
            return Redirect("/Home/GetPostListArray");
        }

        // delete a post
        public IActionResult DeletePostById(int Id)
        {
            var blog = _dbContext.BlogPosts.Find(Id);
            if(blog != null) _dbContext.BlogPosts.Remove(blog);
            _dbContext.SaveChanges();
            ViewData["deletedBlog"] = "The blog is deleted successfully!";
            return Redirect("/Home/GetPostListArray");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

