using API_Pessoas.Data.VO;
using API_Pessoas.Model;

namespace API_Pessoas.Repository
{
    public interface IUserRepository
    {
        tbUsuario ValidateCredentials(UsuarioVO user);
        tbUsuario RefreshUserInfo(tbUsuario user);
    }
}