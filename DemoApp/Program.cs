
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using UniOne.Models;

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
    return 1;
}


var uniOne = new global::UniOne.UniOne(configuration);
List<string> errors = new List<string>();

var emailMessageData = new EmailMessageData();
var recipients = new List<EmailRecipientData> { new EmailRecipientData { EmailAddress = configuration["UniOne:FromEmail"]?.ToString() ?? "user@example.com"}};
var headers = new Dictionary<string, string> { { "X-MyHeader", "some data" }, {"List-Unsubscribe","<mailto: unsubscribe@example.com?subject=unsubscribe>, <http://www.example.com/unsubscribe/{{CustomerId}}>"} };
var attachments = new List<Attachment> { new Attachment { Name = "readme.txt", Type = "text/plain", Content = "SGVsbG8sIHdvcmxkIQ=="} };
var inline_attachments = new List<Attachment> { new Attachment { Name = "IMAGECID1", Type = "image/gif", Content = "R0lGODdhAwADAIABAP+rAP///ywAAAAAAwADAAACBIQRBwUAOw=="} };
var options = new Options(){SendAt = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), UnsubscribeUrl = "https://example.org/unsubscribe/{{CustomerId}}"};

emailMessageData.Recipients = recipients;
emailMessageData.Tags = new List<string> { "tag1" };
emailMessageData.SkipUnsubscribe = 0;
emailMessageData.GlobalLanguage = "en";
emailMessageData.TemplateEngine = "simple";
emailMessageData.Body = new Body { Html = "<b>Hello, {{to_name}}</b>", PlainText = "Hello, {{to_name}}", Amp = "<!doctype html><html amp4email><head> <meta charset=\"utf-8\"><script async src=\"https://cdn.ampproject.org/v0.js\"></script> <style amp4email-boilerplate>body{visibility:hidden}</style></head><body> Hello, AMP4EMAIL world.</body></html>"};
emailMessageData.Subject = "Test email";
emailMessageData.FromEmail = configuration["UniOne:FromEmail"]?.ToString() ?? "user@example.com";
emailMessageData.FromName = "John Smith";
emailMessageData.ReplyTo = configuration["UniOne:FromEmail"]?.ToString() ?? "user@example.com";
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
    Console.WriteLine("Email.Send - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Template.List...");
var list = await uniOne.Template.List();
if (list == null)
{
    errors.Add(("Template.List"));
    var error = uniOne.Template.GetError();
    Console.WriteLine("Template.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Generic.CustomRequest...");
var customRequest = await uniOne.Generic.CustomRequest<TemplateList>("template/list.json", "{\"limit\": 50,\"offset\":0}");
if (customRequest == null)
{
    errors.Add("Generic.CustomRequest");
    var error = uniOne.Generic.GetError();
    Console.WriteLine("Generic.CustomRequest - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing System.SystemInfo...");
var systemInfo = await uniOne.System.SystemInfo();
if (systemInfo == null)
{
    errors.Add(("System.SystemInfo"));
    var error = uniOne.System.GetError();
    Console.WriteLine("System.SystemInfo - APIErrorCode:");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Webhook.List...");
var webhookList = await uniOne.Webhook.List();
if (systemInfo == null)
{
    errors.Add("Webhook.List");
    var error = uniOne.Webhook.GetError();
    Console.WriteLine("Webhook.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Suppression.List...");
var suppressionList = await uniOne.Suppression.List(cause:SuppressionCause.Unsubscribed);
if (suppressionList == null)
{
    errors.Add("Suppression.List");
    var error = uniOne.Suppression.GetError();
    Console.WriteLine("Suppression.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Domain.List...");
var domainList = await uniOne.Domain.List("example.com");
if (domainList == null)
{
    errors.Add("Domain.List");
    var error = uniOne.Domain.GetError();
    Console.WriteLine("Domain.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing EventDump.List...");
var eventDumpList = await uniOne.EventDump.List();
if (eventDumpList == null)
{
    errors.Add("EventDump.List");
    var error = uniOne.EventDump.GetError();
    Console.WriteLine("EventDump.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Tag.List...");
var tagList = await uniOne.Tag.List();
if (tagList == null)
{
    errors.Add("Tag.List");
    var error = uniOne.Tag.GetError();
    Console.WriteLine("Tag.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Project.List...");
var projectList = await uniOne.Project.List();
if (projectList == null)
{
    errors.Add("Project.List");
    var error = uniOne.Project.GetError();
    Console.WriteLine("Project.List - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Obsolete.UnsubscribedList...");
var unsubscribedList = await uniOne.Obsolete.UnsubscribedList(configuration["UniOne:FromEmail"]?.ToString() ?? string.Empty);
if (unsubscribedList == null)
{
    errors.Add("Obsolete.UnsubscribedList");
    var error = uniOne.Obsolete.GetError();
    Console.WriteLine("Obsolete.UnsubscribedList - APIErrorCode");
    Console.WriteLine("*API Code* - " + error!.Details!.Code);
    Console.WriteLine("*Message* - " + error!.Details!.Message);
    Console.WriteLine("*Status* - " + error!.Details!.Status);
}

Console.WriteLine("Testing Webhook.Get...");
var webhook = await uniOne.Webhook.Get(configuration["UniOne:WebhookUrl"]?.ToString() ?? string.Empty);
if (webhook == null)
{
    var spamBlocked = new List<string>() { "*" };
    var emailStatus = new List<string>()
    {
        EmailStatus.Delivered, EmailStatus.Opened, EmailStatus.Clicked, EmailStatus.Unsubscribed,
        EmailStatus.Subscribed, EmailStatus.Soft_bounced, EmailStatus.Hard_bounced, EmailStatus.Spam
    };

    var events = new Event
    {
        Spam_block = spamBlocked,
        Email_status = emailStatus
    };
    
    Console.WriteLine("Webhood not found, creating new one");
    var newWebhook = await uniOne.Webhook.Set(new WebhookData()
    {
        Url = configuration["UniOne:WebhookUrl"]?.ToString(), 
        Status = WebhookStatus.Active, 
        EventFormat = "json_post",
        MaxParallel = 10,
        SingleEvent = 0,
        DeliveryInfo = 0,
        Events = events,
    });

    if (newWebhook != null)
    {
        Console.WriteLine("Webhood created successfully");
        Console.WriteLine("Testing Webhook.Get...");
        var webhook_new = await uniOne.Webhook.Get(configuration["UniOne:WebhookUrl"]?.ToString() ?? string.Empty);
        if (webhook_new == null)
        {
            errors.Add("Webhook.Get");
            var error = uniOne.Webhook.GetError();
            Console.WriteLine("Webhook.Get - APIErrorCode");
            Console.WriteLine("*API Code* - " + error!.Details!.Code);
            Console.WriteLine("*Message* - " + error!.Details!.Message);
            Console.WriteLine("*Status* - " + error!.Details!.Status);
        }
    }
   
}

if (errors.Count > 0 )
    return 1;
else 
    return 0;
