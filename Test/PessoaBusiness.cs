using System.Collections.Generic;
using System.Threading.Tasks;
using API_Pessoas.Business.Implementations;
using API_Pessoas.Data.Converter.Implementations;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;
using API_Pessoas.Repository;
using Xunit;
using Moq;

namespace Test
{
    public class PessoaBusiness
    {

        [Fact]
        public void Create_CommandIsValid_Executed_Succes()
        {
            var pessoaRepository = new Mock<IPessoaRepository>();
            var converter = new PessoaConverter();

            PessoaVO pessoa = new PessoaVO
            {
                FirstName = "Milena",
                LastName = "Ramiro",
                Gender = "F",
                Addres = "Mirassol - SP"
            };

            pessoaRepository.Setup(p => p.Create(It.IsAny<tbPessoa>())).Returns(converter.Parse(pessoa));

            var createPessoaCommand = new PessoaBusinessImplementation(pessoaRepository.Object);

            var pessoaResult = createPessoaCommand.Create(pessoa);
            
            pessoaRepository.Verify(p => p.Create(It.IsAny<tbPessoa>()), Times.Once);
            Assert.NotNull(pessoaResult);
        }
        
        
        [Fact]
        public void FindAll_CommandIsValid_Executed_Succes()
        {
            var pessoaRepository = new Mock<IPessoaRepository>();
            var converter = new PessoaConverter();

            List<PessoaVO> lista = new List<PessoaVO>
            {
                new PessoaVO
                {
                    FirstName = "Milena",
                    LastName = "Ramiro",
                    Gender = "F",
                    Addres = "Mirassol"
                },
                new PessoaVO
                {
                    FirstName = "Lara",
                    LastName = "Dosualdo",
                    Gender = "F",
                    Addres = "Mirassol"
                },
                new PessoaVO
                {
                    FirstName = "Otavio",
                    LastName = "Ramiro",
                    Gender = "M",
                    Addres = "Mirassol"
                }
            };

            pessoaRepository.Setup(x => x.FindAll()).Returns(converter.Parse(lista));

            var findAllBusinessImplementation = new PessoaBusinessImplementation(pessoaRepository.Object);

            var result = findAllBusinessImplementation.FindAll();
            
            pessoaRepository.Verify(x => x.FindAll(), Times.Once);
            Assert.NotNull(result);
        }
    }
}