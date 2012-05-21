using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Calculations;
using NUnit.Framework;


namespace Common.Test
{
    [TestFixture]
    public class RoundOrderHelperTest : TestFixtureBase
    {
        private static readonly double[] Quantity       = new double[] { 0, 1, 15, 7 , 24, 159,         1000 }; // остаток на складе
        private static readonly double[] QuantityInPack = new double[] { 0, 1, 12, 12, 12, 6,           12 }; //   
        private static readonly double[] MinOrder       = new double[] { 0, 1, 12, 12, 12, 6,           12 }; //  

        private static readonly double[] ReqQty         = new double[] { 0, 1, 13, 12, 21, 29,          45 }; // вводимое колво
        private static readonly double[] ClResult       = new double[] { Single.NaN, 0, 3, 7, 0, 3,     4}; // 
        private static readonly double[] CalcRes        = new double[] { Single.NaN, 0, 15, 7, 24, 27,  52 }; // результат
        private static readonly bool[] ChResult         = new[] { false, true, false, false, true, false, false }; // 
        [Test]
        public void CheckTest()
        {for (int inx = 0; inx < ChResult.Length; inx++)
            {
                bool res = RoundOrderHelper.Check(Quantity[inx], QuantityInPack[inx]);
                Assert.AreEqual(ChResult[inx], res);
            }
        }

        [Test]
        public void CalcModTest()
        {
            for (int inx = 0; inx < ClResult.Length; inx++)
            {
                var res = RoundOrderHelper.CalcMod(Quantity[inx], QuantityInPack[inx]);
                Assert.AreEqual(ClResult[inx], res);
            }

        }

        [Test]
        public void CalcTest()
        {
            for (int inx = 2; inx < ChResult.Length; inx++)
            {
                var res = RoundOrderHelper.Calc(ReqQty[inx], Quantity[inx], QuantityInPack[inx], MinOrder[inx]);
                Assert.AreEqual(CalcRes[inx], res);
            }
        }
    }
}
