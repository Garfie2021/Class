using Microsoft.VisualStudio.TestTools.UnitTesting;
using DuplicateCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateCheck.Tests
{
    [TestClass()]
    public class DataClassListHelperTests
    {
        private List<DataClass> DataClassList1;
        private List<DataClass> DataClassList2;
        private List<DataClass> DataClassList3;
        private List<DataClass> DataClassList4;

        public DataClassListHelperTests()
        {
            DataClassList1 = new List<DataClass>
            {
                new DataClass() { Id = 1, Code = "001", Value = "テスト１" },
                new DataClass() { Id = 2, Code = "002", Value = "テスト２" },
                new DataClass() { Id = 3, Code = "003", Value = "テスト３" }
            };

            DataClassList2 = new List<DataClass>
            {
                new DataClass() { Id = 1, Code = "001", Value = "テスト１" },
                new DataClass() { Id = 2, Code = "002", Value = "テスト１" },
                new DataClass() { Id = 3, Code = "003", Value = "テスト１" }
            };

            DataClassList3 = new List<DataClass>
            {
                new DataClass() { Id = 1, Code = "001", Value = "テスト１" },
                new DataClass() { Id = 2, Code = "002", Value = "テスト２" },
                new DataClass() { Id = 1, Code = "003", Value = "テスト３" }
            };

            DataClassList4 = new List<DataClass>
            {
                new DataClass() { Id = 1, Code = "001", Value = "テスト１" },
                new DataClass() { Id = 2, Code = "002", Value = "テスト２" },
                new DataClass() { Id = 3, Code = "001", Value = "テスト３" }
            };
        }


        [TestMethod()]
        public void IsDuplicateId_Ptn1Test()
        {
            Assert.IsTrue(DataClassListHelper.IsDuplicateId_Ptn1(DataClassList1));
            Assert.IsTrue(DataClassListHelper.IsDuplicateId_Ptn1(DataClassList2));
            Assert.IsFalse(DataClassListHelper.IsDuplicateId_Ptn1(DataClassList3));
            Assert.IsTrue(DataClassListHelper.IsDuplicateId_Ptn1(DataClassList4));
        }

        [TestMethod()]
        public void IsDuplicateId_Ptn2Test()
        {
            var result1 = DataClassListHelper.IsDuplicateId_Ptn2(DataClassList1);
            Assert.IsTrue(result1.Item1);
            Assert.IsTrue(result1.Item2?.Count() == null);

            var result2 = DataClassListHelper.IsDuplicateId_Ptn2(DataClassList2);
            Assert.IsTrue(result2.Item1);
            Assert.IsTrue(result2.Item2?.Count() == null);

            var result3 = DataClassListHelper.IsDuplicateId_Ptn2(DataClassList3);
            Assert.IsFalse(result3.Item1);
            Assert.IsTrue(result3.Item2?.Count() > 0);

            var result4 = DataClassListHelper.IsDuplicateId_Ptn2(DataClassList4);
            Assert.IsTrue(result4.Item1);
            Assert.IsTrue(result4.Item2?.Count() == null);
        }

        [TestMethod()]
        public void IsDuplicateCode_Ptn1Test()
        {
            Assert.IsTrue(DataClassListHelper.IsDuplicateCode_Ptn1(DataClassList1));
            Assert.IsTrue(DataClassListHelper.IsDuplicateCode_Ptn1(DataClassList2));
            Assert.IsTrue(DataClassListHelper.IsDuplicateCode_Ptn1(DataClassList3));
            Assert.IsFalse(DataClassListHelper.IsDuplicateCode_Ptn1(DataClassList4));
        }

        [TestMethod()]
        public void IsDuplicateCode_Ptn2Test()
        {
            var result1 = DataClassListHelper.IsDuplicateCode_Ptn2(DataClassList1);
            Assert.IsTrue(result1.Item1);
            Assert.IsTrue(result1.Item2?.Count() == null);

            var result2 = DataClassListHelper.IsDuplicateCode_Ptn2(DataClassList2);
            Assert.IsTrue(result2.Item1);
            Assert.IsTrue(result2.Item2?.Count() == null);

            var result3 = DataClassListHelper.IsDuplicateCode_Ptn2(DataClassList3);
            Assert.IsTrue(result3.Item1);
            Assert.IsTrue(result3.Item2?.Count() == null);

            var result4 = DataClassListHelper.IsDuplicateCode_Ptn2(DataClassList4);
            Assert.IsFalse(result4.Item1);
            Assert.IsTrue(result4.Item2?.Count() > 0);
        }
    }
}