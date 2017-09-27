using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace LogAnalyticsClient
{
    public class LogAnalyticsDownloader : ILogAnalyticsDownloader
    {
        private readonly string _subscriptionId;
        private readonly string _resourceGroup;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tenantId;
        private readonly string _workspaceName;
        private readonly ILogAnalyticsParser _logAnalyticsParser;

        public LogAnalyticsDownloader(
            string subscriptionId,
            string resourceGroup,
            string workspaceName,
            string clientId, 
            string clientSecret, 
            string tenantId, 
            ILogAnalyticsParser logAnalyticsParser)
        {
            _subscriptionId = subscriptionId;
            _resourceGroup = resourceGroup;
            _workspaceName = workspaceName;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _tenantId = tenantId;
            _logAnalyticsParser = logAnalyticsParser;
        }

        public async Task<DataTable> DownloadAsync(SearchParameters searchParameters)
        {
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(
                _clientId,
                _clientSecret,
                _tenantId,
                AzureEnvironment.AzureGlobalCloud);
            var client = new OperationalInsightsManagementClient(credentials);
            client.SubscriptionId = _subscriptionId;

            var searchResult = await client.Workspaces.GetSearchResultsAsync(_resourceGroup, _workspaceName, searchParameters);

            var tempData = new List<Dictionary<string, string>>();
            _logAnalyticsParser.Parse(searchResult, tempData);
            var dt = _logAnalyticsParser.Transform(tempData);

            return dt;
        }
    }
}