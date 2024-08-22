using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace VehiculeFeesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculeFeesController : ControllerBase
    {
        // POST: api/sample
        [HttpPost]
        public OkObjectResult GetVehiculeFees(VehiculeInfosModel data)
        {
            ReturnDataModel returnData = new ReturnDataModel
            {
                //This fee is always 100 and the api for test purpose
                storageFee = 100.00M
            };
            returnData.basicFee = returnData.GetBasicFees(data.VehiculeBasePrice, data.VehiculeType);
            returnData.specialFee = returnData.GetSpecialFees(data.VehiculeBasePrice, data.VehiculeType);
            returnData.associationFee = returnData.GetAssociationFees(data.VehiculeBasePrice);

            // Handle the posted data here
            return Ok(JsonSerializer.Serialize(returnData));
        }
    }
}