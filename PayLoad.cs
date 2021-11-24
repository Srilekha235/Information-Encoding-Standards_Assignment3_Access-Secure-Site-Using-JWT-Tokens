using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace IES_Assignment3.Models
{
    public class PayLoad
    {
        /// <summary>
        /// Issuer where was the JWT issed from
        /// </summary>
        public string issuer { get; set; }

        /// <summary>
        /// Audience for which the JWT was intended for
        /// </summary>
        public string audience { get; set; }

        /// <summary>
        /// UserName related to the User, sometimes this is the Email address
        /// or, the full name of the User
        /// </summary>
        public string unique_name { get; set; }

        /// <summary>
        /// Email address related to the User
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// You may consider using the User's birthdate
        /// This is not essential as a standard Payload entry
        /// </summary>
        public string birthdate { get; set; }

        /// <summary>
        /// A Guid representing a unique id
        /// This may be a primary key from a database entry
        /// </summary>
        /// <example>
        /// var nameid = Guid.NewGuid().ToString();
        /// </example>
        public string uniqueId { get; set; }

        /// <summary>
        /// Any Roles the User may be enrolled in
        /// </summary>
        /// <example>
        /// new[] { "Administrator" };
        /// </example>
        public string[] role { get; set; }

        /// <summary>
        /// Not Before Timestamp
        /// Defaults to Now
        /// </summary>
        /// <example>
        /// var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        /// </example>
        public long nbf { get; set; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        /// <summary>
        /// Expiry Timestamp
        /// Defaults to Now plus 3 hours
        /// </summary>
        /// <example>
        /// Three hour Access Token
        /// var Timestamp = new DateTimeOffset(DateTime.UtcNow.AddHours(3)).ToUnixTimeMilliseconds();
        /// </example>
        public long exp { get; set; } = new DateTimeOffset(DateTime.UtcNow.AddHours(3)).ToUnixTimeMilliseconds();

        /// <summary>
        /// Initiated At Timestamp
        /// Defaults to Now
        /// </summary>
        /// <example>
        /// var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        /// </example>
        public long iat { get; set; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        /// <summary>
        /// Convert the JWT Payload to Json
        /// </summary>
        /// <returns>Json Payload</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Convert the JWT Payload to Base64 used in the generation of a JWT
        /// Converts the Json output to Bytes then to Base64
        /// </summary>
        /// <returns>Base64 Encoded Payload</returns>
        public string ToBase64String()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(ToJson()));
        }
    }
}
