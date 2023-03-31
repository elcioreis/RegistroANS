// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using RegistroANS.Generator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Geração de arquivos para o PTA ANS");

        if (args.Length < 2)
        {
            Operation();
        }
        else
        {
            string type = args[0].ToLower();
            string inputFile = args[1];
            string outputFile = string.Empty;

            if (args.Length > 2)
                outputFile = args[2];

            switch (type)
            {
                case "rpi":
                    var generator = new RPIGenerator(inputFile, outputFile);
                    break;
                default:
                    break;
            }
        }
    }

    private static void Operation()
    {
        var execName = System.AppDomain.CurrentDomain.FriendlyName;

        Console.WriteLine("Utilização:");
        Console.WriteLine($"{execName} TIPO <ArquivoOrigem.xlsx> [ArquivoDestino]");
        Console.WriteLine("Onde o tipo pode ser: RPI");
    }
}
