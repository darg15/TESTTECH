namespace Test.Util
{
    public class Util
    {
        public static string EnmTarjeta(string numeroTarjeta)
        {

            return numeroTarjeta.Substring(0, 4) + " **** **** " + numeroTarjeta.Substring(15, 4).ToString();
        }

        public static decimal Redondear(decimal valor)
        {
            return Math.Round(valor, 2, MidpointRounding.AwayFromZero);
        }
    }
}
