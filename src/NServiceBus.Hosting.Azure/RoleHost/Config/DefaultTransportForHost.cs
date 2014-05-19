namespace NServiceBus.Hosting.Azure.Roles.Handlers
{
    using Settings;
    using Transports;

    public class DefaultTransportForHost : IWantToRunBeforeConfigurationIsFinalized
    {
        public void Run(Configure config)
        {

            if (Configure.Instance.Configurer.HasComponent<ISendMessages>())
            {
                return;
            }

            if (SettingsHolder.GetOrDefault<TransportDefinition>("NServiceBus.Transport.SelectedTransport") != null)
            {
                return;
            }

           // is this really required ???
           // Configure.Instance.UseTransport<AzureStorageQueue>();
        }
    }
}