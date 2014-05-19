using System;
using Newtonsoft.Json;

namespace BuycraftSharp
{
	public static class BuycraftApiResponses
	{
		private BuycraftApiResponses ()
		{
		}

		/*
		 * For a moment, I'd like to thank the Buycraft developers for giving
		 * us yet MORE objects to deserialize! At least Json.NET is fast...
		 * 
		 * Well, on the other hand it /does/ make reply objects easier. So
		 * there's one point for Buycraft.
		 */
		public static class BaseBuycraftApiResponse
		{
			private BaseBuycraftApiResponse()
			{
			}

			[JsonProperty("code")]
			public int ErrorCode { get; }
			[JsonProperty("payload")]
			public object Payload { get; }
		}

		public static class AuthenticationPayload
		{
			private AuthenticationPayload()
			{
			}

			[JsonProperty("latestVersion")]
			public string LatestVersion { get; }
			[JsonProperty("latestDownload")]
			public string LatestPluginDownload { get; }
		}
	}
}

