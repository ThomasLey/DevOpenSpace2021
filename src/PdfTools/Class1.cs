using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AwesomeLib;
using DiTryouts.Models;
using NSubstitute;
using NUnit.Framework;

namespace PdfTools
{
    [TestFixture]
    public class PdfArchiverTest
    {
        [Test]
        public void TestAwesomeLib()
        {
            var hero = new SuperHero();
            var logger = new MyConsoleLogger();

            hero.EliminateAllSuperVailians(new SuperHeroLoggerAdapter(logger));


            hero.EliminateAllSuperVailians(s => logger.Log(s));
        }





        private class MockHttpClient : IHttpClient
        {
            public Task<HttpResponseMessage> GetAsync(string url)
            {
                if (url == "https://www.mclibre.org/descargar/docs/revistas/magpi-books/the-magpi-essentials-scratch-01-en-201606.pd")
                    return Task.FromResult(new HttpResponseMessage()
                    {
                        Content = new ByteArrayContent(File.ReadAllBytes(@"C:\Workspace.Blog\DevOpenSpace2021\03_Extract-Interface.pdf"))
                    });

                return null;
            }
        }

        [Test]
        public void Can_DownloadDocument()
        {
            var url = "https://www.mclibre.org/descargar/docs/revistas/magpi-books/the-magpi-essentials-scratch-01-en-201606.pd";
            var mock = new MockHttpClient();
            var sut = new PdfArchiver(mock);

            sut.Archive(url);

            sut.SaveAs(Path.GetTempFileName());
        }

        [Test]
        public void Can_DownloadDocument2()
        {
            var url = "https://www.mclibre.org/descargar/docs/revistas/magpi-books/the-magpi-essentials-scratch-01-en-201606.pd";
            var mock = Substitute.For<IHttpClient>();
            mock.GetAsync(Arg.Is("https://www.mclibre.org/descargar/docs/revistas/magpi-books/the-magpi-essentials-scratch-01-en-201606.pd"))
                .Returns(Task.FromResult(new HttpResponseMessage()
                {
                    Content = new ByteArrayContent(File.ReadAllBytes(@"C:\Workspace.Blog\DevOpenSpace2021\03_Extract-Interface.pdf"))
                }));
            var sut = new PdfArchiver(mock);

            sut.Archive(url);

            var tmp = Path.GetTempFileName();
            sut.SaveAs(tmp);

            Assert.IsTrue(File.Exists(tmp));
            //Assert.AreEqual(new FileInfo(tmp).Length, new FileInfo(@"C:\Workspace.Blog\DevOpenSpace2021\03_Extract-Interface.pdf").Length);
        }
    }
}
