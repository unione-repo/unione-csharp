
using Microsoft.Extensions.Configuration;
using UniOne = UniOne.UniOne;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var uniOne = new global::UniOne.UniOne(configuration);

var systemInfo = await uniOne.System.SystemInfo();
if (systemInfo == null)
{
    var error = uniOne.System.GetError();
}

var templateList = await uniOne.Template.List();
if (templateList == null)
{
    var error = uniOne.Template.GetError();
}

Console.WriteLine();