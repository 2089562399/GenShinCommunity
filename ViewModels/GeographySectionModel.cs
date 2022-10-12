using Microsoft.Xaml.Behaviors;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using 原社区.Common;
using 原社区.Common.DB;
using 原社区.Common.Models;
using 原社区.Extensions;

namespace 原社区.ViewModels
{
    public class GeographySectionModel :BindableBase
    {

		public DelegateCommand<GeographySection> SelectCommand { get; private set; }
		public DelegateCommand<ComboBoxItem> CountryChanged { get; private set; }

        private List<GeographySection> geographySectionses;             //生成地理志图片
		private readonly IDialogHostService dialogHostService;         //对话系统

		public List<GeographySection> GeographySectionses
        {
			get { return geographySectionses; }
			set { geographySectionses = value; RaisePropertyChanged(); }
		}


		public GeographySectionModel(IDialogHostService dialogHostService)
		{
			GeographySectionses = new List<GeographySection>();

            //使用linq语句进行筛选后返回值赋予的list，其放返回值类型为IEnumerable<GeographySection>
            var list = StaticListItems.GeographySections.Where((p) => p.CountryId == 1);
            //使用方法ToList()将IEnumerable<GeographySection>变为List<GeographySection>
            GeographySectionses = list.ToList();


			SelectCommand = new DelegateCommand<GeographySection>(SelectChanged);
            CountryChanged = new DelegateCommand<ComboBoxItem>(ComboBoxIndexChanged);

            this.dialogHostService = dialogHostService;
		}

		/// <summary>
		/// 国家值变化筛选出对应的地域
		/// </summary>
		/// <param name="obj"></param>
		private void ComboBoxIndexChanged(ComboBoxItem obj)
		{
			if (obj == null)
				return;
			string country = obj.Content.ToString();
			int index = 0;
			switch (country)
			{
				case "蒙德":
					index = 1;
					break;
                case "璃月":
                    index = 2;
                    break;
                case "稻妻":
                    index = 3;
                    break;
                case "须弥":
                    index = 4;
                    break;
                default:
					break;
			}

            //使用linq语句进行筛选后返回值赋予的list，其放返回值类型为IEnumerable<GeographySection>
            var list = StaticListItems.GeographySections.Where((p) => p.CountryId == index);
            //使用方法ToList()将IEnumerable<GeographySection>变为List<GeographySection>
            GeographySectionses = list.ToList();

        }

		private void SelectChanged(GeographySection obj)
		{
			
			dialogHostService.ShowDialog("GeographySectionShowDialogView", null, "RootDialog",obj.Path);
		}
	}
}
