using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova.Models
{
    // Logger é a classe responsável por armazenar os registros de acesso do usuário no sistema
    internal class Logger
    {
        private readonly static string path = "log.txt";
        public static void Inicializar() {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
        public static void Inserir(string metodo, string nome, string id, DateTime data)
        {
            if (metodo == "Login")
            {
                string[] line = { $"O usuário {nome} ({id}) logou no sistema às {data.TimeOfDay} do dia {data.Day}/{data.Month}/{data.Year}" };
                File.AppendAllLines(path, line);
            }
            else
            {
                string[] line = { $"O usuário {nome} ({id}) saiu do sistema às {data.TimeOfDay} do dia {data.Day}/{data.Month}/{data.Year}" };
                File.AppendAllLines(path, line);
            }
        }
    }

}
