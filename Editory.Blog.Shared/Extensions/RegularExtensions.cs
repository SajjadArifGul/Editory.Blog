using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Editory.Blog.Shared.Extensions
{
    public static class RegularExtensions
    {
        private static Regex IllegalCharacterReplacePattern = new Regex(@"[^\w]", RegexOptions.Compiled);
        private static Regex UpperCamelCaseRegex = new Regex(@"(?<!^)((?<!\d)\d|(?(?<=[A-Z])[A-Z](?=[a-z])|[A-Z]))", RegexOptions.Compiled);

        public static string SanitizeString(this string str)
        {
            string sanitizedString = string.Empty;
            if (!string.IsNullOrEmpty(str))
            {
                sanitizedString = IllegalCharacterReplacePattern.Replace(str.Trim(), "-");
                sanitizedString = sanitizedString.Replace("---", "-").Replace("--", "-");
                sanitizedString = sanitizedString.TrimStart('-').TrimEnd('-');
            }

            return sanitizedString;
        }
        public static string SanitizeLowerString(this string str)
        {
            return str.SanitizeString().ToLower();
        }
        private static string ToShortGuid(this Guid newGuid)
        {
            string modifiedBase64 = Convert.ToBase64String(newGuid.ToByteArray())
                .Replace('+', '-').Replace('/', '_') // avoid invalid URL characters
                .Substring(0, 22);
            return modifiedBase64;
        }
        private static Guid ParseShortGuid(string shortGuid)
        {
            string base64 = shortGuid.Replace('-', '+').Replace('_', '/') + "==";
            Byte[] bytes = Convert.FromBase64String(base64);
            return new Guid(bytes);
        }
        public static string ToSiteURL(this string pageURL)
        {
            var request = HttpContext.Current.Request;

            return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, pageURL);
        }
        public static string AsName(this Enum e)
        {
            return UpperCamelCaseRegex.Replace(e.ToString(), " $1");
        }
        public static string IfNullOrEmptyShowAlternative(this string str, string alternativeStr)
        {
            str = str.Trim();
            if (string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
            {
                return alternativeStr;
            }
            else
            {
                return str;
            }
        }
    }
}
