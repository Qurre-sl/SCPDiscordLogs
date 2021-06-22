using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
namespace SCPDiscordLogs
{
    [JsonObject]
    internal class Webhook
    {
        private readonly HttpClient _httpClient;
        private readonly string _webhookUrl;
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; } = new List<Embed>();
        public Webhook(string webhookUrl)
        {
            _httpClient = new HttpClient();
            _webhookUrl = webhookUrl;
        }
        public void Send(string content, IEnumerable<Embed> embeds = null)
        {
            Content = content;
            Username = Cfg.ServerName;
            AvatarUrl = Cfg.Avatar;
            Embeds.Clear();
            if (embeds != null)
            {
                Embeds.AddRange(embeds);
            }
            var contentdata = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
            _httpClient.PostAsync(_webhookUrl, contentdata);
        }
    }
    [JsonObject]
    internal class Embed : IEmbedUrl
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; } = "rich";
        [JsonProperty("description")]
        public string Description { get; set; }
        public string Url { get; set; }
        [JsonProperty("color")]
        public int Color { get; set; }
        [JsonProperty("footer")]
        public EmbedFooter Footer { get; set; }
        [JsonProperty("author")]
        public EmbedAuthor Author { get; set; }
    }

    [JsonObject]
    internal class EmbedFooter : IEmbedIconUrl, IEmbedIconProxyUrl
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        public string IconUrl { get; set; }
        public string ProxyIconUrl { get; set; }
    }
    [JsonObject]
    internal class EmbedAuthor : EmbedUrl, IEmbedIconUrl, IEmbedIconProxyUrl
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string ProxyIconUrl { get; set; }
    }
    [JsonObject]
    internal abstract class EmbedUrl : IEmbedUrl
    {
        public string Url { get; set; }
    }
    [JsonObject]
    internal interface IEmbedUrl
    {
        [JsonProperty("url")]
        string Url { get; set; }
    }
    [JsonObject]
    internal interface IEmbedIconUrl
    {
        [JsonProperty("icon_url")]
        string IconUrl { get; set; }
    }
    [JsonObject]
    internal interface IEmbedIconProxyUrl
    {
        [JsonProperty("proxy_icon_url")]
        string ProxyIconUrl { get; set; }
    }
}