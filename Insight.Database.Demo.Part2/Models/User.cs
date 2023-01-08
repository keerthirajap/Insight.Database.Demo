using System;

namespace Insight.Database.Demo.Part2
{
    public class User
    {
        public long UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
