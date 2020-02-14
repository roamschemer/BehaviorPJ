using BehaviorPJ.Models;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace BehaviorPJ.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        public ReadOnlyReactiveCollection<PageData> PageDatas { get; }
        public ReactiveProperty<PageData> CollectionSelectedItem { get; } = new ReactiveProperty<PageData>();
        public AsyncReactiveCommand<PageData> ListTapped { get;} = new AsyncReactiveCommand<PageData>();
        public MainPageViewModel(INavigationService navigationService, PageModel pageModel) : base(navigationService) {
            PageDatas = pageModel.Pages.ToReadOnlyReactiveCollection();
            //CollectionSelectedItem.Where(x => x != null).Subscribe(async (x) => {
            //    var p = new NavigationParameters { { "PageData", x } };
            //    await navigationService.NavigateAsync("Page1", p);
            //    CollectionSelectedItem.Value = null; //選択を消す
            //});
            ListTapped.Subscribe(async (x) => {
                if (x == null) return;
                var p = new NavigationParameters { { "PageData", x } };
                await navigationService.NavigateAsync("Page1", p);
                CollectionSelectedItem.Value = null; //選択を消す
            });
        }
    }
}
