﻿using System.ComponentModel;
using System.Diagnostics;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning.Handlebars;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins;

public class EmailSender
{
    [KernelFunction]
    [Description("Sends a message as an email with given message to the recipientemail address provided")]
    public async Task<string> SendAsync(
        Kernel kernel,
        [Description("The message that needs to be send to the recipient email address using the email template; describe it in 2-3 sentences to ensure full context is provided")] string message
        )
    {
        var kernelWithMail = kernel.Clone();

        kernelWithMail.Plugins.Remove(kernelWithMail.Plugins["EmailSender"]);

        kernelWithMail.Plugins.AddFromType<EmailPlugin>();

#pragma warning disable SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.


        var planner = new HandlebarsPlanner(new HandlebarsPlannerOptions() { AllowLoops = true });

        //Create a plan
        var plan = await planner.CreatePlanAsync(kernelWithMail, message);
        Console.WriteLine($"Plan::: {plan}");

        //Execute the plan

        var result = (await plan.InvokeAsync(kernelWithMail,[])).Trim();

        Console.WriteLine($"Results :: {result}");
#pragma warning restore SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

        return result;

    }
}