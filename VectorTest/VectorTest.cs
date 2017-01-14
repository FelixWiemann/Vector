using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nepumuk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace nepumukTest
{
    /// <summary>
    /// tested functions:
    /// - GetDistance(Vector,Vector)
    /// - + (add)
    /// - - (subtract)
    /// - * (scalar mult)
    /// - SumComponents(Vector)
    /// - Vector.SumComponents
    /// - SumSquaredComponents(Vector)
    /// - Vector.SumSquaredComponents
    /// - Vector.ToString()
    /// - Vector.ToString(string,string)
    /// 
    /// </summary>
    [TestClass()]
    public class VectorTest
    {
        static Vector v3Dim1; // 1,1,1
        static Vector v3Dim2; // 1,2,3
        static Vector v3Dim3; // 1,1,1
        static Vector v3Dim4; // 1.5,3.1,-5.3 

        static Vector v2Dim1; // 1,1
        static Vector v2Dim2; // 1,3
        static Vector v2Dim3; // 1,1

        static Vector v1Dim1; // 1
        static Vector v10Dim1; // 1,1,1,1,1,1,1,1,1,1

        #region init&cleanup
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            Debug.WriteLine("Class init");
            
        }
        [ClassCleanup()]
        public static void ClassCleanup() 
        {
        }

        [TestInitialize()]
        public void Initialize() {
            v3Dim1 = new Vector(1, 1, 1);
            v3Dim2 = new Vector(1, 2, 3);
            v3Dim3 = new Vector(1, 1, 1);
            v2Dim1 = new Vector(1, 1);
            v2Dim2 = new Vector(1, 3);
            v2Dim3 = new Vector(1, 1);
            v1Dim1 = new Vector(1);
            v1Dim1[0] = 1;
            
            double[] d = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            v10Dim1 = new Vector(d);
        }

        [TestCleanup()]
        public void Cleanup() {
            
        }
        #endregion



        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), Vector.DIMENSION_ERROR)]
        public void exception_Subtract()
        {
            Vector res = v3Dim2 - v2Dim1;
        }


        [TestMethod()]
        public void working_Subtract()
        {
            Vector res1 = v3Dim1 - v3Dim2;
            Vector res2 = v2Dim1 - v2Dim2;
            Vector res3 = v3Dim2 - v3Dim1;
            Vector res4 = v2Dim2 - v2Dim1;
            Assert.AreEqual("[0,-1,-2]", res1.ToString("[", ","));
            Assert.AreEqual("[0,-2]", res2.ToString("[", ","));
            Assert.AreEqual("[0,1,2]", res3.ToString("[", ","));
            Assert.AreEqual("[0,2]", res4.ToString("[", ","));

        }

        [TestMethod()]
        public void working_SkalarMult()
        {
            Vector res1 = v3Dim1 * 2;
            Vector res2 = 3.6 * v2Dim2;
            Assert.AreEqual("[2,2,2]", res1.ToString("[", ","));
            Assert.AreEqual("[3.6,10.8]", res2.ToString("[", ","));
            

        }



        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), Vector.DIMENSION_ERROR)]
        public void exception_Addition()
        {
            Vector res = v3Dim2 + v2Dim1;
        }


        [TestMethod()]
        public void working_Addition()
        {
            Vector res1 = v3Dim1 + v3Dim2;
            Vector res2 = v2Dim1 + v2Dim2;
            Vector res3 = v3Dim2 + v3Dim1;
            Vector res4 = v2Dim2 + v2Dim1;
            Assert.AreEqual("[2,3,4]", res1.ToString("[", ","));
            Assert.AreEqual("[2,4]", res2.ToString("[", ","));
            Assert.AreEqual("[2,3,4]", res3.ToString("[", ","));
            Assert.AreEqual("[2,4]", res4.ToString("[", ","));

        }


        [TestMethod()]
        public void working_SumSquaredComponents()
        {
            Assert.AreEqual(3, v3Dim1.SumSquaredComponents(), "SumSquaredComponents1");
            Assert.AreEqual(14, v3Dim2.SumSquaredComponents(), "SumSquaredComponents2");
            Assert.AreEqual(2, v2Dim1.SumSquaredComponents(), "SumSquaredComponents3");
            Assert.AreEqual(1, v1Dim1.SumSquaredComponents(), "SumSquaredComponents4");
            Assert.AreEqual(10, v10Dim1.SumSquaredComponents(), "SumSquaredComponents5");
            Assert.AreEqual(3, Vector.SumSquaredComponents(v3Dim1), "SumSquaredComponents6");
            Assert.AreEqual(14, Vector.SumSquaredComponents(v3Dim2), "SumSquaredComponents7");
            Assert.AreEqual(2, Vector.SumSquaredComponents(v2Dim1), "SumSquaredComponents8");
            Assert.AreEqual(1, Vector.SumSquaredComponents(v1Dim1), "SumSquaredComponents9");
            Assert.AreEqual(10, Vector.SumSquaredComponents(v10Dim1), "SumSquaredComponents10");
        }

        [TestMethod()]
        public void working_SumComponents()
        {
            Assert.AreEqual(3, v3Dim1.SumComponents(),"SumComponents1");
            Assert.AreEqual(6, v3Dim2.SumComponents(), "SumComponents2");
            Assert.AreEqual(2, v2Dim1.SumComponents(), "SumComponents3");
            Assert.AreEqual(1, v1Dim1.SumComponents(), "SumComponents4");
            Assert.AreEqual(10, v10Dim1.SumComponents(), "SumComponents5");
            Assert.AreEqual(3, Vector.SumComponents(v3Dim1), "SumComponents6");
            Assert.AreEqual(6, Vector.SumComponents(v3Dim2), "SumComponents7");
            Assert.AreEqual(2, Vector.SumComponents(v2Dim1), "SumComponents8");
            Assert.AreEqual(1, Vector.SumComponents(v1Dim1), "SumComponents9");
            Assert.AreEqual(10, Vector.SumComponents(v10Dim1), "SumComponents10");
        }

        [TestMethod()]
        public void working_ToStringTest()
        {
            Assert.AreEqual("(1;1;1)", v3Dim1.ToString(), "toString1");
            Assert.AreEqual("[1;1;1]", v3Dim1.ToString("[", ";"), "toString2");
            Assert.AreEqual("{1a1a1}", v3Dim1.ToString("{", "a"), "toString3");
            Assert.AreEqual("/1;1;1\\", v3Dim1.ToString("/", ";"), "toString4");
            Assert.AreEqual("\\1a1a1/", v3Dim1.ToString("\\", "a"), "toString5");
            Assert.AreEqual("\\1;1;1/", v3Dim1.ToString("\\", null), "toString5");
            Assert.AreEqual("(1.5,3.1,-5.3 )", v3Dim1.ToString("(", ","), "toString6");
        }

        [TestMethod()]
        public void working_GetDistanceTest()
        {
            Assert.AreEqual(0, Vector.GetDistance(v3Dim1, v3Dim1),"d1");
            Assert.AreEqual(Math.Sqrt(5), Vector.GetDistance(v3Dim1, v3Dim2), "d2");
            Assert.AreEqual(Vector.GetDistance(v3Dim2, v3Dim3), Vector.GetDistance(v3Dim1, v3Dim2), "d3");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),Vector.DIMENSION_ERROR)]
        public void exception_GetDistanceTest()
        {
            Vector.GetDistance(v1Dim1, v2Dim1);
        }
    }
}
