using System;
using System.Collections.Generic;
using CommandLine;

public class CommandLineOptions
{


    [Option('o', "orig_dir", Required = true, HelpText = "Original XML Input files to be compared.")]
    public String OriginalXMLDirectory { get; set; }

    [Option('n', "new_dir", Required = true, HelpText = "New XML Input files to be compared.")]
    public String NewXMLDirectory { get; set; }

}
