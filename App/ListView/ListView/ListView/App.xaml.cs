using ListView.Services;
using ListView.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace ListView {
    public partial class App {
        public App(IPlatformInitializer initializer = null) : base(initializer) {
        }

        protected override void OnInitialized() {
            InitializeComponent();
            NavigationService.NavigateAsync("Navigation/Main");
        }

        protected override void RegisterTypes() {
            Container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
            Container.RegisterTypeForNavigation<MainPage>("Main");
        }
    }
}