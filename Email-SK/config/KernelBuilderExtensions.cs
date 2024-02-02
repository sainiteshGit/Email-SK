﻿using Microsoft.SemanticKernel;

internal static class KernelBuilderExtensions
{
    internal static IKernelBuilder WithCompletionService(this IKernelBuilder kernelBuilder)
    {
        kernelBuilder.Services.AddOpenAIChatCompletion(
            modelId: "gpt-3.5-turbo",
            apiKey: "xxxxxxxxxx",
            orgId: "xxxxxxxxxxxxx"
         );

        return kernelBuilder;

    }
}