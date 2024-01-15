using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Plugins;

var builder = Kernel.CreateBuilder();

builder.WithCompletionService();
builder.Plugins.AddFromType<EmailSender>();

var kernel = builder.Build();

ChatHistory history =[];

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

while(true)
{
    Console.Write("User > ");
    history.AddUserMessage(Console.ReadLine()!);

    //Enable auto function calling

    OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
    {
        ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
    };

    var result = chatCompletionService.GetStreamingChatMessageContentsAsync(
            history,
            executionSettings: openAIPromptExecutionSettings,
            kernel: kernel
        );

    String fullMessage = "";

    var first = true;
    await foreach( var content in result)
    {
        if(content.Role.HasValue && first)
        {
            Console.Write("Assistant > ");
            first = false;
        }
        Console.Write(content.Content);
        fullMessage += content.Content;
    }
    Console.WriteLine();
    history.AddAssistantMessage(fullMessage);
}