﻿using MexManager.Tools;
using System;
using System.Net.Http;

namespace MexManager
{
    public class Updater
    {
        //static Release[] releases;

        //public static Release LatestRelease;

        //public static string DownloadURL;
        //public static string Version;

        //public static bool UpdateReady;

        /// <summary>
        /// 
        /// </summary>
        public static bool UpdateCodes()
        {
            // https://github.com/akaneia/m-ex/raw/master/asm/codes.gct
            // https://github.com/akaneia/m-ex/raw/master/asm/codes.ini

            UpdateCodesFromURL(Global.MexCodePath, @"https://github.com/akaneia/m-ex/raw/master/asm/codes.gct");
            UpdateCodesFromURL(Global.MexAddCodePath, @"https://github.com/akaneia/m-ex/raw/master/asm/codes.ini");

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mexPath"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async static void UpdateCodesFromURL(string filePath, string url)
        {
            //string? hash = null;
            //if (File.Exists(filePath))
            //{
            //    hash = HashGen.ComputeSHA256Hash(File.ReadAllBytes(filePath));
            //}

            using HttpClient client = new();
            {
                Uri uri = new(url);
                await client.DownloadFileTaskAsync(uri, filePath);
            }

            //var newhash = HashGen.ComputeSHA256Hash(File.ReadAllBytes(filePath));

            //if (!string.IsNullOrEmpty(hash) &&
            //    !hash.Equals(newhash))
            //    return true;

            //return false;
        }

        /// <summary>
        /// 
        /// </summary>
        //public static void CheckLatest()
        //{
        //    string currentVersion = "";
        //    if (File.Exists(Path.Combine(ApplicationSettings.ExecutablePath, "version.txt")))
        //        currentVersion = File.ReadAllText(Path.Combine(ApplicationSettings.ExecutablePath, "version.txt"));

        //    try
        //    {
        //        var client = new GitHubClient(new ProductHeaderValue("mex-updater"));
        //        GetReleases(client).Wait();

        //        foreach (Release latest in releases)
        //        {
        //            if (latest.Prerelease &&
        //                latest.Assets.Count > 0 &&
        //                !latest.Assets[0].UpdatedAt.ToString().Equals(currentVersion))
        //            {
        //                Console.WriteLine($"Name: {latest.Name}");
        //                Console.WriteLine($"URL: {latest.Assets[0].BrowserDownloadUrl}");
        //                Console.WriteLine($"Upload Date: {latest.Assets[0].UpdatedAt}");

        //                LatestRelease = latest;
        //                DownloadURL = latest.Assets[0].BrowserDownloadUrl;
        //                Version = latest.Assets[0].UpdatedAt.ToString();
        //                UpdateReady = true;
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Failed to get latest update\n{e.ToString()}");
        //    }
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="client"></param>
        ///// <returns></returns>
        //static async Task GetReleases(GitHubClient client)
        //{
        //    List<Release> Releases = new List<Release>();
        //    foreach (Release r in await client.Repository.Release.GetAll("akaneia", "mexTool"))
        //        Releases.Add(r);
        //    releases = Releases.ToArray();
        //}
    }
}
