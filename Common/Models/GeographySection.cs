using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 原社区.Common.Models
{/// <summary>
/// 地理志实例
/// </summary>
    public class GeographySection
    {
		private string gsName;

		public string GsName
        {
			get { return gsName; }
			set { gsName = value; }
		}

		private int gsId;

		public int GsId
		{
			get { return gsId; }
			set { gsId = value; }
		}

		private string path;

		public string Path
		{
			get { return path; }
			set { path = value; }
		}

		private int countryId;

		public int CountryId
		{
			get { return countryId; }
			set { countryId = value; }
		}

		public GeographySection()
		{
			GsName = "";
			Path = "";
			countryId = 0;
			GsId = 0;
		}

		public GeographySection(IDataReader dr)
		{
			GsId = Convert.ToInt32(dr["风景Id"]);
			CountryId = Convert.ToInt32(dr["地域Id"]);
			GsName = dr["风景"].ToString();
            //image控件无法直接获取非资源文件的相对路径下的图片可以使用一下方式将图片的相对路径转为绝对路径
            Path = System.IO.Path.GetFullPath("..\\..\\项目资源\\原神资源\\地理志\\" + dr["Path"].ToString());;
        }

	}
}
