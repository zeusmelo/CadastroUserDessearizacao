using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Projeto08
{
    [DataContract]
    internal class Usuario
    {
        [DataMember]
        private string nome;
        [DataMember]
        private string doc;
        [DataMember]
        private DateTime dataDeNasc;
        [DataMember]
        private string nomeDaRua;
        [DataMember]
        private uint numDaCasa;

        public string Name { get => nome; set => nome = value; }
        public string Doc { get => doc; set => doc = value; }
        public DateTime DataDeNasc { get => dataDeNasc; set => dataDeNasc = value; }
        public string NomeDaRua { get => nomeDaRua; set => nomeDaRua = value; }
        public uint NumDaCasa { get => numDaCasa; set => numDaCasa = value; }

        public Usuario(string nome, string doc, DateTime dataDeNasc, string nomeDaRua, uint numDaCasa)
        {
            this.nome = nome;
            this.doc = doc;
            this.dataDeNasc = dataDeNasc;
            this.nomeDaRua = nomeDaRua;
            this.numDaCasa = numDaCasa;
        }
    }
}
