using System;
using System.Security.Cryptography;
using System.Text;

namespace Manager.Utilitario
{
    public static class Criptografia
    {
        public static string CriptografarSenha(this string valor)
        {
            UnicodeEncoding Ue = new UnicodeEncoding();
            byte[] ByteSourceText = Ue.GetBytes(valor);
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
            return Convert.ToBase64String(ByteHash);
        }
    }
}
