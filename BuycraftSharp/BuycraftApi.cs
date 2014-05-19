using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace BuycraftSharp
{
	public class BuycraftApi
	{
		public string ApiKey { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BuycraftSharp.BuycraftApi"/> class, with the specified API key.
		/// </summary>
		/// <param name="ApiKey">The Buycraft API key.</param>
		public BuycraftApi (string ApiKey)
		{
			this.ApiKey = ApiKey;
		}

		/// <summary>
		/// Authenticate with the Buycraft API.
		/// </summary>
		/// <returns>The authentication reply from the Buycraft API.</returns>
		public BuycraftApiResponses.AuthenticationPayload Authenticate()
		{
			IDictionary<string, object> parameters = CreateBaseParameters();
			parameters["action"] = "info";
			parameters["onlineMode"] = BuycraftConstants.ApiRequestParameters.OnlineMode;
			parameters["version"] = BuycraftConstants.ApiRequestParameters.BuycraftVersion;
			parameters["playersMax"] = BuycraftConstants.ApiRequestParameters.MaxPlayers;
			parameters["serverPort"] = BuycraftConstants.ApiRequestParameters.MinecraftPort;
			return JsonConvert.DeserializeObject<BuycraftApiResponses.AuthenticationPayload>(VerifySuccessfulRequest(MakeHttpRequest<BuycraftApiResponses.BaseBuycraftApiResponse>(CreateUriForRequest(parameters))));
		}

		/// <summary>
		/// Creates the base parameters for the Buycraft API result.
		/// </summary>
		/// <returns>A dictionary containing the base parameters for the request.</returns>
		private IDictionary<string, object> CreateBaseParameters()
		{
			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["playersOnline"] = BuycraftConstants.ApiRequestParameters.PlayersOnline;
			dictionary["secret"] = ApiKey;
			return dictionary;
		}

		/// <summary>
		/// Creates the URI for the specified parameters.
		/// </summary>
		/// <returns>The Uri object for this request.</returns>
		/// <param name="parameters">Parameters to pass to the API.</param>
		private static Uri CreateUriForRequest(IDictionary<string, object> parameters)
		{
			// Mono can not into Linq. Great fucking job...
			String url = "?";

			foreach (KeyValuePair<string, object> pair in parameters)
			{
				url += Uri.EscapeUriString(pair.Key) + "=" + Uri.EscapeUriString(pair.Value) + "&";
			}

			url = url.Remove(url.Length - 1); // remove trailing &

			return new Uri(BuycraftConstants.BuycraftApiUrl + url);
		}

		/// <summary>
		/// Makes an HTTP request, and deserializes the request using the type specified.
		/// </summary>
		/// <returns>An instance of the type parameter.</returns>
		/// <param name="uri">URI.</param>
		/// <typeparam name="T">JSON object to deserialize.</typeparam>
		private static T MakeHttpRequest<T>(Uri uri)
		{
			using (WebClient client = new WebClient())
			{
				return JsonConvert.DeserializeObject<T>(client.DownloadString(uri));
			}
		}

		private static void VerifySuccessfulRequest(BuycraftApiResponses.BaseBuycraftApiResponse response)
		{
			if (response.ErrorCode != BuycraftConstants.ErrorCodes.Success)
			{
				throw new Exception("Error from Buycraft: " + response.ErrorCode);
			}
			return response;
		}
	}
}

