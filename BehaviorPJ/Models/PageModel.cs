using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BehaviorPJ.Models {

    //ページのデータクラス
    public class PageData : BindableBase {
        public string Title { get => title; set => SetProperty(ref title, value); }
        private string title;
        public string LabelName { get => labelName; set => SetProperty(ref labelName, value); }
        private string labelName;
        public void Replacement(PageData p) {
            Title = p.Title;
            LabelName = p.LabelName;
        }
    }

    //ページ情報
    public class PageModel : BindableBase {
        public ObservableCollection<PageData> Pages { get; }

        public PageModel() {
            var items = new List<PageData>{
                new PageData { Title = "画面1", LabelName = "その1" },
                new PageData { Title = "画面2", LabelName = "その2" },
                new PageData { Title = "画面3", LabelName = "その3" },
                new PageData { Title = "画面4", LabelName = "その4" },
                new PageData { Title = "画面5", LabelName = "その5" },
            };
            Pages = new ObservableCollection<PageData>(items);
        }
    }
}
