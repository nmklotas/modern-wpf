using System;
using System.Threading;
using Caliburn.Micro;
using SampleApp.Application;
using SampleApp.TesonetApi;

namespace SampleApp.Login
{
    public class LoginViewModel : Screen
    {
        private readonly ITesonetApi _tesonetApi;
        private readonly IEventAggregator _eventAggregator;
        private string _error;
        private bool _loginInProgress;
        private string _userName;
        private string _password;

        public LoginViewModel(ITesonetApi tesonetApi, IEventAggregator eventAggregator)
        {
            _tesonetApi = tesonetApi;
            _eventAggregator = eventAggregator;
        }

        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string Error
        {
            get => _error;
            set => Set(ref _error, value);
        }

        public bool LoginInProgress
        {
            get => _loginInProgress;
            set => Set(ref _loginInProgress, value);
        }

        public bool CanLogin => !LoginInProgress;

        public async void Login()
        {
            var credentials = new Credentials(UserName, Password);
            if (!ValidateCredentials(credentials))
                return;

            try
            {
                using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    ChangeLoginInProgress(true);

                    var servers = await _tesonetApi.Login(
                        credentials,
                        cancellationTokenSource.Token);

                    await _eventAggregator.PublishOnUIThreadAsync(new LoginSucceededMessage(servers));
                }
            }
            catch (AppException ex)
            {
                Error = ex.Message;
            }
            finally
            {
                ChangeLoginInProgress(false);
            }
        }

        private bool ValidateCredentials(Credentials credentials)
        {
            if (credentials.IsValid(out var credentialsError))
            {
                Error = "";
                return true;
            }

            Error = credentialsError;
            return false;
        }

        private void ChangeLoginInProgress(bool inProgress)
        {
            LoginInProgress = inProgress;
            NotifyOfPropertyChange(() => CanLogin);
        }
    }
}