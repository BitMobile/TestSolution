using System;
using BitMobile.ClientModel3;

namespace Test
{
	public class DB
	{
		private static Database _db;
		public static void Init()
		{
			_db = new Database();
			if (!_db.Exists)
			{
				DConsole.WriteLine("DB is creating...");
				_db.CreateFromModel();
				DConsole.WriteLine("DB has been created.");
			}
		}

		public static string GetCountOfUnsyncedPhotos()
		{
			var qry = new Query("SELECT COUNT(*) AS Cnt FROM _Document_Photos WHERE Link IS NULL");
			var rst = qry.Execute();
			if (rst.Next())
				return rst["Cnt"].ToString();
			return "0";
		}

		public static DbRecordset GetUnsyncedPhotos()
		{
			return new Query("SELECT Id, FileName FROM _Document_Photos WHERE Link IS NULL").Execute();
		}

		public static void MarkPhotoAsSynced(string id, string link)
		{
			var qry = new Query("UPDATE _Document_Photos SET Link = @Link WHERE Id = @Id");
			qry.AddParameter("Id", id);
			qry.AddParameter("Link", link);
			qry.Execute();
		}

		public void Synchronization(object sender, EventArgs e)
		{

			_db.PerformSync(@"http://10.5.195.230/TestPla/testpla/device", "ivan", "2502", TimeSpan.FromMinutes(10), OnSyncComplete, "sync complete");
			DConsole.WriteLine("Synchronization OK!");
		}
		private void OnSyncComplete(object sender, ResultEventArgs<bool> resultEventArgs)
		{
		}

	}
}