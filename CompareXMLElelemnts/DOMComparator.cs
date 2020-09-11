using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

public class DOMComparator
{

    static private String OriginalXMLDirectory { get; set; }

    static private String NewXMLDirectory { get; set; }
    public DOMComparator(String originalXMLDirectory, String newXMLDirectory)
    {
        OriginalXMLDirectory = originalXMLDirectory;
        NewXMLDirectory = newXMLDirectory;

    }

    public void compareXML()
    {

        String[] originalDirectoryXMLFiles = Directory.GetFiles(OriginalXMLDirectory.ToString(), "*.xml");

        string[] newDirectoryXMLFiles = Directory.GetFiles(NewXMLDirectory.ToString(), "*.xml");

        string[] allOriginalElements = extractAllElementsFromXML(originalDirectoryXMLFiles);
        foreach (string nodeName in allOriginalElements)
            Console.WriteLine(nodeName);

        string[] allNewElements = extractAllElementsFromXML(newDirectoryXMLFiles);
        foreach (string nodeName in allNewElements)
            Console.WriteLine(nodeName);

        IEnumerable<string> differenceOriginalElements = allOriginalElements.Except(allNewElements);
        Console.WriteLine("The following elements are in the 9.2 files but not in the 9.4 files");
        foreach (string nodeName in differenceOriginalElements)
            Console.WriteLine(nodeName);

        IEnumerable<string> differenceNewElements = allNewElements.Except(allOriginalElements);
        Console.WriteLine("The following elements are in the 9.4 files but not in the 9.2 files");
        foreach (string nodeName in differenceNewElements)
            Console.WriteLine(nodeName);



    }

    private string[] extractAllElementsFromXML(String[] xmlFiles)
    {

        string[] allElements = { };
        SortedSet<string> allXMLElements = new SortedSet<string>();
        foreach (String xmlFile in xmlFiles)
        {
            try
            {
                XmlReader rdr = XmlReader.Create(new System.IO.StreamReader(xmlFile));
                while (rdr.Read())
                {
                    if (rdr.NodeType == XmlNodeType.Element)
                    {
                        allXMLElements.Add(rdr.LocalName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(xmlFile);
                Console.Write(ex.StackTrace);
                Console.WriteLine();
            }
        }
        return allXMLElements.ToArray();

    }


}
