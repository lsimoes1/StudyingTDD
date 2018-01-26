using System;
using Caelum.Leilao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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

        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario Luan = new Usuario("Luan");

            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(Luan, 2000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(2000.0, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(2000.0, leiloeiro.MenorLance, 0.00001);

        }

        [TestMethod]
        public void DeveRecuperarOsTresMaioresLances()
        {
            Usuario Luan = new Usuario("Luan");
            Usuario Fabiana = new Usuario("Fabiana");
            Usuario Joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(Luan, 100.0));
            leilao.Propoe(new Lance(Fabiana, 200.0));
            leilao.Propoe(new Lance(Joao, 300.0));
            leilao.Propoe(new Lance(Fabiana, 400.0));
            leilao.Propoe(new Lance(Luan, 500.0));

            Avaliador avalia = new Avaliador();
            avalia.Avalia(leilao);
            var maiores = avalia.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(500, maiores[0].Valor, 0.0001);
            Assert.AreEqual(400, maiores[1].Valor, 0.0001);
            Assert.AreEqual(300, maiores[2].Valor, 0.0001);
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void OrdenaValoresAleatorios()
        {
            Usuario Luan = new Usuario("Luan");
            Usuario Fabiana = new Usuario("Fabiana");
            Usuario João = new Usuario("João");

            Leilao leilao = new Leilao("Play4");

            leilao.Propoe(new Lance(Luan, 500.0));
            leilao.Propoe(new Lance(Fabiana, 400));
            leilao.Propoe(new Lance(João, 250));
            leilao.Propoe(new Lance(Fabiana, 100));
            leilao.Propoe(new Lance(Luan, 1000.0));

            Avaliador avalia = new Avaliador();

            avalia.Avalia(leilao);

            var maiores = avalia.TresMaiores;
            var menores = avalia.TresMenos;

            

            Assert.AreEqual(100, menores[0].Valor, 0.0001);
            Assert.AreEqual(1000, maiores[0].Valor, 0.0001);

        }

        [TestMethod]
        public void ValoreOrdemCrescente()
        {
            Usuario Luan = new Usuario("Luan");
            Usuario Fabiana = new Usuario("Fabiana");
            Usuario João = new Usuario("João");

            Leilao leilao = new Leilao("Play4");

            leilao.Propoe(new Lance(Luan, 400));
            leilao.Propoe(new Lance(Fabiana, 300));
            leilao.Propoe(new Lance(João, 200));
            leilao.Propoe(new Lance(Fabiana, 100));

            Avaliador avalia = new Avaliador();

            avalia.Avalia(leilao);

            var maiores = avalia.TresMaiores;
            var menores = avalia.TresMenos;



            Assert.AreEqual(100, menores[0].Valor, 0.0001);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);

        }

        [TestMethod]
        public void IdentificaSeEPalindromoERetornaREsultadoERemoveCaracteres()
        {
            Palindromo frase = new Palindromo();
                        
            bool resultado = frase.EhPalindromo("Socorram-me subi no onibus em Marrocos");

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void IdentificaSeEPalindromoERetornaREsultado()
        {
            Palindromo frase = new Palindromo();

            bool resultado = frase.EhPalindromo("Anotaram a data da maratona");

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void IdentificaQueNaoEPalindromo()
        {
            Palindromo frase = new Palindromo();

            bool resultado = frase.EhPalindromo("Testando a frase se é ou não palindromo");

            Assert.IsFalse(resultado);
        }
    }
}
