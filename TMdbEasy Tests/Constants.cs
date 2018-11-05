using TMdbEasy;

namespace TMdbEasy_Tests
{
    internal static class Constants
    {
        public const string ValidApiKey = "6d4b546936310f017557b2fb498b370b";

        public static readonly EasyClient SecureTestClient;

        static Constants()
        {
            SecureTestClient = new EasyClient(ValidApiKey);
        }
    }
}
