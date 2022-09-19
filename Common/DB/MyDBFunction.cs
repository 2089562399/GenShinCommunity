using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using 原社区.Common.Models;

namespace 原社区.Common.DB
{
    public class MyDBFunction
    {
        #region [=====私有变量=====]

        private static DataLib _dbOper;

        #endregion

        #region [=====属性=====]

        public static DataLib DBOper
        {
            get
            {
                if (_dbOper == null)
                {
                    _dbOper = new DataLib(string.Empty);
                }
                return _dbOper;
            }
        }

        #endregion

        public static List<Character> GetAllCharacter()
        {
            var resultList = new List<Character>();
            string sql = "select * from 原神角色; ";
            using (IDataReader dr = DBOper.GetReaderSql(sql))
            {
                while (dr.Read())
                {
                    resultList.Add(new Character(dr));
                }
            }
            return resultList;
        }
    }
}
