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
    }
}
