using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture
{
    public static class ObtenerImporteLetra
    {
        private static String[] units = { "Cero", "Uno", "Dos", "Tres",
    "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez", "Once",
    "Doce", "Trece", "Catorce", "Quince", "Dieciséis",
    "Diecisiete", "Dieciocho", "Diecinueve" };
        private static String[] tens = { "", "", "Veinte", "Treinta", "Cuarenta",
    "Cincuenta", "Sesenta", "Setenta", "Ochenta", "Noventa" };
        private static String[] hundreds = { "","Ciento","Doscientos", "Trescientos", "Cuatrocientos",
    "Quinientos", "Seiscientos", "Setencientos", "Ochocientos", "Novecientos" };

        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {                    
                    return Convert(amount_int).ToUpper();
                }
                else
                {                    
                    return Convert(amount_int).ToUpper() + " Y " + amount_dec + "/100";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }

        public static String Convert(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                if (i>20&&i<30)
                {
                    return "VEINTI" + Convert(i % 10);
                }
                else
                {
                    return tens[i / 10] + ((i % 10 > 0) ? " y " + Convert(i % 10) : "");
                }                
            }
            if (i < 1000)
            {
                if (i==100)
                {
                    return "CIEN";
                }
                else
                {
                    return hundreds[i/100] + ((i % 100 > 0) ? " " + Convert(i % 100) : "");
                }
            }
            if (i < 100000)
            {
                if (i==1000)
                {
                    return "MIL";
                }
                else
                {
                    var ones = i / 1000;
                    if (ones % 10==1 && ones != 11)
                    {
                        if (ones==21)
                        {
                            return "VEINTIUN MIL" + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
                        }
                        else if (ones == 1)
                        {
                            return "MIL" + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
                        }
                        else
                        {
                            return Convert((i / 1000) - 1) + " y UN MIL" + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
                        }                      
                    }
                    else
                    {
                        return Convert(i / 1000) + " MIL" + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
                    }                    
                }                
            }
            if (i < 1000000)
            {
                var thousands = i / 100000;
                if (i % 100000 == 0)
                {
                    if (thousands==1)
                    {
                        return "CIEN MIL";
                    }
                    else
                    {
                        return hundreds[thousands] + " MIl";
                    }
                    
                }
                else
                {
                    return hundreds[thousands] + " " + Convert(i % 100000);
                }
                //return hundreds[thousands]
                //        + ((i % 100000 > 0) ? " " + Convert(i % 100000) : "");
            }


            if (i < 100000000)
            {
                var millions = i / 1000000;
                if (millions<2)
                {
                    return "UN MILLON" + ((i % 1000000 > 0) ? " " + Convert(i % 1000000) : "");
                }
                else
                {
                    return Convert(i / 1000000) + " MILLONES "
                            + ((i % 1000000 > 0) ? " " + Convert(i % 1000000) : "");
                }
            }
            return "";
        }        
    }
}
