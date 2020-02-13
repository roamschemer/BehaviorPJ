using BehaviorPJ.Models;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace BehaviorPJ.ViewModels {
    public class Page1ViewModel : ViewModelBase, IDisposable {
        private readonly PageData pageData = new PageData();
        public ReactiveProperty<string> Title { get; private set; }
        public ReactiveProperty<string> Label { get; private set; }

        public Page1ViewModel(INavigationService navigationService) : base(navigationService) {
            Title = pageData.ObserveProperty(x => x.Title).ToReactiveProperty().AddTo(this.Disposable);
            Label = pageData.ObserveProperty(x => x.LabelName).ToReactiveProperty().AddTo(this.Disposable);
        }
        public override void OnNavigatedTo(INavigationParameters parameters) {
            pageData.Replacement((PageData)parameters["PageData"]);
        }
        //後始末
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => this.Disposable.Dispose();
    }
}
