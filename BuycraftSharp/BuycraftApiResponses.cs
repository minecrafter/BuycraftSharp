using System;
using Newtonsoft.Json;

namespace BuycraftSharp
{
	public static class BuycraftApiResponses
	{
		public class BaseBuycraftApiResponse<T>
		{
			[JsonProperty("code")]
			public int ErrorCode { get; set; }
			[JsonProperty("payload")]
			public T Payload { get; set; }
		}

		public class AuthenticationPayload
		{
			/// <summary>
			/// The latest version of the Buycraft plugin.
			/// </summary>
			/// <value>The latest version of the Buycraft plugin.</value>
			[JsonProperty("latestVersion")]
			public string LatestVersion { get; set; }
			/// <summary>
			/// The latest download for the Buycraft plugin.
			/// </summary>
			/// <value>The latest download for the Buycraft plugin.</value>
			[JsonProperty("latestDownload")]
			public string LatestPluginDownload { get; set; }
			/// <summary>
			/// The Buycraft server ID.
			/// </summary>
			/// <value>The Buycraft server ID.</value>
			[JsonProperty("serverId")]
			public int ServerId { get; set; }
			/// <summary>
			/// The current currency your shop accepts.
			/// </summary>
			/// <value>The shop's server currency.</value>
			[JsonProperty("serverCurrency")]
			public string ServerCurrency { get; set; }
			/// <summary>
			/// The name associated with the API key currently in use.
			/// </summary>
			/// <value>The name associated with the API key currently in use.</value>
			[JsonProperty("serverName")]
			public string ServerName { get; set; }
			/// <summary>
			/// Unknown purpose.
			/// </summary>
			/// <value>Unknown.</value>
			[JsonProperty("updateUsernameInterval")]
			public int UpdateUsernameInterval { get; set; }
		}
	}
}

