using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseDeDados minhaBase = new BaseDeDados("BaseDeDados.BGxml");
            InterfaceGrafica minhaInterface = new InterfaceGrafica(minhaBase);
            minhaInterface.Show();
        }
    }
}
