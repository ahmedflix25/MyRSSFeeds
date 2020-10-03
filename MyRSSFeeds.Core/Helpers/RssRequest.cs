﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyRSSFeeds.Core.Helpers
{
    /// <summary>
    /// Handles the web requests to the websites by using HttpClient to get their rss data
    /// </summary>
    public class RssRequest
    {
        // MyRSSFeeds/1.0
        // Microsoft provided one "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)"
        public static string BrowserUserAgent { get; set; } = "MyRSSFeeds/1.0";

        private static readonly HttpClient HttpClient;

        static RssRequest()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("User-Agent", BrowserUserAgent);
        }

        /// <summary>
        /// Gets source data from a website as string
        /// </summary>
        /// <param name="url">Vaild url as string</param>
        /// <returns>Task string for the webpage source hopefully a xml one</returns>
        public static async Task<string> GetFeedAsStringAsync(string url)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Gets source data from website as string
        /// </summary>
        /// <param name="url">Vaild url as Uri</param>        
        /// <returns>Task string for the webpage source hopefully a xml one</returns>
        public static async Task<string> GetFeedAsStringAsync(Uri url)
        {
            return await GetFeedAsStringAsync(url.ToString());
        }
    }
}
