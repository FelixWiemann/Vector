﻿using System;
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
    /// - Get/Set
    ///     - 
    ///     
    /// - Constructors:
    ///     - Vector(double[])
    ///     - Vector(double,double,double)
    ///     - Vector(double, double)
    ///     - Vector(Vector)
    ///     - Vector(int)
    /// - Vectoroperators
    ///     - + (add) (v+v)
    ///     - - (subtract) (v-v)
    ///     - * (scalar mult) (d*v; v*d)
    ///     - / (scalar div) (v/d)
    ///     
    /// - Calcutils
    ///     - Vector.getLength(Vector)
    ///     - SumComponents(Vector)
    ///     - Vector.SumComponents(Vector)
    ///     - SumSquaredComponents(Vector)
    ///     - Vector.SumSquaredComponents(Vector)
    ///     
    /// - Rotation
    ///     - 
    ///     
    /// - Calc with dots
    ///     - GetDistance(Vector,Vector)
    /// 
    /// - VectorDescription
    ///     - Vector.ToString()
    ///     - Vector.ToString(string,string)
    /// </summary>
    [TestClass()]
    public class VectorTest
    {
        #region vars
        private const double ALLOWED_DEVIATION_DOUBLE  = 0.0001;

        static Vector v3Dim1; // 1,1,1
        static Vector v3Dim2; // 1,2,3
        static Vector v3Dim3; // 1,1,1
        static Vector v3Dim4; // 1.5,3.1,-5.3 

        static Vector v2Dim1; // 1,1
        static Vector v2Dim2; // 1,3
        static Vector v2Dim3; // 1,1

        static Vector v1Dim1; // 1
        static Vector v10Dim1; // 1,1,1,1,1,1,1,1,1,1
        #endregion
        #region init & cleanup
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
            v3Dim4 = new Vector(1.5, 3.1, -5.3);
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
        public void working_GetSet_AtIndex()
        {
            // read at index
            double[] d = { 1.5, 3.1, -5.3 };
            for (int i = 0; i < d.Length; i++)
            {
                Assert.AreEqual(d[i], v3Dim4[i], "index 1." + i);
            }
            // change var
            d[2] = 4;
            // 
            v3Dim4[2] = d[2];
            for (int i = 0; i < d.Length; i++)
            {
                Assert.AreEqual(d[i], v3Dim4[i], "index 2." + i);
            }
        }
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void exception_setByIndex()
        {
            v3Dim4[6] = 1.4;
        }
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void exception_getByIndex()
        {
            double i = v3Dim4[4];
        }


        [TestMethod()]
        public void working_getLength()
        {
            double d1 = Vector.getLength(v10Dim1);
            double d2 = Vector.getLength(v3Dim2);
            double d3 = Vector.getLength(v2Dim2);
            Assert.AreEqual(d1, Math.Sqrt(10), "getLength 1");
            Assert.AreEqual(d2, Math.Sqrt(14), "getLength 2");
            Assert.AreEqual(d3, Math.Sqrt(10), "getLength 3");
        }

        [TestMethod()]
        public void working_Length_get()
        {
            double d1 = v10Dim1.Length;
            double d2 = v3Dim2.Length;
            double d3 = v2Dim2.Length;
            Assert.AreEqual(d1, Math.Sqrt(10), "Length 1");
            Assert.AreEqual(d2, Math.Sqrt(14), "Length 2");
            Assert.AreEqual(d3, Math.Sqrt(10), "Length 3");
        }
        [TestMethod()]
        public void working_Length_set()
        {

            double d1 = 5;
            double d2 = 10;
            double d3 = 3.5;

            v2Dim2.Length = d1;
            v2Dim1.Length = d2;
            v3Dim2.Length = d3;

            Assert.AreEqual(Math.Sqrt(2.5),v2Dim2[0], ALLOWED_DEVIATION_DOUBLE, "Length_set 1");
            Assert.AreEqual(Math.Sqrt(50), v2Dim1[0], ALLOWED_DEVIATION_DOUBLE, "Length_set 2");
            Assert.AreEqual(Math.Sqrt(0.875), v3Dim2[0], ALLOWED_DEVIATION_DOUBLE, "Length_set 3");
        }

        [TestMethod()]
        public void working_GetSet_nComponents()
        {
            
            double[] d = {1.5,3.1,-5.3};
            for (int i = 0; i < d.Length; i++)
            {
                Assert.AreEqual(d[i], v3Dim4.nComponents[i], "comp 1." + i);
            }   
            d[2] = 4;
            v3Dim4.nComponents = d;
            for (int i = 0; i < d.Length; i++)
            {
                Assert.AreEqual(d[i], v3Dim4.nComponents[i], "comp 2." + i);
            }
            double[] n = {1,1,1,1,1,1,1};
            v3Dim4.nComponents = n; // setting this, means changing dimension. able to do so? or force user to create new vector
            for (int i = 0; i < n.Length; i++)
            {
                Assert.AreEqual(d[i], v3Dim4.nComponents[i], "comp 3." + i);
            }
            
        }

        [TestMethod()]
        public void working_Constructors()
        {
            double[] d = { 1, 2, 3 ,4};
            Vector v1 = new Vector(d);
            Vector v2 = new Vector(1, 2, 3.5);
            Vector v3 = new Vector(2.3, 1);
            Vector v4 = new Vector(v2);
            Vector v5 = new Vector(5);

            Assert.AreEqual("(1;2;3;4)",v1.ToString(),"Con 1");
            Assert.AreEqual("(1;2;3,5)", v2.ToString(), "Con 2");
            Assert.AreEqual("(2,3;1)", v3.ToString(), "Con 3");
            Assert.AreEqual(v2.ToString(), v4.ToString(), "Con 4");
            Assert.AreEqual("(0;0;0;0;0)", v5.ToString(), "Con 5");
        }


        [TestMethod()]
        public void working_scalardiv()
        {
            Vector res1 = v3Dim1 / 2;
            Assert.AreEqual("[0,5;0,5;0,5]", res1.ToString("[", ";"));
        }
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Exception_scalardiv()
        {
            Vector res1 = v3Dim1 / 0;
        }


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
            Assert.AreEqual("(1.5,3.1,-5.3 )", v3Dim4.ToString("(", ","), "toString6");
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
