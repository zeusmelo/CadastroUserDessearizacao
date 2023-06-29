using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto08
{
    internal class InterfaceGrafica
    {
        private BaseDeDados baseDeDados;
        public InterfaceGrafica(BaseDeDados baseDeDados) { 
            this.baseDeDados = baseDeDados;
        }
        public  enum Direcao_e {sucesso, sair, excecao}
        public void MostraMsg(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void Show()
        {
            string opc;
            do
            {
                Console.Clear();
                Console.WriteLine("DIGITE: \nC- PARA REGISTRAR UM USUARIO");
                Console.WriteLine("B- PARA PROCURAR UM USUARIO");
                Console.WriteLine("R- PARA EXLUIR UM USUARIO");
                Console.WriteLine("S- PARA ENCERRAR O PROGRAMA");
                opc = Console.ReadKey().KeyChar.ToString().ToLower();

                switch (opc)
                {
                    case "c":RegistraUser(); break; //adicionar
                    case "b": ProcurarUser(); break; //procurar
                    case "r": ApagaUser(); break; //excluir
                    case "s": Sair(); break; //sair
                }
            } while (opc != "s");
        }
        public Direcao_e PegaString(ref string minhaString, string msg)
        {
            Direcao_e retorno;
            string temp;
            Console.Clear();
            Console.WriteLine($"{msg}");
            temp = Console.ReadLine();
            if(temp == "s")
            {
                retorno = Direcao_e.sair;
            } else
            {
                minhaString = temp;
                retorno = Direcao_e.sucesso;
            }
            return retorno;
        }

        public Direcao_e PegaData(ref DateTime minhaData, string msg)
        {
            Direcao_e retorno;
            string temp;
            do
            {
               
                try
                {

                    Console.Clear();
                    Console.WriteLine(msg);
                    temp = Console.ReadLine();
                    if (temp == "s")
                    {
                        retorno = Direcao_e.sair;
                    } else
                    {
                        retorno = Direcao_e.sucesso;
                        minhaData = Convert.ToDateTime(temp);
                    }
                } catch(Exception ex)
                {
                    MostraMsg(ex.Message);
                    retorno = Direcao_e.excecao;
                }
            } while (retorno == Direcao_e.excecao);

            return retorno;
        }

        public Direcao_e PegaUint(ref uint meuNum, string msg)
        {
            Direcao_e retorno;
            string temp;
            do
            {

                try
                {

                    Console.Clear();
                    Console.WriteLine(msg);
                    temp = Console.ReadLine();
                    if (temp == "s")
                    {
                        retorno = Direcao_e.sair;
                    }
                    else
                    {
                        retorno = Direcao_e.sucesso;
                        meuNum = Convert.ToUInt16(temp);
                    }
                }
                catch (Exception ex)
                {
                    MostraMsg(ex.Message);
                    retorno = Direcao_e.excecao;
                }
            } while (retorno == Direcao_e.excecao);

            return retorno;
        }

        public void MostraDados(Usuario usuarioCadastrado)
        {
            Console.WriteLine($"Nome do usuario da lista: {usuarioCadastrado.Name}");
            Console.WriteLine($"Documento do usuario da lista: {usuarioCadastrado.Doc}");
            Console.WriteLine($"Data de nascimento do usuario da lista: {usuarioCadastrado.DataDeNasc.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Nome da rua do usuario da lista: {usuarioCadastrado.NomeDaRua}");
            Console.WriteLine($"Numero da casa do usuario da lista: {usuarioCadastrado.NumDaCasa}");

        }

        public void MostraLista(List<Usuario> lista)
        {
            foreach (var item in lista)
            {
                MostraDados (item);
            }
            MostraMsg("");
        }


        public Direcao_e RegistraUser()
        {
            string nome = "";
            string doc = "";
            DateTime dataDeNasc = new DateTime();
            string nomeDaRua = "";
            uint numDaCasa = 0;

            if(PegaString(ref nome, "DIGITE O NOME DO USUARIO OU PRESSIONE s PARA SAIR") == Direcao_e.sair)
                return Direcao_e.sair;
            if (PegaString(ref doc, "DIGITE O DOC. DO USUARIO OU PRESSIONE s PARA SAIR") == Direcao_e.sair)
                return Direcao_e.sair;
            if(PegaData(ref dataDeNasc, "DIGITE A DATA DE NASCIMENTO OU PRESSIONE s PARA SAIR") == Direcao_e.sair)
                return Direcao_e.sair;
            if (PegaString(ref nomeDaRua, "DIGITE O NOME DA RUA OU PRESSIONE s PARA SAIR") == Direcao_e.sair)
                return Direcao_e.sair;
            if (PegaUint(ref numDaCasa, "DIGITE O NUMº DA CASA OU PRESSIONE s PARA SAIR") == Direcao_e.sair)
                return Direcao_e.sair;
         
             //instancia usuario
            Usuario usuarios = new Usuario(nome, doc, dataDeNasc, nomeDaRua, numDaCasa);
            //adiciona a lista
            baseDeDados.AdicionaUsuario(usuarios);

            MostraDados(usuarios);
            MostraMsg("");
            //retorna com sucesso.
            return Direcao_e.sucesso;

        }

        public void ProcurarUser()
        {
            Console.Clear();
            Console.WriteLine("Digite o doc de usuario a ser procurado ou s para sair: ");
            string temp = Console.ReadLine();
            if (temp == "s")
            {
                return;
            }
            else
            {
                List<Usuario> listaTemp = baseDeDados.BuscaPorDoc(temp);

                if (listaTemp != null)
                {
                    Console.Clear();
                    MostraLista(listaTemp);
                }
                else
                    MostraMsg("NÃO FOI ENCONTRADO USUARIO COM O DOCUMENTO FORNECIDO");
            }

        }

        public void ApagaUser()
        {
            Console.Clear();
            Console.WriteLine("Digite o doc de usuario a ser excluido ou s para sair: ");
            string temp = Console.ReadLine();
            if (temp == "s")
            {
                return;
            }
            else
            {
                List<Usuario> listaTemp = baseDeDados.ExcluiPorDoc(temp);

                if (listaTemp != null)
                {
                    Console.Clear();
                    Console.WriteLine("USUARIO EXLCUIDO COM SUCESSO");
                    MostraLista(listaTemp);

                }
                else
                    MostraMsg("NÃO FOI ENCONTRADO USUARIO COM O DOCUMENTO FORNECIDO");
            }

        }

        public void Sair()
        {
            Console.Clear();
            Console.WriteLine("Encerrando programa em");
            for(int i = 3; i >= 0; i--)
            {
                Console.WriteLine($"{i}...");
                Thread.Sleep(1000);
            }
            System.Environment.Exit(0);
        }
    }
}
