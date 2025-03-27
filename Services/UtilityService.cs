
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace IPS_survey.Services
{
    public class UtilityService
    {
        public static readonly JsonSerializerOptions SharedOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,

        };
        public static string GenerateAsymptoticHash(DateTime correctDateValue,
       string password, string clientIdValue)
        {
            string seedValue = GetSeedHeader(correctDateValue, clientIdValue!, password);
            return seedValue;
        }
        private static string GetSeedHeader(DateTime utcdate, string ClientID, string Password)
        {
            string date = utcdate.ToString("yyyy-MM-ddHHmmss");
            string data = date + ClientID + Password;
            return SHA512(data);
        }
        public static string SHA512(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hashedInputBytes = System.Security.Cryptography.SHA512.HashData(bytes);
            StringBuilder hashedInputStringBuilder = new(128);
            foreach (byte b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("x2"));
            return hashedInputStringBuilder.ToString();
        }

        public static IFormFile ConvertFileToIFormFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            fileStream.Close();

            var fileName = Path.GetFileName(filePath);
            var contentType = GetContentType(filePath); // Get MIME type
            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return formFile;
        }
        private static string GetContentType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                ".txt" => "text/plain",
                ".json" => "application/json",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".csv" => "text/csv",
                _ => "application/octet-stream" // Default binary type
            };
        }
        /// <summary>
        /// Extracts file type from Base64 string and saves it as a file.
        /// </summary>
        public static string ConvertBase64ToFile(string base64String, string outputDirectory)
        {
            // Extract file extension
            string fileExtension = ExtractFileType(base64String);

            // Remove the data URI prefix if present
            string cleanBase64 = base64String.Contains(",") ? base64String.Split(',')[1] : base64String;

            // Convert Base64 to byte array
            byte[] fileBytes = Convert.FromBase64String(cleanBase64);

            // Generate unique filename
            string fileName = $"{Guid.NewGuid()}.{fileExtension}";
            string filePath = Path.Combine(outputDirectory, fileName);

            // Write file
            File.WriteAllBytes(filePath, fileBytes);

            return filePath;
        }

        /// <summary>
        /// Extracts the file type from a Base64 data URI.
        /// </summary>
        public static string ExtractFileType(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }

    }
}