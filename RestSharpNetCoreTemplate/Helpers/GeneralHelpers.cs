using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNetCoreTemplate.Helpers
{
    public class GeneralHelpers
    {       
        public static string FormatJson(string str)
        {
            string INDENT_STRING = "    ";
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }

        public static void EnsureDirectoryExists(string fullReportFilePath)
        {
            var directory = Path.GetDirectoryName(fullReportFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }
        
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);
            var dirs = dir.GetDirectories();
            // Se o diretório de origem não existe, lançar uma exceção.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            // Se o diretório de destino não existe, criá-lo.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);           
            }
            //deleta arquivos da pasta
            System.IO.DirectoryInfo deletarDestino = new DirectoryInfo(destDirName);
            foreach (FileInfo file in deletarDestino.GetFiles())
            {
                file.Delete();
            } 

            // Receba o conteúdo do arquivo do diretório para copiar.
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                // Crie o caminho para a nova cópia do arquivo.
                var temppath = Path.Combine(destDirName, file.Name);
                // Copie o arquivo.
                file.CopyTo(temppath, true);
            }
            // Se copySubDirs é verdade, copiar os subdiretórios.
            if (!copySubDirs) return;
            foreach (var subdir in dirs)
            {
                // Criar o subdiretório.
                var temppath = Path.Combine(destDirName, subdir.Name);
                // Copiar os subdiretórios.
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }


        public static String CreateDirectoryFolder(string path, string folderName)
        {
            // Specify the directory you want to manipulate.

            try
            {
                if (Directory.Exists(path + "\\" + folderName))
                {
                    Console.WriteLine("That path exists already.");
                    return path + folderName;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path + "\\" + folderName);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path + "\\" + folderName));

                // Delete the directory.
                //di.Delete();

                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            return path + "\\" + folderName;
        }

        public static string ReturnProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            return new Uri(actualPath).LocalPath;
        }

        public static bool VerificaSeStringEstaContidaNaLista(List<string> lista, string p_string)
        {
            foreach (string item in lista)
            {
                if (item.Equals(p_string))
                {
                    return true;
                }
            }
            return false;
        }

        public static int RetornaNumeroDeObjetosDoJson(JArray json)
        {
            return json.Count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodNameByLevel(int level)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(level);
            return sf.GetMethod().Name;
        }

        public static bool IsAJsonArray(string json)
        {
            if (json.StartsWith("["))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ReturnStringWithRandomCharacters(int size)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ReturnStringWithRandomNumbers(int size)
        {
            Random random = new Random();

            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //usando para fazer datadriven

        /*
         metodo do datadriven
         public static IEnumerable NomeMetodoDataDriven()
         {
            return GeneralHelpers.ReturnCSVData("local do csv")
         }
         
         metodo de teste ser:
         [Test, TestCaseSource("NomeDoMetodo")] 
         public void NomeDoMetodoDeTeste(ArrayList testData)
          
         */
        public static IEnumerable ReturnCSVData(string csvPath)
        {
            using (StreamReader sr = new StreamReader(csvPath, System.Text.Encoding.GetEncoding(1252)))
            {
                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ArrayList result = new ArrayList();
                    result.AddRange(line.Split(';'));
                    yield return result;
                }
            }
        }
    }

    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }
}
