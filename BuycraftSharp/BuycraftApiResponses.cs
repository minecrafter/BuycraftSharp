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

		public class InformationPayload
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

		// {"id":207426,"name":"Lifetime Premium","shortDescription":"","guiItemId":54}
		public class Category
		{
			/// <summary>
			/// The ID of the category.
			/// </summary>
			/// <value>The ID for this category.</value>
			[JsonProperty("id")]
			public int Id { get; set; }
			/// <summary>
			/// The name of this category.
			/// </summary>
			/// <value>The name for this category.</value>
			[JsonProperty("name")]
			public string Name { get; set; }
			/// <summary>
			/// The description for this category.
			/// </summary>
			/// <value>The description for this category.</value>
			[JsonProperty("shortDescription")]
			public string Description { get; set; }
			/// <summary>
			/// The Minecraft item ID for this item, used as part of the Buycraft in-game GUI.
			/// </summary>
			/// <value>The Minecraft item ID.</value>
			[JsonProperty("guiItemId")]
			public int MinecraftItemId { get; set; }
		}
	}
}

