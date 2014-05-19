using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace BuycraftSharp
{
	public class BuycraftApi
	{
		/// <summary>
		/// Gets or sets the Buycraft API key.
		/// </summary>
		/// <value>The Buycraft API key.</value>
		public string ApiKey { get; set; }

		/// <summary>
		/// Fetch information about the store and the user of the API key.
		/// </summary>
		/// <returns>The info reply from the Buycraft API.</returns>
		public BuycraftApiResponses.InformationPayload Information()
		{
			IDictionary<string, object> parameters = CreateBaseParameters();
			parameters["action"] = "info";

			return FetchPayload(MakeHttpRequest<BuycraftApiResponses.BaseBuycraftApiResponse<BuycraftApiResponses.InformationPayload>>(CreateUriForRequest(parameters)));
		}

		/// <summary>
		/// Fetch information about all categories.
		/// </summary>
		/// <returns>The categories from the Buycraft API.</returns>
		public ICollection<BuycraftApiResponses.Category> Categories()
		{
			IDictionary<string, object> parameters = CreateBaseParameters();
			parameters["action"] = "categories";

			return FetchPayload(MakeHttpRequest<BuycraftApiResponses.BaseBuycraftApiResponse<List<BuycraftApiResponses.Category>>>(CreateUriForRequest(parameters)));
		}

		/// <summary>
		/// Creates the base parameters for the Buycraft API result.
		/// </summary>
		/// <returns>A dictionary containing the base parameters for the request.</returns>
		private IDictionary<string, object> CreateBaseParameters()
		{
			IDictionary<string, object> dictionary = new Dictionary<string, object>();
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
				url += Uri.EscapeUriString(pair.Key) + "=" + Uri.EscapeUriString(pair.Value.ToString()) + "&";
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

		private static BuycraftApiResponses.BaseBuycraftApiResponse<T> VerifySuccessfulRequest<T>(BuycraftApiResponses.BaseBuycraftApiResponse<T> response)
		{
			if (response.ErrorCode != BuycraftConstants.ErrorCodes.Success)
			{
				throw new Exception("Error from Buycraft: " + response.ErrorCode);
			}
			return response;
		}

		private static T FetchPayload<T>(BuycraftApiResponses.BaseBuycraftApiResponse<T> response)
		{
			return VerifySuccessfulRequest(response).Payload;
		}
	}
}

