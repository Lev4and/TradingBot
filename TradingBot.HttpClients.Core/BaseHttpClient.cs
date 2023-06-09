﻿using TradingBot.HttpClients.Core.Builders;
using TradingBot.HttpClients.Core.Extensions;
using TradingBot.HttpClients.Core.HttpRequestHandlers;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.Core
{
    public class BaseHttpClient : HttpClient
    {
        protected virtual IHttpRequestHandler HttpRequestHandler => new BaseHttpRequestHandler();

        public BaseHttpClient() : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {

        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            BaseAddress = new Uri(uri);
        }

        protected virtual async Task<ResponseModel<TResult>> GetAsync<TResult>(string uri,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => GetAsync(uri, cancellationToken));
        }

        protected virtual async Task<ResponseModel<TResult>> PostAsync<TResult>(string uri, object content,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => PostAsync(uri, content.ToStringContent(),
                cancellationToken));
        }

        protected virtual async Task<ResponseModel<TResult>> PutAsync<TResult>(string uri, object content,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => PutAsync(uri, content.ToStringContent(),
                cancellationToken));
        }

        protected virtual async Task<ResponseModel<TResult>> DeleteAsync<TResult>(string uri,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => DeleteAsync(uri, cancellationToken));
        }

        public void UseHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            DefaultRequestHeaders.Clear();

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void OverrideHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Remove(header.Key);
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
