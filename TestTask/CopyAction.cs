using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class CopyAction
    {
        /// <summary>
        /// Метод копировния файлов
        /// в качестве аргумента, методу передается массив, где первый столбец это откуда копируется файл,
        /// а второй столбец куда копируется
        /// </summary> 
        public static void CopyFiles(string[,] DataMatrix)
        {
            int j = 0;
            for (int i=0;i<= DataMatrix.GetUpperBound(0);i++)
            {
                CopyFile(DataMatrix[i, j], DataMatrix[i, j + 1]);
            }
            j++;
        }

        /// <summary>
        /// Метод копировния файла
        /// в качестве аргумента, методу передается два парметра, где первый  это откуда копируется файл,
        /// а второй куда копируется
        /// </summary> 
        public static void CopyFile(string FileDirectory, string FileDirectoryCopy)
        {
            try
            {
                File.Copy(FileDirectory, FileDirectoryCopy, true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Файл:{FileDirectory} скопирован в {FileDirectoryCopy}");
                Console.ForegroundColor = ConsoleColor.White;//Сброс цвета
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл:{FileDirectory} не скопирован в {FileDirectoryCopy}");
                Console.ForegroundColor = ConsoleColor.White;//Сброс цвета
            }           
        }
    }
}
