﻿using BehaviorPJ.Models;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace BehaviorPJ.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        public ReadOnlyReactiveCollection<PageData> PageDatas { get; }
        public AsyncReactiveCommand<PageData> ListTapped { get;} 
        public MainPageViewModel(INavigationService navigationService, PageModel pageModel) : base(navigationService) {
            PageDatas = pageModel.Pages.ToReadOnlyReactiveCollection();
            ListTapped = new AsyncReactiveCommand<PageData>()
                .WithSubscribe(async (x) => {
                    var p = new NavigationParameters { { "PageData", x } };
                    await navigationService.NavigateAsync("Page1", p);
                });
        }
    }
}
