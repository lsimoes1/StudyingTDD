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
        private List<Lance> maiores;
        private double Total;
        private int Quantidade;
        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }

        public List<Lance> TresMaiores
        {
            get { return this.maiores; }
        }

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

                PegaOsMaioresNoLeilao(leilao);
            }
        }

        private void PegaOsMaioresNoLeilao(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maiores = maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);
        }

        public void ValorMedio(Leilao leilao)
        {
            foreach (var item in leilao.Lances)
            {
                Total += item.Valor;
                Quantidade++;
            }
            Total = Total / Quantidade;
        }
    }
}
