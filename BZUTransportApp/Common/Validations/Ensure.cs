namespace BZUCommon.RequestValidiation
{
    using Microsoft.Extensions.Logging;
    using System.Text.RegularExpressions;

    public static class Ensure
    {
        public static void IsNotNull(object obj, string nameOfObject)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameOfObject);
            }
        }

        public static void StringIsNullOrWhiteSpace(string obj, string nameOfObject)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                throw new ArgumentNullException(nameOfObject);
            }
        }

        public static bool StringRegexValidation(string value, string stringRegex, ILogger logger)
        {
            try
            {
                if (value == null)
                {
                    return false;
                }

                Regex regex = new Regex(stringRegex);

                if (regex.IsMatch(value.ToString()))
                    return true;

                return false;
            }
            catch (Exception)
            {
                logger.LogCritical("Error caught while trying to validtate the name");
            }

            return false;
        }
    }
}
