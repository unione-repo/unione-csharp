
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using UniOne.Models;
using UniOne = UniOne.UniOne;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

int startupErrors = 0;

if (Environment.GetCommandLineArgs().Count() > 1)
{
    configuration["UniOne:ServerAddress"] = Environment.GetCommandLineArgs()[1];
    configuration["UniOne:X-API-KEY"] = Environment.GetCommandLineArgs()[2];
    configuration["UniOne:WebhookUrl"] = Environment.GetCommandLineArgs()[3];
    configuration["UniOne:FromEmail"] = Environment.GetCommandLineArgs()[4];
}

Regex apiUrlRegex = new Regex(@"^(http(s):\/\/.)[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&\/\/=]*)$");
Match apiUrlMatch = apiUrlRegex.Match(configuration["UniOne:ServerAddress"] ?? string.Empty);

if (!apiUrlMatch.Success)
{
    Console.WriteLine("Api url is not valid!");
    startupErrors++;
}

if (string.IsNullOrEmpty(configuration["UniOne:X-API-KEY"]) || configuration["UniOne:X-API-KEY"]!.Length < 40)
{
    Console.WriteLine("Api key is not valid!");
    startupErrors++;
}

Regex webhookUrlRegex = new Regex(@"^(http(s):\/\/.)[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&\/\/=]*)$");
Match webhookUrlMatch = apiUrlRegex.Match(configuration["UniOne:WebhookUrl"] ?? string.Empty);

if (!webhookUrlMatch.Success)
{
    Console.WriteLine("WebHook url is not valid!");
    startupErrors++;
}

Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$");
Match emailMatch = emailRegex.Match(configuration["UniOne:FromEmail"] ?? string.Empty);

if (!emailMatch.Success)
{
    Console.WriteLine("Email address is not valid!");
    startupErrors++;
}

if (startupErrors > 0)
{
    Console.WriteLine("Startup errors: " + startupErrors);
    return;
}


var uniOne = new global::UniOne.UniOne(configuration);
List<string> errors = new List<string>();

var emailMessageData = new EmailMessageData();
var substitution = new Dictionary<Object, Object> { { "CustomerId", "12452" }, { "to_name","John Smith" } };
var recipients = new List<EmailRecipientData> { new EmailRecipientData { EmailAddress = "user@example.com" , Metadata = new Dictionary<string, string>() { { "campaign_id", "c77f4f4e-3561-49f7-9f07-c35be01b4f43" }, { "customer_hash","b253ac7" } },Substitutions = substitution}};
var headers = new Dictionary<string, string> { { "X-MyHeader", "some data" }, {"List-Unsubscribe","<mailto: unsubscribe@example.com?subject=unsubscribe>, <http://www.example.com/unsubscribe/{{CustomerId}}>"} };
var attachments = new List<Attachment> { new Attachment { Name = "readme.txt", Type = "text/plain", Content = "SGVsbG8sIHdvcmxkIQ=="} };
var inline_attachments = new List<Attachment> { new Attachment { Name = "IMAGECID1", Type = "image/gif", Content = "R0lGODdhAwADAIABAP+rAP///ywAAAAAAwADAAACBIQRBwUAOw=="} };
var options = new Options(){SendAt = "2023-09-15 12:00:00", UnsubscribeUrl = "https://example.org/unsubscribe/{{CustomerId}}", CustomBackendId = 0, SmtpPoolId = ""};

emailMessageData.Recipients = recipients;
emailMessageData.TemplateId = "3e10d6ac-2569-11ee-841f-76642cd010f7";
emailMessageData.Tags = new List<string> { "tag1" };
emailMessageData.SkipUnsubscribe = 0;
emailMessageData.GlobalLanguage = "en";
emailMessageData.TemplateEngine = "simple";
emailMessageData.Body = new Body { Html = "<b>Hello, {{to_name}}</b>", PlainText = "Hello, {{to_name}}", Amp = "<!doctype html><html amp4email><head> <meta charset=\"utf-8\"><script async src=\"https://cdn.ampproject.org/v0.js\"></script> <style amp4email-boilerplate>body{visibility:hidden}</style></head><body> Hello, AMP4EMAIL world.</body></html>"};
emailMessageData.Subject = "string";
emailMessageData.FromEmail = "user@example.com";
emailMessageData.FromName = "John Smith";
emailMessageData.ReplyTo = "user@example.com";
emailMessageData.TrackLinks = 0;
emailMessageData.TrackRead = 0;
emailMessageData.BypassGlobal = 0;
emailMessageData.BypassUnavailable = 0;
emailMessageData.BypassUnsubscribed = 0;
emailMessageData.BypassComplained = 0;
emailMessageData.Headers = headers;
emailMessageData.Attachments = attachments; 
emailMessageData.InlineAttachments = inline_attachments;
emailMessageData.Options = options;

