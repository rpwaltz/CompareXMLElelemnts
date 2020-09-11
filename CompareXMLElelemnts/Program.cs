using System;
using CommandLine;
using System.IO;


namespace CompareXMLElelemnts
{
    class Program
    {
        static void Main(string[] args)
        {
            String originalXMLDirectory = "";
            String newXMLDirectory = "";
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                    .WithParsed<CommandLineOptions>(o =>
                    {
                        if (!String.IsNullOrEmpty(o.OriginalXMLDirectory))
                        {
                            originalXMLDirectory = o.OriginalXMLDirectory;
                        }
                        else
                        {
                            Console.WriteLine("No original XML Directory");
                            return;
                        }

                        if (!String.IsNullOrEmpty(o.OriginalXMLDirectory))
                        {
                            newXMLDirectory = o.NewXMLDirectory;
                        }
                        else
                        {
                            Console.WriteLine("No new XML Directory");
                            return;
                        }
                    });
            if (Directory.Exists(originalXMLDirectory) && Directory.Exists(newXMLDirectory)  )
            {
                DOMComparator domComparator = new DOMComparator(originalXMLDirectory, newXMLDirectory);
                domComparator.compareXML();

            }
        }
    }
}
