using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原社区.Common.Models
{
    public class Character
    {
        private int id;
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get;
            set;
        }

        private string q_icon;
        public string Q_icon { set; get; }

        private string hd_WallpapersPath;
        public string Hd_WallpapersPath { set; get; }


        public Character()
        {
            Id = 0;
            Q_icon = "";
            Name = "";
            Hd_WallpapersPath = "";
        }

        public Character(IDataReader dr)
        {
            Id=Convert.ToInt32(dr["id"]);
            Q_icon = "F:\\桌面\\多媒体项目实践\\项目实现\\项目资源\\原神资源\\Q头像\\" + dr["Q_icon"].ToString();
            Name =  dr["Name"].ToString();
            Hd_WallpapersPath = "F:\\桌面\\多媒体项目实践\\项目实现\\项目资源\\原神资源\\高清背景图\\"+ dr["HD_WallpapersPath"].ToString();
        }
    }
}
