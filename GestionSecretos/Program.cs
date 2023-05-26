using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.Security.KeyVault.Secrets; 

namespace GestionSecretos
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            const string secretName = "miSecretoNumeroDos";
            var kvUri = "https://almacentutorial.vault.azure.net/";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            Console.Write("Introduce el valor de tu secreto: ");
            var secretValue = Console.ReadLine();

            Console.Write($"Creating un secreto llamado '{secretName}' con el valor '{secretValue}' ...");
            await client.SetSecretAsync(secretName, secretValue);
            Console.WriteLine(" hecho.");

            Console.WriteLine("Olvidando el valor del secreto.");
            secretValue = string.Empty;
            Console.WriteLine($"El valor de tu secreto es '{secretValue}'.");

            Console.WriteLine($"Obteniendo el valor de tu secreto.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Tu secreto es '{secret.Value.Value}'.");
        }
    }
}
