
using Microsoft.Extensions.Configuration;
using UniOne.Models;
using UniOne = UniOne.UniOne;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

if (Environment.GetCommandLineArgs().Count() > 0)
{
    configuration["ServerAddress"] = Environment.GetCommandLineArgs()[1];
    configuration["X-API-KEY"] = Environment.GetCommandLineArgs()[2];
    configuration["WebhookUrl"] = Environment.GetCommandLineArgs()[3];
    configuration["FromEmail"] = Environment.GetCommandLineArgs()[4];
}

var uniOne = new global::UniOne.UniOne(configuration);
List<string> errors = new List<string>();


var list = await uniOne.Template.List();
if (list == null)
{
    errors.Add(("Template.List"));
    var error = uniOne.Template.GetError();
}

var customRequest = await uniOne.Generic.CustomRequest<TemplateList>("template/list.json", "{\"limit\": 50,\"offset\":0}");
if (customRequest == null)
{
    errors.Add("Generic.CustomRequest");
    var error = uniOne.Generic.GetError();
}


var systemInfo = await uniOne.System.SystemInfo();
if (systemInfo == null)
{
    errors.Add(("System.SystemInfo"));
    var error = uniOne.System.GetError();
}

var webhookList = await uniOne.Webhook.List();
if (systemInfo == null)
{
    errors.Add("Webhook.List");
    var error = uniOne.Webhook.GetError();
}

var suppressionList = await uniOne.Suppression.List();
if (suppressionList == null)
{
    errors.Add("Suppression.List");
    var error = uniOne.Suppression.GetError();
}

var domainList = await uniOne.Domain.List("");
if (domainList == null)
{
    errors.Add("Domain.List");
    var error = uniOne.Domain.GetError();
}

var eventDumpList = await uniOne.EventDump.List();
if (eventDumpList == null)
{
    errors.Add("EventDump.List");
    var error = uniOne.EventDump.GetError();
}

var tagList = await uniOne.Tag.List();
if (tagList == null)
{
    errors.Add("Tag.List");
    var error = uniOne.Tag.GetError();
}

var projectList = await uniOne.Project.List();
if (projectList == null)
{
    errors.Add("Project.List");
    var error = uniOne.Project.GetError();
}

var unsubscribedList = await uniOne.Obsolete.UnsubscribedList(configuration["FromEmail"]?.ToString() ?? string.Empty);
if (unsubscribedList == null)
{
    errors.Add("Obsolete.UnsubscribedList");
    var error = uniOne.Obsolete.GetError();
}

var webhook = await uniOne.Webhook.Get(configuration["WebhookUrl"]?.ToString() ?? string.Empty);
if (webhook == null)
{
    errors.Add("Webhook.Get");
    var error = uniOne.Webhook.GetError();
}

Console.WriteLine("Error count:" + errors.Count + "/11" );
if (errors.Count > 0)
{
    Console.WriteLine("Error List:");
    foreach (var error  in errors)
    {
        Console.WriteLine(" - " + error);
    }
}