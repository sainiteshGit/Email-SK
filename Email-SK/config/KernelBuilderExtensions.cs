using Microsoft.SemanticKernel;

internal static class KernelBuilderExtensions
{
    internal static IKernelBuilder WithCompletionService(this IKernelBuilder kernelBuilder)
    {
        kernelBuilder.Services.AddOpenAIChatCompletion(
            modelId: "gpt-3.5-turbo",
            apiKey: "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",
            orgId: "org-q8LduSfFw61g4CafCyxzHThs"
         );

        return kernelBuilder;

    }
}