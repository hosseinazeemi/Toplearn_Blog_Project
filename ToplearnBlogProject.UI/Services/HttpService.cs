﻿using Newtonsoft.Json;
using System.Text;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.UI.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto<TResult>> PostAsync<TResult, TData>(string url, TData data)
        {
            var serializeData = JsonConvert.SerializeObject(data);

            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var finaly = JsonConvert.DeserializeObject<ResponseDto<TResult>>(result);
                if (finaly != null)
                {
                    return await Task.FromResult(finaly);
                }
            }
            return new ResponseDto<TResult>(false, "خطا", default);
        }
    }
    public interface IHttpService
    {
        Task<ResponseDto<TResult>> PostAsync<TResult, TData>(string url, TData data);
    }
}
