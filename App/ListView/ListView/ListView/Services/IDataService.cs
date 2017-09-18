using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ListView.Models;

namespace ListView.Services {
    public interface IDataService {
        Task<ObservableCollection<Person>> GetListPersionAsync();
    }
}