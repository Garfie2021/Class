using System.Linq;
using System.Runtime.CompilerServices;

namespace DuplicateCheck
{
    public static class DataClassListHelper
    {
        /// <summary>
        /// データクラスのリストに、重複しているId/Codeがあるかチェックする
        /// </summary>
        /// <returns>true;重複無し　false;重複有り</returns>
        public static bool IsDuplicateId_Ptn1(List<DataClass> dataList)
        {
            if (dataList.Where(x1 => x1.Id != 0)
                .Select(x2 => x2.Id)
                .GroupBy(x3 => x3)
                .Any(x4 => x4.Count() > 1))
                return false;    //重複有り

            return true;   //重複無し
        }

        /// <summary>
        /// データクラスのリストに、重複しているIdがあるかチェックする
        /// </summary>
        /// <returns>
        /// true;重複無し
        /// false;重複有り
        /// 重複したIdのリスト。
        /// </returns>
        public static (bool, List<DataClass>?) IsDuplicateId_Ptn2(List<DataClass> dataList)
        {
            var duplicateListId = dataList.Where(x1 => x1.Id != 0)
                .Select(x2 => x2.Id)
                .GroupBy(x3 => x3)
                .Where(x4 => x4.Count() > 1)
                .Select(x5 => x5.Key).ToList();


            if (duplicateListId.Count() > 0)
            {
                return (false, dataList.Where(x6 => duplicateListId.Select(Id => Id).Contains(x6.Id)).ToList());    //重複有り
            }

            return (true, null) ;   //重複無し
        }

        /// <summary>
        /// データクラスのリストに、重複しているId/Codeがあるかチェックする
        /// </summary>
        /// <returns>true;重複無し　false;重複有り</returns>
        public static bool IsDuplicateCode_Ptn1(List<DataClass> dataList)
        {
            if (dataList.Where(x1 => !string.IsNullOrEmpty(x1.Code))
                .Select(x2 => x2.Code)
                .GroupBy(x3 => x3)
                .Any(x4 => x4.Count() > 1))
                return false;    //重複有り

            return true;   //重複無し
        }

        /// <summary>
        /// データクラスのリストに、重複しているCodeがあるかチェックする
        /// </summary>
        /// <returns>
        /// true;重複無し
        /// false;重複有り
        /// 重複したIdのリスト。
        /// </returns>
        public static (bool, List<DataClass>?) IsDuplicateCode_Ptn2(List<DataClass> dataList)
        {
            var duplicateListCode = dataList.Where(x1 => !string.IsNullOrEmpty(x1.Code))
                .Select(x2 => x2.Code)
                .GroupBy(x3 => x3)
                .Where(x4 => x4.Count() > 1)
                .Select(x5 => x5.Key).ToList();

            if (duplicateListCode.Count() > 0)
                return (false, dataList.Where(x6 => duplicateListCode.Select(Code => Code).Contains(x6.Code)).ToList());    //重複有り

            return (true, null);   //重複無し
        }

    }
}