using BehaviorPJ.Models;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace BehaviorPJ.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        public ReadOnlyReactiveCollection<PageData> PageDatas { get; private set; }
        public ReactiveProperty<PageData> CollectionSelectedItem { get; set; } = new ReactiveProperty<PageData>();

        public MainPageViewModel(INavigationService navigationService, PageModel pageModel) : base(navigationService) {
            PageDatas = pageModel.Pages.ToReadOnlyReactiveCollection();
            //SelectedItemが変化する事で発火
            CollectionSelectedItem.Where(x => x != null).Subscribe(async (x) => {
                var p = new NavigationParameters { { "PageData", x } };
                await navigationService.NavigateAsync("Page1", p);
            });
        }
    }
}
