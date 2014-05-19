using System;

namespace BuycraftSharp
{
	public static class BuycraftConstants
	{
		public const string BuycraftApiUrl = "https://api.buycraft.net/v4";

		public static class ApiRequestParameters
		{
			public const int MinecraftPort = 25565;
			public const bool OnlineMode = true;
			public const int MaxPlayers = 0;
			public const int PlayersOnline = 0;
			public const string BuycraftVersion = "6.3";
		}

		public static class ErrorCodes
		{
			public const int Success = 0;
			public const int BadSecret = 101;
		}
	}
}

