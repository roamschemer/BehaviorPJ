using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BehaviorPJ.Models {
    //ページのデータクラス
    public class PageData : BindableBase {
        public string Title { get => title; set => SetProperty(ref title, value); }
        private string title;
        public string ViewName { get => viewName; set => SetProperty(ref viewName, value); }
        private string viewName;

        public PageData() {

        }

        public PageData(PageData pageData) {
            Title = pageData.Title;
            ViewName = pageData.ViewName;
        }
    }
    //ページ情報
    public class PageModel : BindableBase {
        public ObservableCollection<PageData> Pages { get; }

        public PageModel() {
            var items = new List<PageData>{
                new PageData { Title = "画面1" },
                new PageData { Title = "画面2" },
                new PageData { Title = "画面3" },
                new PageData { Title = "画面4" },
                new PageData { Title = "画面5" },
            };
            Pages = new ObservableCollection<PageData>(items);
        }
    }
}
