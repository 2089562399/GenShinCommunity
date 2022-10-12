using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 原社区.Common.Models;
using 原社区.Extensions;

namespace 原社区.ViewModels
{
    public class RoleIntroductionModel:BindableBase
    {
        private string hdPath;
        public string HDPath { get { return hdPath; } set { hdPath = value; RaisePropertyChanged(); } }

        private List<Character> characters;
        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<Character> HD_WallChanged { get; private set; } //高清图变换
        public RoleIntroductionModel()
        {
            Characters = new List<Character>();
            Characters = StaticListItems.Characters;
            HDPath = Characters[0].Hd_WallpapersPath;

            HD_WallChanged = new DelegateCommand<Character>(Hd_WallpapersPathChanged);
        }
        public void Hd_WallpapersPathChanged(Character obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Hd_WallpapersPath))
            {
                return;
            }
            HDPath = obj.Hd_WallpapersPath;


        }
    }
}
