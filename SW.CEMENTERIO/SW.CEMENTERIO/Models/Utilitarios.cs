using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace SW.CEMENTERIO.Models
{
    public class Utilitarios
    {
        internal static string NumeroAletorio()
        {
            return new Random().Next(10000, 99999).ToString();
        }

        private const string CRYPT_KEY = "xkKqH3aUDcp4UrSlTuwvFiBtJVA+bIc51NhR3tAkNnM=";

        private static byte[] Encriptar(string password, byte[] Key, byte[] IV)
        {
            if (password == null || password.Length <= 0)
            {
                throw new ApplicationDataUtilException(
                         AplicationDataUtilExceptionIds.ValorDePasswordNulo
                         , "La contraseña a encriptar es nula o es unan cadena vacía."
                         , new object[] { null });
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ApplicationDataUtilException(
                        AplicationDataUtilExceptionIds.ValorDeLlaveNulo
                        , "La llave es nula o el tamaño del arreglo es menor igual a cero."
                        , new object[] { null });
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ApplicationDataUtilException(
                        AplicationDataUtilExceptionIds.ValorDeLlaveNulo
                        , "El vector de inicialización es nulo o el tamaño del arreglo es menor igual a cero."
                        , new object[] { null });
            }

            MemoryStream msEncrypt = null;
            CryptoStream csEncrypt = null;
            StreamWriter swEncrypt = null;

            AesCryptoServiceProvider aesManagedAlg = null;

            try
            {
                aesManagedAlg = new AesCryptoServiceProvider();
                aesManagedAlg.Key = Key;
                aesManagedAlg.IV = IV;

                ICryptoTransform encryptor = aesManagedAlg.CreateEncryptor(aesManagedAlg.Key, aesManagedAlg.IV);

                msEncrypt = new MemoryStream();
                csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                swEncrypt = new StreamWriter(csEncrypt);

                swEncrypt.Write(password);
            }
            finally
            {
                if (swEncrypt != null)
                    swEncrypt.Close();
                if (csEncrypt != null)
                    csEncrypt.Close();
                if (msEncrypt != null)
                    msEncrypt.Close();

                if (aesManagedAlg != null)
                    aesManagedAlg.Clear();
            }

            return msEncrypt.ToArray();

        }

        private static string Desencriptar(string password, byte[] Key, byte[] IV)
        {
            byte[] passwordCifrado;
            passwordCifrado = CadenaBase64ABytes(password);

            if (password == null || password.Length <= 0)
            {
                throw new ApplicationDataUtilException(
                         AplicationDataUtilExceptionIds.ValorDePasswordNulo
                         , "La contraseña a desencriptar es nula o es una cadena vacía."
                         , new object[] { null });
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ApplicationDataUtilException(
                        AplicationDataUtilExceptionIds.ValorDeLlaveNulo
                        , "La llave es nula o el tamaño del arreglo es menor igual a cero."
                        , new object[] { null });
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ApplicationDataUtilException(
                        AplicationDataUtilExceptionIds.ValorDeLlaveNulo
                        , "El vector de inicialización es nulo o el tamaño del arreglo es menor igual a cero."
                        , new object[] { null });
            }

            MemoryStream msDecrypt = null;
            CryptoStream csDecrypt = null;
            StreamReader srDecrypt = null;

            AesCryptoServiceProvider aesManagedAlg = null;

            string plaintext = null;

            try
            {
                aesManagedAlg = new AesCryptoServiceProvider();
                aesManagedAlg.Key = Key;
                aesManagedAlg.IV = IV;

                ICryptoTransform decryptor = aesManagedAlg.CreateDecryptor(aesManagedAlg.Key, aesManagedAlg.IV);

                msDecrypt = new MemoryStream(passwordCifrado);
                csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                srDecrypt = new StreamReader(csDecrypt);

                plaintext = srDecrypt.ReadToEnd();
            }
            finally
            {
                if (srDecrypt != null)
                    srDecrypt.Close();
                if (csDecrypt != null)
                    csDecrypt.Close();
                if (msDecrypt != null)
                    msDecrypt.Close();

                if (aesManagedAlg != null)
                    aesManagedAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] CadenaBase64ABytes(string valor)
        {
            return (string.IsNullOrEmpty(valor) == false ? System.Convert.FromBase64String(valor) : null);
        }

        private static string BytesACadenaBase64(byte[] valor)
        {
            return ((valor != null && valor.Length >= 0) ? System.Convert.ToBase64String(valor) : string.Empty);
        }

        public static string EncriptarPassword(string strPassword)
        {
            try
            {
                byte[] valorVector = new byte[16];

                Random random = new Random(20110103);
                random.NextBytes(valorVector);

                string ivstring = BytesACadenaBase64(valorVector);
                byte[] IV = CadenaBase64ABytes(ivstring);

                byte[] Key = CadenaBase64ABytes(CRYPT_KEY);

                return BytesACadenaBase64(Encriptar(strPassword, Key, IV));
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public static string DesencriptarPassword(string strPassword)
        {
            try
            {
                byte[] valorVector = new byte[16];

                Random random = new Random(20110103);
                random.NextBytes(valorVector);
                string ivstring = BytesACadenaBase64(valorVector);

                byte[] Key = CadenaBase64ABytes(CRYPT_KEY);
                byte[] IV = CadenaBase64ABytes(ivstring);

                return Desencriptar(strPassword, Key, IV);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}