using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projeto08
{
    [DataContract]
    internal class BaseDeDados
    {
        [DataMember]
        List<Usuario> listaDeUsuarios;
        private string caminhoBaseDeDados; //local do arquivo
        public BaseDeDados(string caminhoBaseDeDados) {
            this.caminhoBaseDeDados = caminhoBaseDeDados;
            BaseDeDados baseTemp = Serializador.Desserializa(caminhoBaseDeDados);
            if(baseTemp != null ) {
            listaDeUsuarios = baseTemp.listaDeUsuarios;
            } 
            else
            listaDeUsuarios = new List<Usuario>();
            
           
        }

        public void AdicionaUsuario(Usuario usuario)
        {
            listaDeUsuarios.Add(usuario);
            Serializador.Serializa(caminhoBaseDeDados, this); 
        }

        public List<Usuario> BuscaPorDoc(string doc)
        {
            List<Usuario> listaTemp = new List<Usuario>();

            listaTemp = listaDeUsuarios.Where(x => x.Doc == doc).ToList();

            if (listaTemp.Count > 0)
            {
                return listaTemp;
            }
            else
                return null;
        }

        public List<Usuario> ExcluiPorDoc(string doc)
        {
            List<Usuario> listaTemp = new List<Usuario>();

            listaTemp = listaDeUsuarios.Where(x => x.Doc == doc).ToList();

            if (listaTemp.Count > 0)
            {
                foreach (var item in listaTemp)
                {
                    listaDeUsuarios.Remove(item);
                }
                return listaTemp;
            }
            else
                return null;
        }
    }
}
