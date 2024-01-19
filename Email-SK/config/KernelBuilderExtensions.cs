using Microsoft.SemanticKernel;

internal static class KernelBuilderExtensions
{
    internal static IKernelBuilder WithCompletionService(this IKernelBuilder kernelBuilder)
    {
        kernelBuilder.Services.AddOpenAIChatCompletion(
            modelId: "gpt-3.5-turbo",
            apiKey: "xxxxx",
            orgId: "xxxxxx"
         );

        return kernelBuilder;

    }
}