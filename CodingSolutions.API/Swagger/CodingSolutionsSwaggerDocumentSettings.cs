using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace CodingSolutions.API.Swagger;

public class CodingSolutionsSwaggerDocumentSettings : IDocumentProcessor
{
    public void Process(DocumentProcessorContext context)
    {
        context.Document.Info.Title = "Coding Solutions API";
        context.Document.Info.Description = "API designed as Take Home for Coding Solutions";
        context.Document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "Lucas Baldasso",
            Email = "biolucasb@gmail.com"
        };
    }
}