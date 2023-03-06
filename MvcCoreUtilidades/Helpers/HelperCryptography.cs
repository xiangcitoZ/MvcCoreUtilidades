using System.Text;
using System.Security.Cryptography;
namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        public static string EncriptarTextoBasico(string contenido)
        {
            byte[] entrada;
            byte[] salida;

            UnicodeEncoding encoding = new UnicodeEncoding();
            SHA1Managed sHA1 = new SHA1Managed();

            entrada = encoding.GetBytes(contenido);
            salida = sHA1.ComputeHash(entrada);

            string resultado = encoding.GetString(salida);
            return resultado;


        }


    }
}
