using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class TesteDoAvaliador
    {
        [Test]
        public void TesteAvaliadorLances()
        {
            Usuario Luan = new Usuario("Luan");
            Usuario Fabiana = new Usuario("Fabiana");
            Usuario Joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(Joao, 250.0));
            leilao.Propoe(new Lance(Luan, 300.0));
            leilao.Propoe(new Lance(Fabiana, 400.0));


            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);


            double maiorEsperado = 400.0;
            double menorEsperado = 250.0;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
       
        }
        [Test]
        public void TesteOutroCenarioLances()
        {
            Usuario Luan = new Usuario("Luan");
            Leilao leilao = new Leilao("TV");
            Avaliador leiloeiro = new Avaliador();
            string Message;

            leilao.Propoe(new Lance(Luan, 0));

            try
            {
                leiloeiro.Avalia(leilao);
            }
            catch (Exception ex)
            {
                Message = ex.ToString();
            }
        }

        [Test]
        public void TestaValorMedio()
        {
            Usuario Luan = new Usuario("Luan");
            Usuario Fabiana = new Usuario("Fabiana");
            Usuario João = new Usuario("João");

            Leilao leilao = new Leilao("Play4");
            leilao.Propoe(new Lance(Luan, 0.1));
            leilao.Propoe(new Lance(Fabiana, 100));
            leilao.Propoe(new Lance(João, 250));

            Avaliador avalia = new Avaliador();

            try
            {
                avalia.ValorMedio(leilao);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
