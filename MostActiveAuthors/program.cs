using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
class Result
{
    /*
    * Complete the 'getUsernames' function below.
    *
    * The function is expected to return a STRING_ARRAY.
    * The function accepts INTEGER threshold as parameter.
    */
    public static List<string> getUsernames(int threshold)
    {
        var result = new List<string>();
        var users = new List<Data>();
        var pages = 1;
        var current = 1;
        using (var client = new WebClient())
        {
            do
            {
                var resultApi = GetApi(client, current++);
                users.AddRange(resultApi.data.Where(o => o.submission_count >
                                                         threshold));
                pages = resultApi.total_pages;
            } while (current <= pages);
        }
        return users.Select(o => o.username).ToList();
    }

    public static ModelApiPage GetApi(WebClient client, int page)
    {
        var url = $"https://jsonmock.hackerrank.com/api/article_users/search?page={page}";
        return JsonConvert.DeserializeObject<ModelApiPage>
            (client.DownloadString(url));
    }
}
class ModelApiPage
{
    public string page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<Data> data { get; set; }
}
class Data
{
    public int id { get; set; }
    public string username { get; set; }
    public string about { get; set; }
    public int submitted { get; set; }
    public DateTime updated_at { get; set; }
    public int submission_count { get; set; }
    public int comment_count { get; set; }
    public int created_at { get; set; }
}
