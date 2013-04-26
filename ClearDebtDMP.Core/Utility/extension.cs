using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Utility
{
    public static class extension
    {

        public static bool ToBoolean(this object o)
        {
            if (o.IsNotNull())
            {
                if (o.ToString().ToLower() == "yes" || o.ToString().ToLower() == "on" || o.ToString().ToLower() == "true")
                    return (true);
            }

            return (false);
        }

        public static string ToHTMLChecked(this bool b)
        {
            if (b)
                return (" checked ");

            return ("");
        }

        public static bool IsNotNullOrBlank(this string s)
        {
            if (s != null)
                if (s != "")
                    return (true);

            return (false);
        }

        public static bool IsNullOrBlank(this string s)
        {
            if (s == null)
                return (true);

            if (s == String.Empty)
                return (true);

            return (false);
        }

        public static bool IsNotNull(this object o)
        {
            if (o != null)
                return (true);

            return (false);
        }

        public static bool IsNull(this object o)
        {
            if (o == null)
                return (true);

            return (false);
        }

        public static string AddNewLine(this string s, int NumberOfNewLines, bool pWeb)
        {
            string newLine = string.Empty;

            if (pWeb)
                newLine = @"<br/>";
            else
                newLine = System.Environment.NewLine;

            for (int x = 1; x <= NumberOfNewLines; x++)
                s = String.Concat(s, newLine);

            return (s);
        }

        public static int ToInteger(this string s)
        {
            int result;

            if (int.TryParse(s, out result))
                return result;

            throw new Exception(String.Format("'{0}' is not a valid integer.", s));
        }

        public static int? GetValueOrNull(this int? i)
        {
            int? retVal = null;

            if (i.HasValue)
                retVal = i.Value;

            return retVal;
        }

        public static DateTime? GetValueOrNull(this DateTime? d)
        {
            DateTime? retVal = null;

            if (d.HasValue)
                retVal = d.Value;

            return retVal;
        }

        public static int? GetValueOrNull(this string s)
        {
            int? retVal = null;
            int value;

            if (int.TryParse(s, out value))
                retVal = value;

            return retVal;
        }

    }
}
