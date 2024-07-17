using EntityLib;
namespace RepoLib;

public interface IPaymentGatewayRepo
{
    int FundTransfer(PaymentGateway info );
}