using System.Reflection;
using Mapster;

namespace MappingToolTest;

public class ApiModelGenerator : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        var namespaceName = typeof(Domain.Person).Namespace ?? "MappingToolTest.Domain";
        config.AdaptTo("[name]Dto")
            .ForAllTypesInNamespace(typeof(Domain.Person).Assembly, namespaceName);

        config.GenerateMapper("[name]Mapper")
            .ForAllTypesInNamespace(typeof(Domain.Person).Assembly, namespaceName);
    }
}
