using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.CodeDom.Compiler;

namespace WebApplication12
{
    static class myLib
    {
        //clé symérique et tableau d'initialisation
        static public byte[] cle = System.Convert.FromBase64String("12UCgcnHy8LHoN/VodosrUVgv+r+kQ5e");
        static public byte[] iv = System.Convert.FromBase64String("AsJNO9N/4dM=");

        //clés assymétrique publique et privée
        static public string pu = "<RSAKeyValue><Modulus>lsKsZcKt6yrWp3c8UN7al0pzcn8KpfOztWri0HJM3aixZpjXLnBWmgzjCcVHiwB1G8RckXDOjupqHbdHTde6zH9ACmB0aZk/89FQthDbeLrtoDevXdPM2QJE1tzX8eWa+2o2Rqc9O7l1uIalV4P2JrMXQl/DkeIy3UL8TH9V2R0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        static public string pr = "<RSAKeyValue><Modulus>lsKsZcKt6yrWp3c8UN7al0pzcn8KpfOztWri0HJM3aixZpjXLnBWmgzjCcVHiwB1G8RckXDOjupqHbdHTde6zH9ACmB0aZk/89FQthDbeLrtoDevXdPM2QJE1tzX8eWa+2o2Rqc9O7l1uIalV4P2JrMXQl/DkeIy3UL8TH9V2R0=</Modulus><Exponent>AQAB</Exponent><P>wR8qqHuRGHzVLP5v+W2F0Wjbvl4pjltbOv45sBs9ORZES+JU+mZinVZDK8xd6MlyUGgI0GXHjb6lvegssCJz2w==</P><Q>x9ipmL1L9y/Co4A3gsaQFU0JxRGHVloEgHgT0uQ5KayCuPiPbX6uxCO+sC4V8DqzE9/N5YiCcu8LfUp1vQ50Zw==</Q><DP>tr5GQH4FE9X0ZwoxbSZ9TWZbIa26xxGdp5ovfnyYF3ABmokGfpfp0xZwo35UktYkzP9U79aP2YpBDg4oU1eWpw==</DP><DQ>Ayf1zba3m2jCryhYOBWAswVrcRRMyd1UEt9SmNMH4BOcYOV0BmuowOo7mbawnAGhUGAJdWWJgd0qlkj1wQ2YYw==</DQ><InverseQ>iYc9CLHX8nR0aYHS+88g21XjfNmNHCqe+4wK2FrszfSYQJfA6Je2Hxr0REISSmxsD1vkV0TD3giUF/YxUnflkA==</InverseQ><D>XbTM8UdLUNPErjynqeCK3+Sv02fxl2rdtZKlPkj9S/1RnuK7RSsgOQpviCAuMtDq+YJYwzHpwd0kbioAUPsZKJRiF/nbyqOsi1AbQGLXk88ygIMO3Q+TeJcxQyAsNcEDX7XsUinrRA6B720vYOldGMECnfnnDpG3c8G3cFVszqU=</D></RSAKeyValue>";



        static public void Generate_cle_iv()
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            byte[] iv = TDES.IV;
            byte[] cle = TDES.Key;
            Console.WriteLine("cle = " + Convert.ToBase64String(cle));
            Console.WriteLine("iv = " + Convert.ToBase64String(iv));
        }

        static public void generate_public_private_key()
        {
            CspParameters cspParams = new CspParameters();
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                // Génère que la clé privée

                Console.WriteLine(rsa.ToXmlString(false));
                // Génère la clé publique et la clé privée
                Console.WriteLine(rsa.ToXmlString(true));




                rsa.Clear();
            }
        }


        static public  byte[] EncryptSym(string text, byte[] key, byte[] iv)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(text);
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            // Cet objet est utilisé pour chiffrer les données.
            // Il reçoit en entrée les données en clair sous la forme d'un tableau de bytes.
            // Les données chiffrées sont également retournées sous la forme d'un tableau de bytes
            var encryptor = TDES.CreateEncryptor(key, iv);

            byte[] cryptedTextAsByte = encryptor.TransformFinalBlock(textAsByte, 0, textAsByte.Length);

            return cryptedTextAsByte;
        }

        static public string DecryptSym(byte[] cryptedTextAsByte, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            // Cet objet est utilisé pour déchiffrer les données.
            // Il reçoit les données chiffrées sous la forme d'un tableau de bytes.
            // Les données déchiffrées sont également retournées sous la forme d'un tableau de bytes
            var decryptor = TDES.CreateDecryptor(key, iv);

            byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);

            return Encoding.Default.GetString(decryptedTextAsByte);
        }



        static public  byte[] EncryptAssym(string value, RSAParameters rsaKeyInfo)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Récupère les infos de la clé publique
                rsa.ImportParameters(rsaKeyInfo);

                byte[] encodedData = Encoding.Default.GetBytes(value);

                // Chiffre les données.
                // Les données chiffrées sont retournées sous la forme d'un tableau de bytes
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();

                return encryptedData;
            }
        }

        static public string DecryptAssym(byte[] encryptedData, RSAParameters rsaKeyInfo)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Récupère les infos de la clé privée
                rsa.ImportParameters(rsaKeyInfo);

                // Déchiffre les données.
                // Les données déchiffrées sont retournées sous la forme d'un tableau de bytes
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);

                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();

                return decryptedValue;
            }
        }


        static public string  hash(string chaine)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(chaine);

            SHA512 sha512 = SHA512Cng.Create();

            byte[] hash = sha512.ComputeHash(textAsByte);

            return Convert.ToBase64String(hash);
 
        }

        static public string hash2(string chaine)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(chaine);

            SHA256 sha256 = SHA256Cng.Create();

            byte[] hash = sha256.ComputeHash(textAsByte);

            return Convert.ToBase64String(hash);

        }


    }
}
