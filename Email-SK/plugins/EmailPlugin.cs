namespace Plugins;

using System.ComponentModel;
using Microsoft.SemanticKernel;

public class EmailPlugin
{
    [KernelFunction, Description("generate the email template with the given message")]
    public static string EmailTemplate([Description("The message that needs to be used for sending email")]
     string message)
    {
        return "Email Template" + message;
    }

    [KernelFunction, Description("Sends the email with the given input email templated message")]
    public static string SendEmail([Description("The email templated message that will be used for sending email")]
     string message)
    {
        return "Success:::Email  Sent  with  message ::" + message;
    }

}