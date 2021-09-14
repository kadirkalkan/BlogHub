using BlogHub.Data;
using BlogHub.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BlogHub.Controllers
{
    // Article'larla ilgili ekleme silme ve güncelleme işlemlerini buradan yapıcam.
    [Authorize]
    public class DataController : Controller
    {
        readonly DatabaseContext _context;
        public DataController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
