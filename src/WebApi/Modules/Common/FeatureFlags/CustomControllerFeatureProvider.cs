using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Collections;
using System.Reflection;

namespace WebApi.Modules.Common.FeatureFlags;

public sealed class CustomControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private readonly IFeatureManager _featureManager;

    public CustomControllerFeatureProvider(IFeatureManager featureManager) => _featureManager = featureManager;

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        if(feature == null) throw new ArgumentNullException(nameof(feature));

        for(var i = feature.Controllers.Count - 1; i >= 0; i--)
        {
            var controller = feature.Controllers[i].AsType();
            foreach(var customAttribute in controller.CustomAttributes)
            {
                if(customAttribute.AttributeType.FullName == typeof(FeatureGateAttribute).FullName)
                {
                    var constructorArgument = customAttribute.ConstructorArguments.First();
                    foreach (var argumentValue in constructorArgument.Value as IEnumerable)
                    {
                        var typedArgument = (CustomAttributeTypedArgument)argumentValue!;
                        var typedArgumentValue = (Features)(int)typedArgument.Value!;
                        bool isFeatureEnabled = this._featureManager
                            .IsEnabledAsync(typedArgumentValue.ToString())
                            .ConfigureAwait(false)
                            .GetAwaiter()
                            .GetResult();
                        if (!isFeatureEnabled)
                        {
                            feature.Controllers.RemoveAt(i);
                        }
                    }
                    
                  
                }
            }
        }
    }
}
