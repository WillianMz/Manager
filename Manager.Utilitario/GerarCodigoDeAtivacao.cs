using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Infra.Utilitario
{
    public static class GerarCodigoDeAtivacao
    {
        public static string GerarCodigo(this string valor)
        {
            //codigo baseado neste exemplo: https://raphaelcardoso.com.br/dica-gerando-numeros-randomicos-com-c-sharp/

            //tamanho do codigo gerado
            int tamanho = 8;
            string codigo = string.Empty;

            for (int i = 0; i < tamanho; i++)
            {
                Random random = new Random();
                int cod = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((cod >= 48 && cod <= 57) || (cod >= 97 && cod <= 122))
                {
                    string _char = ((char)cod).ToString();
                    if (!codigo.Contains(_char))
                        codigo += _char;
                    else
                        i--;
                }
                else
                    i--;
            }

            return codigo;
        }
    }
}
