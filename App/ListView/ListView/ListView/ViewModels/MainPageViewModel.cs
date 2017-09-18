using System.Collections.ObjectModel;
using ListView.Models;
using ListView.Services;
using Prism.Navigation;

namespace ListView.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private readonly IDataService _dataService;

        private ObservableCollection<Person> _listPerson;

        public MainPageViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService) {
            _dataService = dataService;
            Title = "List Person";
        }

        public ObservableCollection<Person> ListPerson {
            get => _listPerson;
            set => SetProperty(ref _listPerson, value);
        }

        public override async void OnNavigatingTo(NavigationParameters parameters) {
            base.OnNavigatingTo(parameters);
            ListPerson = await _dataService.GetListPersionAsync();
        }
    }
}