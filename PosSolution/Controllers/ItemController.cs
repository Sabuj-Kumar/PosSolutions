using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PosSolution.Models;
using System.Data;

namespace PosSolution.Controllers
{
    public class ItemController : Controller
    {
        private readonly IConfiguration _configuration;

        public ItemController(IConfiguration configuration)
        {
            this._configuration = configuration; 
        }
        public IActionResult Index()
        {
            try {
                return View();
            }
            catch{

                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCmd = new SqlCommand("item_create", sqlConnection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("id", itemModel.Id);
                        sqlCmd.Parameters.AddWithValue("itemName", itemModel.item);
                        sqlCmd.Parameters.AddWithValue("unique_quantity", itemModel.quantity);
                        sqlCmd.Parameters.AddWithValue("priceUnit", itemModel.price);
                        sqlCmd.Parameters.AddWithValue("amt", itemModel.amount);
                        sqlCmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else {
                return RedirectToAction("Index");
            }
        }

        // Get: ItemController/Edit/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult GetAllItem()
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
