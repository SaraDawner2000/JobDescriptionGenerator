// This custom attribute allows for checking that the list submitted not only has an element,
// but specifically a non-empty string element
using System.ComponentModel.DataAnnotations;

public class TextListRequiredAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is List<string> list)
        {
            return list.Any(item => !string.IsNullOrWhiteSpace(item));
        }

        return false;
    }
}