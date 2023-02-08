using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SpreadSheetReader.Data;
using SpreadSheetReader.Models;
using System.Data.SqlTypes;

namespace SpreadSheetReader.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private OrdersDbContext _ordersDbContext;
        public List<Order> _orders = new List<Order>();

        public OrdersController(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            List<Order> orders = await _ordersDbContext.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrdersFromFile(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(file.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                //int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;
                List<Order> orders = new List<Order>();

                for (int row = 2; row <= rowCount; row++)
                {
                    var data = GetSeparetedDate(worksheet.Cells[row, 3].Value.ToString());

                    Order order = new Order()
                    {
                        Id = new Guid(),
                        Code = long.Parse(worksheet.Cells[row, 1].Value.ToString()),
                        Category = worksheet.Cells[row, 2].Value.ToString(),
                        Date = new DateTime(data.year, data.month, data.day),
                        Quantity = int.Parse(worksheet.Cells[row, 4].Value.ToString()),
                        Value = double.Parse(worksheet.Cells[row, 5].Value.ToString())
                    };
                    await _ordersDbContext.Orders.AddAsync(order);
                    await _ordersDbContext.SaveChangesAsync();
                }
            }

            return Ok(file);
        }
        
        [HttpPost("/mockpost")]
        public IActionResult MockPostOrdersFromFile(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(file.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;
                List<Order> orders = new List<Order>();

                for (int row = 2; row <= rowCount; row++)
                {

                    var data = GetSeparetedDate(worksheet.Cells[row, 3].Value.ToString());

                    Order order = new Order()
                    {
                        Id = new Guid(),
                        Code = long.Parse(worksheet.Cells[row, 1].Value.ToString()),
                        Category = worksheet.Cells[row, 2].Value.ToString(),
                        Date = new DateTime(data.year, data.month, data.day),
                        Quantity = int.Parse(worksheet.Cells[row, 4].Value.ToString()),
                        Value = double.Parse(worksheet.Cells[row, 5].Value.ToString())
                    };
                    orders.Add(order);
                }
             _orders = orders;
            }
            
            return Ok(file);
        }

        [HttpGet("/mockget")]
        public IActionResult GetOrdersFromFile()
        {
            return Ok(_orders);
        }


        private (int day, int month, int year) GetSeparetedDate(string date)
        {
           int day = int.Parse(date.Substring(0, 2));
           int month = int.Parse(date.Substring(3, 2));
           int year = int.Parse(date.Substring(6, 4));
           //string formatedDate = $"{month}/{day}/{year}";
           return (day, month, year);
        }
    }
}
