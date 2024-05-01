using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LoadMoreSample
{
    public class ProductPageViewModel : INotifyPropertyChanged
    {
        public ProductPageViewModel()
        {
            Init();

            RemainingItemsCommand = new Command(LoadMoreContent);
        }

        #region Property
        private int numb_of_game_in_list = 5;
        RestService rest;
        private List<GameModel> allGame;

        private ObservableCollection<GameModel> _listGame;
        public ObservableCollection<GameModel> ListGame
        {
            get { return _listGame; }
            set { _listGame = value; OnPropertyChanged(); }
        }
        #endregion

        #region Method
        public async void Init()
        {
            rest = new RestService();
            ListGame = new ObservableCollection<GameModel>();
            allGame = await rest.GetListGame();
            if (allGame != null)
            {
                //Load 5 game from AllGame to display on phone through ListGame
                for (int i = 0; i < 5; i++)
                {
                    ListGame.Add(allGame[i]);
                }
            }
        }

        private void LoadMoreContent()
        { 
            //Simulate get item from API by load next 5 game from AllGame
            if (allGame.Count() - numb_of_game_in_list >= 5) //Game stored more than 5 => Get 5
            {
                for (int i = numb_of_game_in_list; i < numb_of_game_in_list + 5; i++)
                {
                    ListGame.Add(allGame[i]);
                }
                numb_of_game_in_list += 5;
            }
            else //Less than 5 => Get all
            {
                for (int i = numb_of_game_in_list; i < allGame.Count(); i++)
                {
                    ListGame.Add(allGame[i]);
                }
                numb_of_game_in_list = allGame.Count();
            }
        }
        #endregion

        #region Command
        public ICommand RemainingItemsCommand { get; set; }
        #endregion

        #region IPropertyChanged
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}
