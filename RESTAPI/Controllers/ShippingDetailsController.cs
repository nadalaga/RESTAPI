using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
namespace RESTAPI.Controllers
{
    [Route("api/ShippingDetails")]
    [ApiController]
    public class ShippingDetailsController : ControllerBase
    {

        private ShippingDetailService objShippingDetails = new ShippingDetailService(Startup.DatabasePath);

        

        // GET: api/ShippingDetails/5
        [HttpGet("GetShippingDetails/{id}")]
        public async Task<List<ShippingDetail>> GetShippingDetails(int id)
        {
            objShippingDetails.idorder = id;
            return await objShippingDetails.GetByOrderID();
        }
    }
}
