using System;

namespace BuycraftSharp
{
	public static class BuycraftConstants
	{
		public const string BuycraftApiUrl = "https://api.buycraft.net/v4";

		public static class ErrorCodes
		{
			public const int Success = 0;
			public const int InvalidAction = 100;
			public const int BadSecret = 101;
			public const int InvalidAction2 = 102;
		}
	}
}

