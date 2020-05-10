using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SCM.Model
{
    public static class CommonUtilties
    {
        public static int ToInt32(this string input)
        {
            int output;
            Int32.TryParse(input, out output);
            return output;
        }

        public static long ToInt64(this string input)
        {
            long output;
            Int64.TryParse(input, out output);
            return output;
        }

        public static int? ToNullableInt32(this string input)
        {
            int output;

            if (Int32.TryParse(input, out output))
                return output;

            return null;
        }

        public static long? ToNullableInt64(this string input)
        {
            long output;

            if (Int64.TryParse(input, out output))
                return output;

            return null;
        }

        public static float ToFloat(this string input)
        {
            float output;
            float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out output);
            return output;
        }

        public static float? ToNullableFloat(this string input)
        {
            float output;

            if (float.TryParse(input, out output))
                return output;

            return null;
        }

        public static bool ToBool(this string input)
        {
            bool output;
            Boolean.TryParse(input, out output);
            return output;
        }

        public static float ToRound(this float input, int round)
        {
            return (float)Math.Round(input, round);
        }

        public static string ToRound(this string input, int round)
        {
            return (string)Math.Round(input.ToFloat(), round).ToString();
        }

        public static string FormatToDecimal(this string number, int decPlaces)
        {
            return number.ToFloat().ToRound(decPlaces).ToString("#0." + new String('0', decPlaces));
        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }

        public static string ToFormatedDateTime(this DateTime? input, string format = "dd-MM-yyyy HH:mm")
        {
            return input.HasValue ? input.Value.ToString(format) : string.Empty;
        }

        public static string ToFormatedDateTime(this DateTime input, string format = "dd-MM-yyyy HH:mm")
        {
            return input.ToString(format);
        }

        public static DateTime? FromFormatedDateTime(this string input, string format = "dd-MM-yyyy HH:mm")
        {
            DateTime output;
            DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out output);
            return output;
        }

        public static string PostSeprator(this string input, char seprator)
        {

            int l = input.IndexOf(seprator);
            if (l > 0)
            {
                return input.Substring((l + 1), (input.Length - l - 1));
            }
            return input;
        }

        public static List<T> ConvertDataTableToCustomList<T>(DataTable table)
        {
            try
            {
                T tempT = Activator.CreateInstance<T>();
                var tType = tempT.GetType();
                List<T> list = new List<T>();
                foreach (var row in table.Rows.Cast<DataRow>())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (table.Columns.Contains(prop.Name))
                        {
                            var propertyInfo = tType.GetProperty(prop.Name);
                            var rowValue = Convert.ToString(row[prop.Name]) != "" && Convert.ToString(row[prop.Name]) != "NULL" ? row[prop.Name] : DBNull.Value;
                            var t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                            try
                            {
                                object safeValue = (rowValue == null || DBNull.Value.Equals(rowValue)) ? null : Convert.ChangeType(rowValue, t);
                                propertyInfo.SetValue(obj, safeValue, null);
                            }
                            catch (Exception ex)
                            {
                                //this write exception to my logger
                            }
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
