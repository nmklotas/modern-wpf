using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SampleApp.Login;
using SampleApp.Servers;

namespace SampleApp.Shell
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive,
        IHandle<LoginSucceededMessage>,
        IHandle<LogoutRequestedMessage>
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IEventAggregator _eventAggregator;

        public ShellViewModel(LoginViewModel loginViewModel, IEventAggregator eventAggregator)
        {
            _loginViewModel = loginViewModel;
            _eventAggregator = eventAggregator;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _eventAggregator.SubscribeOnPublishedThread(this);
            ActivateItem(_loginViewModel);
        }

        public async Task HandleAsync(LoginSucceededMessage message, CancellationToken cancellationToken)
        {
            ActivateItem(new ServersViewModel(message.Servers, _eventAggregator));
        }

        public async Task HandleAsync(LogoutRequestedMessage message, CancellationToken cancellationToken)
        {
            ActivateItem(_loginViewModel);
        }
    }
}