using System.Net.Http.Headers;
using System.Text.Json;

namespace Ttlock.Api.Services
{
    public class TtlockOptions
    {
        public string BaseUrl { get; set; } = "https://api.ttlock.com";
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }

    public class TtlockClient
    {
        private readonly HttpClient httpClient;
        private readonly TtlockOptions options;

        public TtlockClient(HttpClient httpClient, TtlockOptions options)
        {
            this.httpClient = httpClient;
            this.options = options;
            this.httpClient.BaseAddress = new Uri(options.BaseUrl);
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // TODO: Implement OAuth/token management per TTLock API docs
        public async Task<bool> PingAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using var req = new HttpRequestMessage(HttpMethod.Get, "/v3/lock/list" );
                using var resp = await httpClient.SendAsync(req, cancellationToken);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}