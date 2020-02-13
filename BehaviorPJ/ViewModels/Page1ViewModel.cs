using BehaviorPJ.Models;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;

namespace BehaviorPJ.ViewModels {
    public class Page1ViewModel : ViewModelBase, IDisposable {
        private PageData pageData;
        public ReactiveProperty<string> Title { get; set; } = new ReactiveProperty<string>();
        public Page1ViewModel(INavigationService navigationService) : base(navigationService) {
        }
        public override void OnNavigatedTo(INavigationParameters parameters) {
            pageData = new PageData((PageData)parameters["PageData"]);
            //Title.Value = pageData.Title;
            //Title = pageData.ObserveProperty(x => x.Title).ToReactiveProperty();
        }
        //後始末
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => this.Disposable.Dispose();
    }
}
