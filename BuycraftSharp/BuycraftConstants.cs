using System;

namespace BuycraftSharp
{
	static class BuycraftConstants
	{
		public const string BuycraftApiUrl = "https://api.buycraft.net/v4";

		private BuycraftConstants ()
		{
		}

		public static class ApiRequestParameters
		{
			private ApiRequestParameters()
			{
			}

			public const int MinecraftPort = 25565;
			public const int OnlineMode = true;
			public const int MaxPlayers = 0;
			public const int PlayersOnline = 0;
			public const string BuycraftVersion = "6.3";
		}

		public static class ErrorCodes
		{
			private ErrorCodes()
			{
			}

			public const int Success = 0;
			public const int BadSecret = 101;
		}
	}
}

