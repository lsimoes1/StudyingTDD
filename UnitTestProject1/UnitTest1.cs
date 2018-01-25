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
            TesteDoAvaliador a = new TesteDoAvaliador();
            a.TesteAvaliadorLances();

        }

        [TestMethod]
        public void TesteOutroCenarioLances()
        {
            TesteDoAvaliador a = new TesteDoAvaliador();

            a.TesteOutroCenarioLances();
        }
        [TestMethod]
        public void TestaValorMedio()
        {
            TesteDoAvaliador teste = new TesteDoAvaliador();
            teste.TestaValorMedio();
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
