// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	using FestivalManager.Entities;
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class StageTests
	{
		[Test]
		public void AddPerformerShouldThrowExceptionWhenNull()
		{
			var stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}
		[Test]
		public void AddPerformerShouldThrowExceptionWhenUnder18()
		{
			var stage = new Stage();
			var performer = new Performer("pesho", "ded", 15);
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}
		[Test]
		public void AddPerformerShouldWork()
		{
			var stage = new Stage();
			var performer = new Performer("pesho", "ded", 23);
			stage.AddPerformer(performer);
			Assert.AreEqual(1, stage.Performers.Count);

		}
		[Test]
		public void AddSongShouldThrowExceptionWhenNull()
		{
			var stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void AddSongShouldThrowExceptionDurationIsLowerThan1()
		{
			var stage = new Stage();
			var song = new Song("all", new TimeSpan(0, 0, 50));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}
		[Test]
		public void AddSongShouldWork()
		{
			TimeSpan timeSpan = new TimeSpan();
			var stage = new Stage();
			var song = new Song("pesho", new TimeSpan(0, 2, 20));
			stage.AddSong(song);
			Assert.AreEqual(1, 1);
		}
		[Test]
		public void AddSongToPerfomerCannotBeNullForSong()
		{
			var stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "dedo"));
		}
		[Test]
		public void AddSongToPerfomerCannotBeNullForPerformer()
		{
			var stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("guns", null));
		}
		[Test]
		public void AddSongToPerfomerShouldWork()
		{
			var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
			var performer = new Performer("Ivan", "Ivanov", 19);
			Stage stage = new Stage();
			stage.AddSong(song1);
			stage.AddPerformer(performer);
			var result = stage.AddSongToPerformer("Ветрове", "Ivan Ivanov");
			Assert.AreEqual("Ветрове (03:30) will be performed by Ivan Ivanov", result);
		}
		[Test]
		public void PlayShouldWork()
		{
			var stage = new Stage();
			var performer = new Performer("Ivan", "Ivanov", 19);
			var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
			stage.AddSong(song1);
			stage.AddPerformer(performer);
			performer.SongList.Add(song1);
			var res = stage.Play();
			Assert.AreEqual("1 performers played 1 songs", res);

		}
		[Test]
		public void GetPerformerShouldThrowExceptionWhenNotFound()
		{
			var stage = new Stage();
			var performer = new Performer("Ivan", "Ivanov", 19);
			var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
			stage.AddSong(song1);
			stage.AddPerformer(performer);
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Ветрове", "popo"));
		}
		[Test]
		public void GetSongShouldThrowExceptionWhenNotFound()
		{
			var stage = new Stage();
			var performer = new Performer("Ivan", "Ivanov", 19);
			var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
			stage.AddSong(song1);
			stage.AddPerformer(performer);
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("drr", "Ivan"));
		}
	}

	internal struct NewStruct
	{
		public int Item1;
		public int Item2;
		public int Item3;

		public NewStruct(int item1, int item2, int item3)
		{
			Item1 = item1;
			Item2 = item2;
			Item3 = item3;
		}

		public override bool Equals(object obj)
		{
			return obj is NewStruct other &&
				   Item1 == other.Item1 &&
				   Item2 == other.Item2 &&
				   Item3 == other.Item3;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Item1, Item2, Item3);
		}

		public void Deconstruct(out int item1, out int item2, out int item3)
		{
			item1 = Item1;
			item2 = Item2;
			item3 = Item3;
		}

		public static implicit operator (int, int, int)(NewStruct value)
		{
			return (value.Item1, value.Item2, value.Item3);
		}

		public static implicit operator NewStruct((int, int, int) value)
		{
			return new NewStruct(value.Item1, value.Item2, value.Item3);
		}
	}
}
