# DRAFT
Simple snippet to download Log Analytics data.

## Important steps to use

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