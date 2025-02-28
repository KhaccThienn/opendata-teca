namespace Shared.Extensions
{
    /// <summary>
    /// Lớp mở rộng cho các phương thức xử lý chuỗi.
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// Chuyển đổi chuỗi đầu vào thành phiên bản không dấu bằng cách loại bỏ các ký tự đặc biệt,
        /// dấu phụ, và tùy chọn thay thế khoảng trắng và chuyển đổi thành chữ hoa.
        /// </summary>
        /// <param name="s">Chuỗi đầu vào cần chuyển đổi.</param>
        /// <param name="replaceSpace">Ký tự để thay thế khoảng trắng. Mặc định là ' ' (khoảng trắng).</param>
        /// <param name="toUpper">Chỉ định có chuyển đổi kết quả thành chữ hoa hay không. Mặc định là true.</param>
        /// <returns>Phiên bản không dấu của chuỗi đầu vào.</returns>
        public static string ToUnSign(this string s, char replaceSpace = ' ', bool toUpper = true)
        {
            // Ensure the string is not null
            s ??= "";

            // Remove all special characters
            s = Regex.Replace(s, @"[^\w\d]", " ");

            // Replace multiple consecutive spaces with a single space
            s = Regex.Replace(s, @"\s+", " ");

            // Normalize the string to decompose combined characters
            string temp = s.Normalize(NormalizationForm.FormD);

            // Remove diacritical marks
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(temp, string.Empty)
                                 .Replace('\u0111', 'd') // Replace specific characters
                                 .Replace('\u0110', 'D');

            // Replace spaces with the specified character if needed
            if (replaceSpace != ' ')
            {
                result = result.Replace(' ', replaceSpace);
            }

            // Convert the result to upper case if specified
            if (toUpper)
            {
                result = result.ToUpper();
            }

            return result;
        }

        /// <summary>
        /// Kiểm tra xem chuỗi có chứa ký tự có dấu hay không.
        /// </summary>
        /// <param name="s">Chuỗi cần kiểm tra.</param>
        /// <returns>True nếu chuỗi có chứa ký tự có dấu, ngược lại False.</returns>
        public static bool HasUnSign(this string s)
        {
            if (s == null)
            {
                return false;
            }
            s = Regex.Replace(s, @"[^\w\d]", "[CODAU]");
            if (s.Contains("[CODAU]", StringComparison.CurrentCulture))
            {
                return true;
            }
            return false;
        }

        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));
        }

        public static string FirstCharToLoower(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToLower() + string.Join("", input.Skip(1));
        }

        public static bool HasValue(this string? s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static bool HasValue(this object s)
        {
            return s != null;
        }

        public static DateTime? ToDate(this string s, string format = "dd/MM/yyyy")
        {
            return DateTime.TryParseExact(s, format, null, System.Globalization.DateTimeStyles.None, out DateTime result) ? result : null;
        }

        public static bool ValidDate(this string s, string format = "dd/MM/yyyy")
        {
            return DateTime.TryParseExact(s, format, null, System.Globalization.DateTimeStyles.None, out _);
        }

        public static bool ValidEmail(this string s)
        {
            return MailAddress.TryCreate(s, out _);
        }

        public static string RenderTemplate<T>(this string sourse, T model)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                sourse = sourse.Replace($"{{{{{prop.Name}}}}}", prop.GetValue(model)?.ToString());
            }
            return sourse;
        }

        public static long[] ToLongArray(this string source)
        {
            if (!source.HasValue()) return [];
            return source.Split(",").Select(x => long.Parse(x)).ToArray();
        }
    }
}
