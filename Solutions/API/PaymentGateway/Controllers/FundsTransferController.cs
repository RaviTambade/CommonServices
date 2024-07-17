using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using API.Services.Interfaces;

namespace PaymentGateWayService.Controllers;

[ApiController]
[Route("/api/fundstransfer")]
public class FundsTransferController: ControllerBase
{

    private readonly IPaymentGatewayService _svc;
    public FundsTransferController(IPaymentGatewayService svc)
    {
        _svc = svc;
    }

    [HttpPost]
    public int PaymentGateWay([FromBody] PaymentGateWay info)
    {
        return _svc.FundTransfer(info);
    }

}
