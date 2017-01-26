using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ProxyProject.UnitTests
{
    public class TestAuthentification
    {
        int TestCountPassword;
        [SetUp]
        public void BeforeTest()
        {
            TestCountPassword = 50;
            ProxyProject.Authentification.AddUser(TestCountPassword);
        }
        [Test]
        public void TestGetPassword()
        {
            string test = "쮸㵫曨ﷲ\u171f澙Ǯ쓎詴";
            Assert.AreEqual(ProxyProject.Authentification.GetPassword(TestCountPassword), test);
            Assert.AreNotEqual(ProxyProject.Authentification.GetPassword(TestCountPassword), TestCountPassword);
        }
        [Test]
        public void TestUserCheck()
        {
            ProxyProject.User user = new ProxyProject.User(25);
            Assert.IsTrue(ProxyProject.Authentification.UserCheck(user));
            ProxyProject.User user1 = new ProxyProject.User(51);
            Assert.IsTrue(ProxyProject.Authentification.UserCheck(user1));
        }
        [Test]
        public void TestClientAuthentification()
        {
            ProxyProject.User user = new ProxyProject.User(25);
            Assert.That(() => ProxyProject.Authentification.ClientAuthentification(user), Throws.Nothing);
            ProxyProject.User user1 = new ProxyProject.User(51);
            ProxyProject.Authentification.ClientAuthentification(user1);
        }
      }

    public class TestCorrecherss
    {
        ProxyProject.Rules rl1;
        ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            rl1 = new ProxyProject.Correcherss();
            request = ProxyProject.Packet.GetPacket();
        }
        [Test]
        public void TestRule()
        {
            Assert.That(() => rl1.Rule(request), Throws.Nothing);
        }
    }

    public class TestAccess
    {
        ProxyProject.Rules rl1;
        ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            rl1 = new ProxyProject.Access();
            request = ProxyProject.Packet.GetPacket();
        }
        [Test]
        public void TestRule()
        {
            request.Destination = 3;
            request.Time = 14;
            Assert.That(() => rl1.Rule(request), Throws.Nothing);
        }
     }

    public class TestAnswer
    {
        ProxyProject.Rules rl1;
        ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            rl1 = new ProxyProject.Answer();
            request = ProxyProject.Packet.GetPacket();
        }
        [Test]
        public void TestRule()
        {
            request.Sourse = 45;
            request.Destination = 81;
            Assert.That(() => rl1.Rule(request), Throws.Nothing);
        }
    }

    public class TestProxyServ
    {
        ProxyProject.ProxyServ proxy;
        ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            ProxyProject.ProxyServ proxy = new ProxyProject.ProxyServ(new ProxyProject.RealSubject());
            request = ProxyProject.Packet.GetPacket();
        }
        [Test]
        public void Prepare()
        {
            request.Sourse = 1;
            request.Destination = 12;
            Assert.That(() => proxy.Prepare(request), Throws.Nothing);
        }
    }

    public class TestSystem
    {
        public ProxyProject.ProxyServ proxy;
        public ProxyProject.User user;
        int TestCountPassword;
        ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            proxy = new ProxyProject.ProxyServ(new ProxyProject.RealSubject());
            TestCountPassword = 50;
            ProxyProject.Authentification.AddUser(TestCountPassword);
            user = new ProxyProject.User(30);
            request = ProxyProject.Packet.GetPacket();
        }
        [Test]
        public void TestProduction()
        {
            Assert.IsNotNull(proxy);
            Assert.IsNotNull(user);
            Assert.IsNotNull(request);
            Assert.That(() => ProxyProject.Authentification.ClientAuthentification(user), Throws.Nothing);
            Assert.That(() => proxy.Prepare(request), Throws.Nothing);
            ProxyProject.Packet response = user.GetResponse(proxy, request, user);
            Assert.IsNotNull(response);
        }
    }
}
