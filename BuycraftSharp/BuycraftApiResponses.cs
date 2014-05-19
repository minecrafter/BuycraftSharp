using System;
using Newtonsoft.Json;

namespace BuycraftSharp
{
	public static class BuycraftApiResponses
	{
		/*
		 * For a moment, I'd like to thank the Buycraft developers for giving
		 * us yet MORE objects to deserialize! At least Json.NET is fast...
		 * 
		 * Well, on the other hand it /does/ make reply objects easier. So
		 * there's one point for Buycraft.
		 */
		public class BaseBuycraftApiResponse<T>
		{
			[JsonProperty("code")]
			public int ErrorCode { get; set; }
			[JsonProperty("payload")]
			public T Payload { get; set; }
		}

		public class AuthenticationPayload
		{
			[JsonProperty("latestVersion")]
			public string LatestVersion { get; set; }
			[JsonProperty("latestDownload")]
			public string LatestPluginDownload { get; set; }
		}
	}
}

