using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace LogAnalyticsClient
{
    public interface ILogAnalyticsDownloader
    {
        Task<DataTable> DownloadAsync(SearchParameters searchParameters);
    }
}