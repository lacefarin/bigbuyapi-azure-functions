using BigBuyApi.Model.Constant;
using System.Net.Http.Json;
using System.Text.Json;

namespace BigBuyApi.Networking
{
    internal class BigBuyClient
    {
        private HttpClient _httpClient;

        internal BigBuyClient(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }

        internal async Task<List<T>?> GetBigBuyData<T>(RequestData reqData)
        {
            var endpoint = MakeEndpoint(reqData);
            var apiKey = GetApiKey();
            var bearerToken = $"Bearer {apiKey}";
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Add("Authorization", bearerToken);

            var response = await _httpClient.SendAsync(request);
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var data = await response.Content.ReadFromJsonAsync<List<T>>(jsonOptions);

            return data;
        }

        private string MakeEndpoint(RequestData reqData)
        {
            string baseUrlKey = IsSandbox() ? "BASE_URL_SANDBOX" : "BASE_URL";
            string? baseUrl = ReadEnvironmentVariable(baseUrlKey);

            if (baseUrl == null)
            {
                throw new ArgumentNullException();
            }

            string endpoint = baseUrl + reqData.Path;
            string parameters = "";
            int paramterCount = 0;

            foreach (var p in reqData.Parameters)
            {
                // Apply ampersand to all items after the first one
                string prefix = paramterCount == 0 ? "" : "&";

                if (p.Value == null)
                {
                    parameters += $"{prefix}{p.Key}";
                    continue;
                }

                parameters += $"{prefix}{p.Key}={p.Value}";

                paramterCount++;
            }

            if (string.IsNullOrEmpty(parameters))
            {
                return endpoint;
            }

            return endpoint + "?" + parameters;
        }

        private bool IsSandbox()
        {
            string environemntKey = "ENVIRONMENT";
            string? environment = ReadEnvironmentVariable(environemntKey);
            if (environment == null)
            {
                throw new ArgumentNullException();
            }

            return environment == "SANDBOX";
        }

        private string GetApiKey()
        {
            string environmentKey = IsSandbox() ? "API_KEY_SANDBOX" : "API_KEY";
            string? apiKey = ReadEnvironmentVariable(environmentKey);

            if (apiKey == null)
            { throw new ArgumentNullException(); }
            return apiKey;

        }

        private string? ReadEnvironmentVariable(string key)
        {
            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
        }
    }
}


