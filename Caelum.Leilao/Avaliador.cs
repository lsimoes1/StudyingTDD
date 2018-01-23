using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = double.MinValue;
        private double menorDeTodos = double.MaxValue;

        public void Avalia(Leilao leilao)
        {    
            foreach(var lance in leilao.Lances)
            {
                if (lance.Valor == 0)
                {
                    throw new NullReferenceException("Valor do lance está zerado!");
                }
                else
                {
                    if (lance.Valor > maiorDeTodos)
                    {
                        maiorDeTodos = lance.Valor;
                    }
                    if (lance.Valor < menorDeTodos)
                    {
                        menorDeTodos = lance.Valor;
                    }
                }
            }
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }

    }
}
