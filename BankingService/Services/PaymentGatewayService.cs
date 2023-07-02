using EntityLib;
using RepoLib;

namespace ServicesLib;


public class PaymentGatewayService:IPaymentGatewayService
{
    private IPaymentGatewayRepo _repo;

   public PaymentGatewayService(IPaymentGatewayRepo repo){
     _repo =repo;
   }
   public int FundTransfer(PaymentGateway info){
    return _repo.FundTransfer(info);
   }
}