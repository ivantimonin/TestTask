using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main()
        {
            string DirectoryFileConfig = @"D:\УРОКИ С#\TestTask\TestTask\Config.xml";//указание директории файла-конфигурации
            string[,] DataMatrix = InfoFromXML.Readxml(DirectoryFileConfig);//чтение файла-конфигурации          
            CopyAction.CopyFiles(DataMatrix);//копирование файлов согласно файла-конфигурации
            Console.Read();
        }
    }
}
