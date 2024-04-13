using FluentValidation.Results;

namespace Core.Extensions
{
    public static class FluentValidationExtensions
    {
        public static Dictionary<string, IEnumerable<string>> ErrorsToDictionary(this ValidationResult result)
            => result.Errors
                  .GroupBy(x => x.PropertyName)
                  .ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage));

    }
}
