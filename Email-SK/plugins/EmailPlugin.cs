﻿namespace Plugins;

using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using Microsoft.SemanticKernel;


public class EmailPlugin
{

    [KernelFunction, Description("generates the recipeint email address")]
    public static string RecipientEmailAddress()
    {
        return "sainiteshad@gmail.com";

    }


    [KernelFunction, Description("generate the email template with the given message")]
    public static string EmailTemplate([Description("The message that needs to be used for sending email")]
     string message)
    {
        return "Email Template" + message;
    }


    [KernelFunction, Description("Sends the email with the given input email templated message and the inputted receipient email address")]
    public static string SendEmail([Description("The email templated message that will be used for sending email")]
     string message, [Description("The recepient email to whom the email or message needs to be sent")]
     string emailreceipient)
    {

        using (var client = new SmtpClient())
        {
            
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("sainiteshad@GMAIL.COM", ""); //xxxxxxx 



            using (var mailMessage = new MailMessage(
                from: new MailAddress("sainiteshad@gmail.com", "AutoGenerated"),
                to: new MailAddress(emailreceipient, "Sai Nitesh")
                ))
            {

                mailMessage.Subject = "SK Config";
                mailMessage.Body = "..........-------................... Semantic Kernel .....------........"+ message;

                client.Send(mailMessage);
            }
        }

        return "Success:::Email  Sent  with  message ::" + message;
    }

}