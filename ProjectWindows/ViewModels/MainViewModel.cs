using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ProjectWindows.Models;
using ProjectWindows.Repositories;
using ProjectWindows.ViewModel;

namespace ProjectWindows.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set 
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null) 
            {
                    CurrentUserAccount.UserName = user.Username;
                    CurrentUserAccount.DisplayName = $"Welcome{user.Name}{user.LastName};)";
                    CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logger in";
                //Hide child views
            }
        }
    }
}
