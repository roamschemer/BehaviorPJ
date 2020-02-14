using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BehaviorPJ.Models {

    //ページのデータクラス
    public class PageData : BindableBase {
        public string Title { get => title; set => SetProperty(ref title, value); }
        private string title;
        public string Text { get => text; set => SetProperty(ref text, value); }
        private string text;
        public void Replacement(PageData p) {
            Title = p.Title;
            Text = p.Text;
        }
    }

    //ページ情報
    public class PageModel : BindableBase {
        public ObservableCollection<PageData> Pages { get; }

        public PageModel() {
            var items = new List<PageData>{
                new PageData { Title = "画面1", Text = "その1" },
                new PageData { Title = "画面2", Text = "その2" },
                new PageData { Title = "画面3", Text = "その3" },
                new PageData { Title = "画面4", Text = "その4" },
                new PageData { Title = "画面5", Text = "その5" },
            };
            Pages = new ObservableCollection<PageData>(items);
        }
    }
}
