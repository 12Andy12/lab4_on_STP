using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernCoding;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_i()
        {
            //act (выполнить)
            Matrix a = new Matrix(0, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_j()
        {
            //act (выполнить)
            Matrix a = new Matrix(2, -1);
        }
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void this_Expected_MyException_set_j()
        {
            //act (выполнить)
            Matrix a = new Matrix(2, 2);
            a[1, 3] = 2;
        }
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void this_Expected_MyException_get_i()
        {
            //act (выполнить)
            Matrix a = new Matrix(2, 2);
            int r = a[3, 1];
        }
        [TestMethod]
        public void Equel()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            //act (выполнить)
            //bool r = a == b;
            //assert(доказать)
            //Assert.IsTrue(r);
            Assert.AreEqual(a, b);
        }
        [TestMethod]
        public void Summa()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 3; expected[0, 1] = 3;
            expected[1, 0] = 3; expected[1, 1] = 3;
            Matrix actual = new Matrix(2, 2);
            //act (выполнить)
            actual = a + b;
            //assert(доказать)
            Assert.IsTrue(actual == expected);//Оракул
        }
        [TestMethod]
        public void Dif()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1;
            a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; 
            b[1, 0] = 2; b[1, 1] = 2;
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 1; expected[0, 1] = 1;
            expected[1, 0] = 1; expected[1, 1] = 1;
            Matrix actual = new Matrix(2, 2);
            //act (выполнить)
            actual = b - a;
            //assert(доказать)
            Assert.IsTrue(actual == expected);//Оракул
        }
        [TestMethod]
        public void Multiply()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 4; expected[0, 1] = 4;
            expected[1, 0] = 4; expected[1, 1] = 4;
            Matrix actual = new Matrix(2, 2);
            //act (выполнить)
            actual = a * b;
            //assert(доказать)
            Assert.IsTrue(actual == expected);//Оракул
        }
        [TestMethod]
        public void transpose()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 2; a[1, 0] = 3; a[1, 1] = 4;
            
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 1; expected[0, 1] = 3;
            expected[1, 0] = 2; expected[1, 1] = 4;
            Matrix actual = new Matrix(2, 2);
            //act (выполнить)
            actual = a.transp();
            //assert(доказать)
            Assert.IsTrue(actual == expected);//Оракул
        }

        [TestMethod]
        public void min()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 2; a[1, 0] = 3; a[1, 1] = 4;

            int expected = 1;

            //act (выполнить)
            int actual = a.min();
            //assert(доказать)
            Assert.IsTrue(actual == expected);//Оракул
        }
        [TestMethod]
        public void mtos()
        {
            //arrange(обеспечить)
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 2; a[1, 0] = 3; a[1, 1] = 4;

            string expected = "1 2, 3 4";

            //act (выполнить)
            string actual = a.toString();
            //assert(доказать)
            Assert.IsTrue(actual == expected);//Оракул
        }

    }
}