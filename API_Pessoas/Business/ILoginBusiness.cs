using API_Pessoas.Data.VO;

namespace API_Pessoas.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UsuarioVO user);
    }
}