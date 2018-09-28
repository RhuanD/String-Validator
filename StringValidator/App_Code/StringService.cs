using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Descrição resumida de StringService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
[System.Web.Script.Services.ScriptService]
public class StringService : System.Web.Services.WebService
{
    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = false)]
    public string ValidadorString(string validar)
    {
        if (Validar(validar))
        {
            return $@"Sucesso ao validar a string ""{validar}""";
        }
        else
        {
            return "String inválida, verifique e tente novamente.";
        }
    }

    private bool Validar(string entrada)
    {
        if (Regex.IsMatch(entrada, @"\d"))
        {
            return false;
        }

        Dictionary<char, int> dicionario = new Dictionary<char, int>();

        foreach (char c in "{}[]()")
        {
            dicionario.Add(c, 0);
        }

        foreach (char c in entrada)
        {
            if (dicionario.ContainsKey(c)) dicionario[c] += 1;
        }

        return dicionario['{'] == dicionario['}']
            && dicionario['('] == dicionario[')']
            && dicionario['['] == dicionario[']'];
    }

}
