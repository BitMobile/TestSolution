using BitMobile.ClientModel3;

namespace Test
{
    public class DB
    {
        public static void Init()
        {
            var db = new Database();
            if (!db.Exists)
            {
                DConsole.WriteLine("DB is creating...");
                db.CreateFromModel();
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
    }
}