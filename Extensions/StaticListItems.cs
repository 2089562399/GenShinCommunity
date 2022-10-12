using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 原社区.Common.DB;
using 原社区.Common.Models;

namespace 原社区.Extensions
{
    public static class StaticListItems
    {
        /// <summary>
        /// 数据库角色表条目
        /// </summary>
        public static List<Character> Characters;
        /// <summary>
        /// 数据库地域志条目
        /// </summary>
        public static List<GeographySection> GeographySections;



        public static void DBinitialization()
        {
            //获取数据库中的角色信息
            Characters = MyDBFunction.GetAllCharacter();
            //获取数据库中的地域志信息
            GeographySections=MyDBFunction.GetGeographySections();
        }
    }
}
