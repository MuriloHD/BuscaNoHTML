using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Busca
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create ("https://g1.globo.com/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            


            if(String.Compare(response.StatusDescription,"OK") == 0){
            // Fluxo de dados  
            Stream data = response.GetResponseStream();
            // Leitura dos dados
            StreamReader  arquivo = new StreamReader(data);
            String arquivoHtml = arquivo.ReadToEnd();

            // Busca pela palavra no HTML
            String palavra = " ";
            Console.WriteLine("Digite a palavra a ser buscada");
            palavra = Console.ReadLine();
            while(String.Compare(palavra,"sair") != 0){    
            
                while(String.Compare(palavra,"") == 0){
                    Console.WriteLine("Digite Uma palavra");
                    palavra = Console.ReadLine();
                }

            Regex rx = new Regex($"{palavra}",RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(arquivoHtml);
            Console.WriteLine("{0} correspondências encontradas em :\n g1.globo.br\n",matches.Count);
            Console.WriteLine("Digite a palavra a ser buscada\nDigite sair para encerrar");
            palavra = Console.ReadLine();
            }
            
            arquivo.Close();
            data.Close();
            response.Close();
            }
            else{
                Console.WriteLine("A requesição falhou");
            }
            Console.WriteLine("Aplicação Encerrada");
        }
    }
}
