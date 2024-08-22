using System.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace YourApiName.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        // GET: api/sample
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from .NET 8 API");
        }

        // POST: api/sample
        [HttpPost]
        public IActionResult Post(YourDataModel data)
        {
            ReturnDataModel returnData = new ReturnDataModel
            {
                //This fee is always 100 and the api for test purpose
                storageFee = 100
            };
            returnData.basicFee = returnData.GetBasicFees(data.VehiculeBasePrice, data.VehiculeType);
            returnData.specialFee = returnData.GetSpecialFees(data.VehiculeBasePrice, data.VehiculeType);
            returnData.associationFee = returnData.GetAssociationFees(data.VehiculeBasePrice);

            // Handle the posted data here
            return Ok(JsonSerializer.Serialize(returnData));
        }
    }

    public class ReturnDataModel
    {
        public decimal basicFee { get; set; }

        public decimal specialFee { get; set; }

        public decimal associationFee { get; set; }

        public decimal storageFee { get; set; }

        public decimal GetBasicFees(decimal vehiculeBasePrice, int vehiculeType) {
            decimal fee = vehiculeBasePrice * 0.1M;

            if(vehiculeType == 1){
                if(fee < 10){
                    fee = 10;
                } else if(fee > 50){
                    fee = 50;
                }
            } else {
                if(fee < 25){
                    fee = 25;
                } else if(fee > 200){
                    fee = 200;
                }
            }

            return fee;
        }

        public decimal GetSpecialFees(decimal vehiculeBasePrice, int vehiculeType) {
            decimal specialFees = 0M;

            if(vehiculeType == 1){
                specialFees = 0.02M;
            } else {
                specialFees = 0.04M;
            }

            decimal fee = vehiculeBasePrice * specialFees;

            return fee;
        }

        public decimal GetAssociationFees(decimal vehiculeBasePrice) {
            decimal fee = 0;

            if(vehiculeBasePrice >= 1 && vehiculeBasePrice <= 500) {
                fee = 5;
            } else if (vehiculeBasePrice > 500 && vehiculeBasePrice <= 1000) {
                fee = 10;
            } else if (vehiculeBasePrice > 1000 && vehiculeBasePrice <= 3000) {
                fee = 15;
            } else if (vehiculeBasePrice > 3000) {
                fee = 20;
            } 

            return fee;
        }
    }

    public class YourDataModel
    {
        public decimal VehiculeBasePrice { get; set; }
        public int VehiculeType { get; set; }
    }
}