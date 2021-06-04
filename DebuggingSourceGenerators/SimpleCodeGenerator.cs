using Microsoft.CodeAnalysis;

namespace DebuggingSourceGenerators
{
    [Generator]
    public class SimpleCodeGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUGGENERATOR
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
        }


        public void Execute(GeneratorExecutionContext context)
    {
            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.RootNamespace", out var currentNamespace);

            currentNamespace = string.IsNullOrWhiteSpace(currentNamespace) ? "CodeHelper" : currentNamespace;
            var sourceCode = $@"namespace {currentNamespace}
{{
    public static class Messages
    {{

        public static string SayHello()
        {{
            return ""Hello"";
        }}
    }}
}}";
            context.AddSource("SayHello.g.cs", sourceCode);
        }
    }
}
