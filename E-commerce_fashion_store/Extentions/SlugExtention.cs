using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace E_commerce_fashion_store.Extentions
{
    public class SlugExtention
    {
        public static string GenerateSlug(string phrase)
        {
            string str = phrase.ToLower().Normalize(NormalizationForm.FormD);
            var chars = str.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            str = new string(chars);
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", " ").Trim();
            return Regex.Replace(str, @"\s", "-");
        }
    }
}
