using System.Text.RegularExpressions;

namespace Arcana.WebApi.Helpers;

public class RouteHelper : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value is string val && !string.IsNullOrWhiteSpace(val))
            return Regex.Replace(val, "([a-z])([A-Z])", "$1-$2").ToLower();

        return null;
    }
}