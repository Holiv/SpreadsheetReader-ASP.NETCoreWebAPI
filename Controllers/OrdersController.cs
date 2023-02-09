﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SpreadSheetReader.Data;
using SpreadSheetReader.Models;
using System.Data.SqlTypes;
using System.Globalization;

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
                        Value = double.Parse(worksheet.Cells[row, 5].Value.ToString(), CultureInfo.InvariantCulture)
                    };
                    await _ordersDbContext.Orders.AddAsync(order);
                    await _ordersDbContext.SaveChangesAsync();
                }
            }

            return Ok(file);
        }
        //Método para testes
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

        [HttpDelete]
        public async Task<IActionResult> DeleteOrders()
        {
            await _ordersDbContext.Orders.Select(order => order).ExecuteDeleteAsync();
            return Ok();
        }

        [HttpGet("code")]
        public async Task<IActionResult> GetByCode(string code)
        {
            long askedCode = long.Parse(code);
            List<Order> orders = await _ordersDbContext.Orders.Where(order => order.Code == askedCode).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            List<Order> orders = await _ordersDbContext.Orders.Where(order => order.Category == category).ToListAsync();
            return Ok(orders);
        }
        [HttpGet("month")]
        public async Task<IActionResult> GetByMonth(int month)
        {
            List<Order> orders = await _ordersDbContext.Orders.Where(order => order.Date.Month== month).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("trimestre")]
        public async Task<IActionResult> GetTrimestreResult(int trimestre)
        {
            List<Order> orders = new List<Order>();
            switch (trimestre)
            {
                case 1:
                     orders = await _ordersDbContext.Orders.Where(order => order.Date.Month >= 1 && order.Date.Month <= 3).ToListAsync();
                    return Ok(orders);
                case 2:
                     orders = await _ordersDbContext.Orders.Where(order => order.Date.Month >= 4 && order.Date.Month <= 6).ToListAsync();
                    return Ok(orders);
                case 3:
                    orders = await _ordersDbContext.Orders.Where(order => order.Date.Month >= 7 && order.Date.Month <= 9).ToListAsync();
                    return Ok(orders);
                case 4:
                    orders = await _ordersDbContext.Orders.Where(order => order.Date.Month >= 10).ToListAsync();
                    return Ok(orders);
                default:
                    return BadRequest(nameof(trimestre));
            }
            
        }

        [HttpGet("dcode")]
        public async Task<IActionResult> DistinctByCode()
        {
            List<long> orders = await _ordersDbContext.Orders.Select(order => order.Code).Distinct().ToListAsync();
            return Ok(orders);
        }
        [HttpGet("dcategory")]
        public async Task<IActionResult> DistinctByCategory()
        {
            List<string> category = await _ordersDbContext.Orders.Select(order => order.Category).Distinct().ToListAsync();
            return Ok(category);
        }

        [HttpGet("dmonth")]
        public async Task<IActionResult> GetByMonth()
        {
            var dates = await _ordersDbContext.Orders.Select(order => order.Date).ToListAsync();
            var month = dates.Select(date => date.Month).Distinct().OrderBy(order => order);

            return Ok(month);
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
