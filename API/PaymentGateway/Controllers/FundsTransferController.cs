using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using API.Services.Interfaces;

namespace PaymentGateWayService.Controllers;

//Authorized attribute for each action method

//http://localhost:898454/api/paymentgatway
[ApiController]
[Route("[controller]")]
public class FundsTransferController: ControllerBase
{

    private readonly IPaymentGatewayService _svc;
    public FundTsransferController(IPaymentGatewayService svc)
    {
        _svc = svc;
    }

    // HTTP: POST http://localhost:898454/api/paymentgatway
    [HttpPost]
    public int PaymentGateWay([FromBody] PaymentGateWay info)
    {
        return _svc.FundTransfer(info);
    }

}
