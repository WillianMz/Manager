﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Manager.Infra.Utilitario
{
    public static class Criptografia
    {
        public static string CriptografarSenha(this string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            var password = (text += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
