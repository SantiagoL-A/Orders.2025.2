﻿namespace Orders.Frontend.Repositories;

public interface IRepository
{
    Task<HttpResponseWrapper<T>> GetAsync<T>(string Url);

    Task<HttpResponseWrapper<object>> PostAsync<T>(string Url, T model);

    Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model);

    Task<HttpResponseWrapper<object>> DeleteAsync(string url);

    Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model);

    Task<HttpResponseWrapper<TActionResponse>> PutAsync<T, TActionResponse>(string url, T model);
}