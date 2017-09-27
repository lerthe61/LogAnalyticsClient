using System.Collections.Generic;
using System.Data;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace LogAnalyticsClient
{
    public interface ILogAnalyticsParser
    {
        void Parse(SearchResultsResponse searchResult, List<Dictionary<string, string>> data);
        DataTable Transform(List<Dictionary<string, string>> data);
    }
}