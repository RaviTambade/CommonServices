using Microsoft.AspNetCore.Mvc;
using  ServicesLib;
using EntityLib;

namespace PaymentGateWayService.Controllers;

[ApiController]
[Route("[controller]")]
public class FundTransferController: ControllerBase
{

    private readonly IPaymentGatewayService _svc;
    public FundTransferController(IPaymentGatewayService svc)
    {
        _svc = svc;
    }

    [HttpPost]
    public int PaymentGateWay([FromBody] Payment info)
    {
        return _svc.FundTransfer(info);
    }

}
