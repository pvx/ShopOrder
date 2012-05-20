using System;

namespace Common.Calculations
{
    public static class RoundOrderHelper
    {
        private const double Cst = 0.5;
        private const double Prc = 0.4; // 40%

        public static bool Check(double quantity, double quantityInPack)
        {
            return quantity % quantityInPack == 0;
        }

        public static double CalcMod(double quantity, double quantityInPack)
        {
            return quantity % quantityInPack;
        }

        public static double Calc(double reqQuantity, double quantity, double quantityInPack, double minOrder)
        {
            double res;

            var mod = CalcMod(quantity, quantityInPack);
            var cl = quantityInPack * Cst;
            reqQuantity = Math.Abs(reqQuantity);

            if(mod == 0)
            {
                return CalcC(reqQuantity, minOrder);
            }

            if(mod >= cl)
            {
                res = CalcC(reqQuantity, minOrder) - quantityInPack + mod;
            }
            else
            {
                res = CalcC(reqQuantity, minOrder) + mod;
            }
            return res; 
        }

        private static double CalcC(double reqQuantity, double minOrder)
        {
            var mod = CalcMod(reqQuantity, minOrder);
            if (mod > 0)
            {
                return mod >= (minOrder * Prc) ? reqQuantity - mod + minOrder : reqQuantity - mod;
            }
            return reqQuantity;
        }
    }
} 