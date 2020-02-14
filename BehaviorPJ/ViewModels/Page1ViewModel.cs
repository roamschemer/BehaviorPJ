using BehaviorPJ.Models;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace BehaviorPJ.ViewModels {
    public class Page1ViewModel : ViewModelBase {
        private PageData PageData { get; }
        public ReactiveProperty<string> Title { get; }
        public ReactiveProperty<string> Label { get; }

        public Page1ViewModel(INavigationService navigationService, PageData pageData) : base(navigationService) {
            this.PageData = pageData;
            Title = PageData.ObserveProperty(x => x.Title).ToReactiveProperty().AddTo(this.Disposable);
            Label = PageData.ObserveProperty(x => x.LabelName).ToReactiveProperty().AddTo(this.Disposable);
        }
        public override void OnNavigatedTo(INavigationParameters parameters) {
            if (parameters == null) return;
            if (parameters.ContainsKey("PageData")) PageData.Replacement((PageData)parameters["PageData"]);
        }
    }
}
