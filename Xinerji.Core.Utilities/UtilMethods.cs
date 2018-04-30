using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xinerji.Utilities
{
    public static class UtilMethods
    {
        #region ToEnum
        public static T ToEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }
        #endregion

        #region RandomString
        public static string RandomString(int size)
        {
            Random _rng = new Random();
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
        #endregion

        #region RandomPassword
        public static string RandomPassword()
        {
            var random = new Random();

            string lowerDictionaryString = "abcdefghijklmnopqrstuvwxyz";
            string uppperDictionaryString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numberDictionaryString = "0123456789";

            StringBuilder resultStringBuilder = new StringBuilder();

            switch (random.Next(2))
            {
                case 0:
                    resultStringBuilder.Append(lowerDictionaryString[random.Next(lowerDictionaryString.Length)]);
                    break;
                case 1:
                    resultStringBuilder.Append(uppperDictionaryString[random.Next(uppperDictionaryString.Length)]);
                    break;
                case 2:
                    resultStringBuilder.Append(numberDictionaryString[random.Next(numberDictionaryString.Length)]);
                    break;
            }

            for (int i = 0; i < 2; i++)
            {
                resultStringBuilder.Append(lowerDictionaryString[random.Next(lowerDictionaryString.Length)]);
            }

            for (int i = 0; i < 2; i++)
            {
                resultStringBuilder.Append(uppperDictionaryString[random.Next(uppperDictionaryString.Length)]);
            }

            for (int i = 0; i < 2; i++)
            {
                resultStringBuilder.Append(numberDictionaryString[random.Next(numberDictionaryString.Length)]);
            }

            switch (random.Next(2))
            {
                case 0:
                    resultStringBuilder.Append(lowerDictionaryString[random.Next(lowerDictionaryString.Length)]);
                    break;
                case 1:
                    resultStringBuilder.Append(uppperDictionaryString[random.Next(uppperDictionaryString.Length)]);
                    break;
                case 2:
                    resultStringBuilder.Append(numberDictionaryString[random.Next(numberDictionaryString.Length)]);
                    break;
            }

            return resultStringBuilder.ToString();
        }
        #endregion

        #region ConvertSqlToDate
        public static DateTime ConvertSqlToDate(string date, char splitChar)
        {
            return ConvertSqlToDateTime(date + " 00:00:00", splitChar);
        }
        #endregion

        #region ConvertSqlToDate
        public static DateTime ConvertSqlToDateTime()
        {
            return ConvertSqlToDateTime("");
        }
        #endregion

        #region ConvertSqlToDateTime
        public static DateTime ConvertSqlToDateTime(string date)
        {
            if (date == null)
            {
                date = "";
            }

            date = date.Replace('/', '.');

            if (date.Trim() == "")
            {
                date = "01.01.1901 00:00:00";
            }
            return ConvertSqlToDateTime(date, '.');
        }
        #endregion

        #region ConvertSqlToDateTime
        public static DateTime ConvertSqlToDateTime(string date, char splitChar)
        {
            string[] tdate = date.Split(splitChar);

            date = tdate[0].PadLeft(2, '0') + "." + tdate[1].PadLeft(2, '0') + "." + tdate[2];

            return DateTime.ParseExact(date,
                                  "dd.MM.yyyy HH:mm:ss",
                                   System.Globalization.CultureInfo.InvariantCulture);
        }
        #endregion

        #region MaskingName
        public static string MaskingName(string name)
        {
            string tempName = "";

            string[] nameArray = name.Split(' ');

            for (int i = 0; i < nameArray.Length; i++)
            {
                nameArray[i] = nameArray[i].Trim();
                if (nameArray[i].Length > 2)
                {
                    tempName += nameArray[i].Substring(0, nameArray[i].Length - 2) + String.Concat(" * * ");
                }
            }

            return tempName.TrimEnd();
        }
        #endregion

        #region FormatPhoneNumber
        public static string FormatPhoneNumber(string phoneNumber)
        {

            return phoneNumber.Substring(0, 4) + " " + phoneNumber.Substring(4, 3) + " " + phoneNumber.Substring(7, 4);
        }
        #endregion

        #region MaskingPhoneNumber
        public static string MaskingPhoneNumber(string phoneNumber)
        {
            phoneNumber = FormatPhoneNumber(phoneNumber);
            //0553 203 8833
            return phoneNumber.Substring(0, 9) + "****";
        }
        #endregion

        #region GenerateUniqueNumber
        public static string GenerateUniqueNumber()
        {
            DateTime _now = DateTime.Now;
            string _dd = _now.ToString("dd"); //
            string _mm = _now.ToString("MM");
            string _yy = _now.ToString("yyyy");
            string _hh = _now.Hour.ToString();
            string _min = _now.Minute.ToString();
            string _ss = _now.Second.ToString();
            string _mmm = _now.Millisecond.ToString();

            string _uniqueId = _mmm + _dd + _hh + _mm + _min + _ss + _yy;

            return _uniqueId;
        }
        #endregion

        #region SplitList
        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
        #endregion

        #region GetDifferenceInYears
        public static int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            //Excel documentation says "COMPLETE calendar years in between dates"
            int years = endDate.Year - startDate.Year;

            if (startDate.Month == endDate.Month &&// if the start month and the end month are the same
                endDate.Day < startDate.Day)// BUT the end day is less than the start day
            {
                years--;
            }
            else if (endDate.Month < startDate.Month)// if the end month is less than the start month
            {
                years--;
            }

            return years;
        }
        #endregion

        #region ValidateTCKN
        public static bool ValidateTCKN(string tcNumber)
        {

            bool returnvalue = false;
            try
            {
                if (tcNumber.Length == 11)
                {
                    Int64 ATCNO, BTCNO, TcNo;
                    long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                    TcNo = Int64.Parse(tcNumber);

                    ATCNO = TcNo / 100;
                    BTCNO = TcNo / 100;

                    C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                    Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                    Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                    returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
                }
            }
            catch
            {

            }
            return returnvalue;
        }
        #endregion

        #region ValidateIban
        public static bool ValidateIban(string ibanValue)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ibanValue, "^[A-Z0-9]"))
            {
                ibanValue = ibanValue.Replace(" ", String.Empty);
                string iban =
                ibanValue.Substring(4, ibanValue.Length - 4) + ibanValue.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in iban)
                {
                    int v;
                    if (Char.IsLetter(c))
                    {
                        v = c - asciiShift;
                    }
                    else
                    {
                        v = int.Parse(c.ToString());
                    }
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ValidatePlaque
        public static bool ValidatePlate(string plaque)
        {
            string sPattern = @"[0-8][0-9][A-Z]{1,3}[0-9]{2,5}";

            return System.Text.RegularExpressions.Regex.IsMatch(plaque, sPattern);
        }
        #endregion

        #region SerializeObjectToXml
        public static string SerializeObjectToXml<T>(T data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());

            using (StringWriter str = new StringWriter())
            {
                xmlSerializer.Serialize(str, data);

                return str.ToString();
            }
        }
        #endregion

        #region StripHTML
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        #endregion


        public static string SerializeObjectToJson<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray());
            return retVal;
        }

        public static T DeserializeJsonToObject<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }
    }
}
