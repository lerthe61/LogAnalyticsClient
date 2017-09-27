# DRAFT
Simple snippet to download Log Analytics data.

## Important steps to use
Register application that should have Reader priveleges for Log Analytics. Use ClientId and ClientSecret from this application to access data.
[Connect Configuration Manager to Log Analytics](https://docs.microsoft.com/en-us/azure/log-analytics/log-analytics-sccm)


## Usage
Use code bellow to request all records that contain `COUNTER tracking`
```
var client = new LogAnalyticsDownloader(...);
var parameters = new SearchParaeters();
parameters.Query = "COUNTER tracking";
parameters.Start = date;
parameters.End = date.AddDays(1).AddMilliseconds(-1);
var data = await client.DownloadAsync(parameters);
```

### Sharp corners

* Limitation in 5000 records
* whole class hierarchy should be reviewed. Current code is a part of small utility that give us ability to create daily report in Confluence.

### References
* Based on post [Simpler Azure Management Libraries for .NET](https://azure.microsoft.com/en-us/blog/simpler-azure-management-libraries-for-net/)
* [Use portal to create an Azure Active Directory application and service principal that can access resources](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal)
* [Provide Configuration Manager with permissions to OMS](https://docs.microsoft.com/en-us/azure/log-analytics/log-analytics-sccm#provide-configuration-manager-with-permissions-to-oms)
* [Integrating applications with Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-integrating-applications)