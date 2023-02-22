using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PosSolution.Controllers
{
    public class ItemController : Controller
    {
        public IConfiguration _configuration { get; }

        public ItemController(IConfiguration configuration)
        {
            this._configuration = configuration; 
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DbConnection"))) { 
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Get: ItemController/Edit/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult GetAllItem()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
