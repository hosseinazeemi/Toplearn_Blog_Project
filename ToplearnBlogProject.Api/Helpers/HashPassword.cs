namespace ToplearnBlogProject.Api.Helpers
{
    public static class HashPassword
    {
        private static string GetSalt(int workFactor)
        {
            return BCrypt.Net.BCrypt.GenerateSalt(workFactor);
        }

        public static string Generate(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password , GetSalt(12));
        }

        public static bool Verify(string password , string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password , hash);
        }
    }
}
