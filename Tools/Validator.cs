using System.Text.RegularExpressions;

namespace RegistroANS.Tools;
public static class Validator
{
    public static bool CNPJ(string cnpj)
    {
        // Remove qualquer caractere não numérico da string
        var cnpjLimpo = Regex.Replace(cnpj, "[^0-9]+", "");

        // Garante que o CNPJ tenha exatamente 14 digitos
        cnpjLimpo = Convert.ToInt64(cnpjLimpo).ToString("D14");

        // Calcula os 02 digitos do CNPJ e compara com os digitos informados
        return (DigitosCNPJ(cnpjLimpo.Substring(0, 12)) == cnpjLimpo.Substring(12, 2));
    }

    public static bool CPF(string cpf)
    {
        // Remove qualquer caractere não numérico da string
        var cpfLimpo = Regex.Replace(cpf, "[^0-9]+", "");

        // Garante que o CPF tenha exatamente 11 digitos
        cpfLimpo = Convert.ToInt64(cpfLimpo).ToString("D11");

        // Calcula os 02 digitos do CPF e compra com os digitos informados
        if (DigitosCPF(cpfLimpo.Substring(0, 9)) == cpfLimpo.Substring(9, 2))
            return true;
        else
            return false;
    }

    internal static string DigitosCNPJ(string principalCNPJ)
    {
        string cnpj = principalCNPJ;
        string digito = "";
        int[] calculoDigito1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] calculoDigito2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        // Calcula o primeiro digito do CNPJ
        int Aux1 = 0;

        for (int i = 0; i < principalCNPJ.Length; i++)
        {
            Aux1 += Convert.ToInt32(principalCNPJ.Substring(i, 1)) * calculoDigito1[i];
        }

        int Aux2 = (Aux1 % 11);

        // Carrega o primeiro digito na variavel digito
        if (Aux2 < 2)
        {
            digito += "0";
        }
        else
        {
            digito += (11 - Aux2).ToString();
        }

        // Adiciona o primeiro digito ao final do CNPJ para calcular o segundo digito
        cnpj += digito;

        // Calcula o segundo digito do CNPJ
        Aux1 = 0;

        for (int i = 0; i < cnpj.Length; i++)
        {
            Aux1 += Convert.ToInt32(cnpj.Substring(i, 1)) * calculoDigito2[i];
        }

        Aux2 = (Aux1 % 11);

        // Carrega o segundo digito na variavel digito
        if (Aux2 < 2)
        {
            digito += "0";
        }
        else
        {
            digito += (11 - Aux2).ToString();
        }

        return digito;
    }

    internal static string DigitosCPF(string principalCNPJ)
    {
        return "";
    }
}