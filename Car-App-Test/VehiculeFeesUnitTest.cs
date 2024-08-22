using Microsoft.AspNetCore.Mvc;
using VehiculeFeesApi.Controllers;
using System.Text.Json;

namespace Car_App_Test;

public class VehiculeFeesUnitTest
{
    VehiculeFeesController _controller;
    VehiculeInfosModel _model;

    [Fact]
    public void CheckRightResultGetFeesForLuxuryCar()
    {
        _controller = new VehiculeFeesController();
        _model = new VehiculeInfosModel
        {
            VehiculeBasePrice = 1800,
            VehiculeType = VehiculeType.Luxury
        };

        ReturnDataModel returnData = new ReturnDataModel
        {
            basicFee = 180.00M,
            specialFee = 72.00M,
            associationFee = 15.00M,
            storageFee = 100.00M
        };

        var result = _controller.GetVehiculeFees(_model);

        Assert.NotNull(result);
        Assert.Equal(JsonSerializer.Serialize(returnData), result.Value);
    }

    [Fact]
    public void CheckRightResultGetFeesForCommonCar()
    {
        _controller = new VehiculeFeesController();
        _model = new VehiculeInfosModel
        {
            VehiculeBasePrice = 398,
            VehiculeType = VehiculeType.Common
        };

        ReturnDataModel returnData = new ReturnDataModel
        {
            basicFee = 39.80M,
            specialFee = 7.96M,
            associationFee = 5.00M,
            storageFee = 100.00M
        };

        var result = _controller.GetVehiculeFees(_model);

        Assert.NotNull(result);
        Assert.Equal(JsonSerializer.Serialize(returnData), result.Value);
    }
}