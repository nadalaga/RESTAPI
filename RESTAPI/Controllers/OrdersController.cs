using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
namespace RESTAPI.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderService objOrder = new OrderService(Startup.DatabasePath);

        // GET: api/Orders
        [HttpGet("GetAllOrders")]
        public async Task<List<Order>> GetAllOrders()
        {
            return await objOrder.Get();
        }


        // GET: api/Orders
        [HttpGet("GetAllOrdersByUser/{id}")]
        public async Task<List<Order>> GetAllOrdersByUser(int id)
        {
            objOrder.iduser = id;
            return await objOrder.GetOrdersByUserID();
        }
    }
}
