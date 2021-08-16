using System;
using System.IO;
using System.Xml;

namespace TestTask
{
    public class InfoFromXML
    {
        /// <summary>
        /// Метод формирования матрицы, где первый столбец это откуда копируется файл, 
        /// а второй столбец, куда копируется
        /// </summary>     
        public static string[,] Readxml(string DirectoryFileConfig)
        {
            if (!File.Exists(DirectoryFileConfig))
            {
                throw new Exception("Не удалось найти указанный файл конфигурации");
            }
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(DirectoryFileConfig);               
            XmlElement XmlRoot = XmlDoc.DocumentElement;// получение корневога элемента
            string[,] DataMatrix = new string[XmlRoot.ChildNodes.Count, XmlRoot.ChildNodes.Count];//1-й столбец откуда копировать; 2-й столбец-куда
            int i = 0;//строка матрицы
            int j = 0;//столбец матрицы
            foreach (XmlNode Node in XmlRoot)
            {                
                foreach (XmlNode Attributes in Node.Attributes)
                {
                    if (Attributes.Name == "source_path")
                    {
                        DataMatrix[i, j] = Attributes.InnerText;
                    }
                    if (Attributes.Name == "destination_path")
                    {
                        DataMatrix[i, j+1] = Attributes.InnerText;
                    }
                    if (Attributes.Name == "file_name")
                    {
                        DataMatrix[i, j] = $@"{DataMatrix[i, j]}\{Attributes.InnerText}";
                        DataMatrix[i, j+1] = $@"{DataMatrix[i, j+1]}\{Attributes.InnerText}";
                    }
                }
                i++;
            }
            return DataMatrix;
        }      
    }
}
