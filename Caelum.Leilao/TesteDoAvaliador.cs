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

            leilao.Propoe(new Lance(Luan, 0));
            leiloeiro.Avalia(leilao);
        }
    }
}
