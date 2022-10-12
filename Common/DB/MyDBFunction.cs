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


        /// <summary>
        /// 获取数据库中原神角色表中的数据
        /// </summary>
        /// <returns></returns>
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

        public static List<GeographySection> GetGeographySections()
        {
            var list = new List<GeographySection>();
            string sql = "select * from 地域志;";
            using(IDataReader dr = DBOper.GetReaderSql(sql))
            {
                while (dr.Read())
                {
                    list.Add(new GeographySection(dr));
                }
            }
            return list;
        }
    }
}
