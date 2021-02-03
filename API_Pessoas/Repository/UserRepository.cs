using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;
using API_Pessoas.Model.Context;

namespace API_Pessoas.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }
        
        
        public tbUsuario ValidateCredentials(string userName)
        {
            return _context.Usuario.SingleOrDefault(u => u.UserName == userName);
        }


        public tbUsuario ValidateCredentials(UsuarioVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            //TODO: Já sei q essa linha nao vai funcionar
            //return _context.Usuario.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
            var usuario = _context.Usuario.Where(u => (u.UserName == user.UserName) && (u.Password == pass)).FirstOrDefault();

            return usuario;
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Usuario.SingleOrDefault(u => u.UserName == userName);

            if (user == null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public tbUsuario RefreshUserInfo(tbUsuario user)
        {
            if (!_context.Usuario.Any(u => u.Id == user.Id))
            {
                return null;
            }


            var result = _context.Usuario.Where(u => u.Id == user.Id).FirstOrDefault();

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return user;
                }
                catch (Exception ex)
                {
                    throw;
                    return null;
                }
            }

            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider sha)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = sha.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}