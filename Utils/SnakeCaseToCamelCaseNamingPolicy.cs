using System.Text;
using System.Text.Json;

namespace Utils.SnakeCaseToCamelCaseNamingPolicy;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        var builder = new StringBuilder();
        if (name.Contains('_'))
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]))
                {
                    if (i > 0)
                    {
                        builder.Append('_');
                    }
                    builder.Append(char.ToLower(name[i]));
                }
                else
                {
                    builder.Append(name[i]);
                }
            }
        }
        // Convert camelCase to snake_case
        else
        {
            {
                var parts = name.Split('_');
                var camelCaseName = parts[0];
                for (int i = 1; i < parts.Length; i++)
                {
                    camelCaseName += char.ToUpperInvariant(parts[i][0]) + parts[i].Substring(1);
                }
                return camelCaseName;
            }
        }
        return builder.ToString();
    }
}