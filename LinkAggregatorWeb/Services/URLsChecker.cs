namespace LinkAggregatorWeb.Services
{
    public static class URLsChecker
    {
        public static string CheckURL(string url)
        {
            string prefix =  url.Substring(0, 7);
            string newUrl =  url;

            if (prefix != "https:/" && prefix != "http://")
            {
                newUrl = "https://" + url;
            }
                return newUrl;
        }
    }
}
