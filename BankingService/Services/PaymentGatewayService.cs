using EntityLib;
using RepoLib;

namespace ServicesLib;


public class PaymentGatewayService:IPaymentGatewayService
{
    private IPaymentGatewayRepo repo;

   public IPaymentGatewayRepo(IPaymentGatewayRepo _repo){
    this.repo=_repo;
   }
   public int FundTransfer(PaymentGateway info){
    return repo.FundTransfer(info);
   }
}