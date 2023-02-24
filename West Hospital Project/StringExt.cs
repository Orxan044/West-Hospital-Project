
using System.Text.RegularExpressions;

// Vacib Melumat

/// Bu classin sebebi isNumeric ve IsAlpha C# hazir olmadigina gore yazmisam
/// yeni lazim olan  yerde cagirma olanda rahat olsun


namespace StringExtN
{
    internal static class StringExt
    {
        public static bool IsNumeric(this string text)
        {
            double test;
            return double.TryParse(text, out test);
        }

        public static bool IsAlpha(this string @this)
        {
            return !Regex.IsMatch(@this, "[^a-zA-Z]");
        }
    }
}
