using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
namespace Projeto08
{
   
    internal static class Serializador
    {
        static private DataContractSerializer serializador = new DataContractSerializer(typeof(BaseDeDados));

        public static void Serializa(string caminhoXML, BaseDeDados baseDeDados)
        {
            //SERIALIZAÇÃO
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            StringBuilder construtorDeString = new StringBuilder();
            XmlWriter escritorXML = XmlWriter.Create(construtorDeString, settings);
            serializador.WriteObject(escritorXML, baseDeDados);
            escritorXML.Flush();
            //salvar em arquivo
            string construtorEmString = construtorDeString.ToString();
            FileStream salvar = File.Create(caminhoXML);
            salvar.Close();
            File.WriteAllText(caminhoXML, construtorEmString );
            escritorXML.Close();
        }

        public static BaseDeDados Desserializa(string caminhoXML)
        {
            try
            {
                if(File.Exists(caminhoXML))
                {
                    string conteudoDessearilizar = File.ReadAllText(caminhoXML);
                    StringReader leitorDeString = new StringReader(conteudoDessearilizar);
                    XmlReader leitorXML = XmlReader.Create(leitorDeString);
                    BaseDeDados baseTemp = (BaseDeDados)serializador.ReadObject(leitorXML);
                    leitorXML.Close();
                    return baseTemp;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }

}
