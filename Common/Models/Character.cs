using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原社区.Common.Models
{
    /// <summary>
    /// 角色实例
    /// </summary>
    public class Character
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        private int id;
        public int ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        private string name;
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 角色Q版头像
        /// </summary>
        private string q_icon;
        public string Q_icon { set; get; }

        /// <summary>
        /// 角色高清背景图片
        /// </summary>
        private string hd_WallpapersPath;
        public string Hd_WallpapersPath { set; get; }

        /// <summary>
        /// 背景动画
        /// </summary>
        private string backgroundAnimation;

        public string BackgroundAnimation
        {
            get { return backgroundAnimation; }
            set { backgroundAnimation = value; }
        }

        /// <summary>
        /// 旋转动画
        /// </summary>
        private string rotationAnimation;

        public string RotationAnimation
        {
            get { return rotationAnimation; }
            set { rotationAnimation = value; }
        }

        /// <summary>
        /// 地域ID
        /// </summary>
        private int countryID;

        public int CountryID
        {
            get { return countryID; }
            set { countryID = value; }
        }

        /// <summary>
        /// 平A技能
        /// </summary>
        private string aSkill;

        public string ASkill
        {
            get { return aSkill; }
            set { aSkill = value; }
        }

        /// <summary>
        /// E技能
        /// </summary>
        private string eSkill;

        public string ESkill
        {
            get { return eSkill; }
            set { eSkill = value; }
        }

        /// <summary>
        /// Q技能
        /// </summary>
        private string qSkill;

        public string QSkill
        {
            get { return qSkill; }
            set { qSkill = value; }
        }

        private string iocn;

        public string Icon
        {
            get { return iocn; }
            set { iocn = value; }
        }

        public Character()
        {
        }

        public Character(IDataReader dr)
        {
            ID=Convert.ToInt32(dr["id"]);
            //image控件无法直接获取非资源文件的相对路径下的图片可以使用一下方式将图片的相对路径转为绝对路径
            Q_icon = System.IO.Path.GetFullPath("..\\..\\项目资源\\原神资源\\Q头像\\" + dr["Q_icon"].ToString());
            Name =  dr["Name"].ToString();
            Hd_WallpapersPath = "..\\..\\项目资源\\原神资源\\高清背景图\\" + dr["HD_WallpapersPath"].ToString();
            BackgroundAnimation = dr["BackgroundAnimation"].ToString();
            RotationAnimation = dr["RotationAnimation"].ToString();
            CountryID = Convert.ToInt32(dr["地域Id"]);
            ASkill = dr["A技能"].ToString();
            ESkill = dr["E技能"].ToString();
            QSkill = dr["Q技能"].ToString();
            Icon = System.IO.Path.GetFullPath("..\\..\\项目资源\\原神资源\\角色头像\\" + dr["Icon"].ToString());
        }
    }
}
