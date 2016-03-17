using System.IO;
using System.Xml;
using BitMobile.ClientModel3;
using XmlDocument = BitMobile.ClientModel3.XmlDocument;

namespace Test
{
    public class YandexPhoto
    {
        private static readonly string token = "63b7ea6bd442484093dc4d507a8aa951";
        private static readonly string login = "original-nick";

        public static void SyncPhotos()
        {
            var rst = DB.GetUnsyncedPhotos();
            while (rst.Next())
            {
                var id = rst["Id"].ToString();
                var fileName = rst["FileName"].ToString();
                var link = UploadFile(FileSystem.GetFileStream(fileName));

                if (!string.IsNullOrEmpty(link))
                {
                    DB.MarkPhotoAsSynced(id, link);
                    FileSystem.DeleteFile(fileName);

                    DConsole.WriteLine(string.Format("Photo file {0} has been successfully uploaded", fileName));
                }
            }
        }

        private static string UploadFile(Stream fs)
        {
            var req = new HttpRequest("http://api-fotki.yandex.ru");
            req.ContentType = "image/jpeg";
            req.AddHeader("Authorization", string.Format("OAuth {0}", token));
            var result = req.Post(string.Format("/api/users/{0}/photos/", login), fs);
            if (req.Status != 200)
            {
                DConsole.WriteLine(req.Error);
                return null;
            }

            var doc = new XmlDocument();
            doc.LoadXml(result);

            var nodes = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                if (node.Name.Equals("link"))
                    if (node.Attributes["rel"].Value.Equals("self"))
                        return node.Attributes["href"].Value;
            }

            return null; //smth is going wrong...
        }
    }
}