Console.WriteLine("Testing Email.Send...");
var email = await uniOne.Email.Send(emailMessageData);
if (email == null)
{
    errors.Add(("Email.Send"));
    var error = uniOne.Email.GetError();
    Console.WriteLine("Email.Send - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Template.List...");
var list = await uniOne.Template.List();
if (list == null)
{
    errors.Add(("Template.List"));
    var error = uniOne.Template.GetError();
    Console.WriteLine("Template.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Generic.CustomRequest...");
var customRequest = await uniOne.Generic.CustomRequest<TemplateList>("template/list.json", "{\"limit\": 50,\"offset\":0}");
if (customRequest == null)
{
    errors.Add("Generic.CustomRequest");
    var error = uniOne.Generic.GetError();
    Console.WriteLine("Generic.CustomRequest - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing System.SystemInfo...");
var systemInfo = await uniOne.System.SystemInfo();
if (systemInfo == null)
{
    errors.Add(("System.SystemInfo"));
    var error = uniOne.System.GetError();
    Console.WriteLine("System.SystemInfo - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Webhook.List...");
var webhookList = await uniOne.Webhook.List();
if (systemInfo == null)
{
    errors.Add("Webhook.List");
    var error = uniOne.Webhook.GetError();
    Console.WriteLine("Webhook.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Suppression.List...");
var suppressionList = await uniOne.Suppression.List();
if (suppressionList == null)
{
    errors.Add("Suppression.List");
    var error = uniOne.Suppression.GetError();
    Console.WriteLine("Suppression.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Domain.List...");
var domainList = await uniOne.Domain.List("");
if (domainList == null)
{
    errors.Add("Domain.List");
    var error = uniOne.Domain.GetError();
    Console.WriteLine("Domain.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing EventDump.List...");
var eventDumpList = await uniOne.EventDump.List();
if (eventDumpList == null)
{
    errors.Add("EventDump.List");
    var error = uniOne.EventDump.GetError();
    Console.WriteLine("EventDump.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Tag.List...");
var tagList = await uniOne.Tag.List();
if (tagList == null)
{
    errors.Add("Tag.List");
    var error = uniOne.Tag.GetError();
    Console.WriteLine("Tag.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Project.List...");
var projectList = await uniOne.Project.List();
if (projectList == null)
{
    errors.Add("Project.List");
    var error = uniOne.Project.GetError();
    Console.WriteLine("Project.List - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Obsolete.UnsubscribedList...");
var unsubscribedList = await uniOne.Obsolete.UnsubscribedList(configuration["UniOne:FromEmail"]?.ToString() ?? string.Empty);
if (unsubscribedList == null)
{
    errors.Add("Obsolete.UnsubscribedList");
    var error = uniOne.Obsolete.GetError();
    Console.WriteLine("Obsolete.UnsubscribedList - " + error.Details.CodeDescription);
}

Console.WriteLine("Testing Webhook.Get...");
var webhook = await uniOne.Webhook.Get(configuration["UniOne:WebhookUrl"]?.ToString() ?? string.Empty);
if (webhook == null)
{
    errors.Add("Webhook.Get");
    var error = uniOne.Webhook.GetError();
    Console.WriteLine("Webhook.Get - " + error.Details.CodeDescription);
}

Console.WriteLine("Error count:" + errors.Count + "/12" );
if (errors.Count > 0)
{
    Console.WriteLine("Error List:");
    foreach (var error  in errors)
    {
        Console.WriteLine(" - " + error);
    }
}