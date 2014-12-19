using System.Collections.Generic;

namespace UniLinqTest
{
	// For Test
	class PlayLog
	{
		public int StageId { get; set; }

		public int Score { get; set; }
	}

	// For Test
	class StageData
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}

	// For Test
	class PlayData
	{
		public int Score { get; set; }

		public string StageName { get; set; }
	}

	// For Test
	class StagePlayData
	{
		public List<int> ScoreList { get; set; }

		public string StageName { get; set; }
	}
}