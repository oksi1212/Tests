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
        public void TestUserCheck()
        {
            ProxyProject.User user = new ProxyProject.User(25);
            Assert.IsTrue(ProxyProject.Authentification.UserCheck(user));
        }
        [Test]
        public void TestClientAuthentification()
        {
            int TestCountPassword = 50;
            ProxyProject.Authentification.AddUser(TestCountPassword);
            ProxyProject.User user = new ProxyProject.User(25);
            Assert.That(() => ProxyProject.Authentification.ClientAuthentification(user), Throws.Nothing);
        }
    }

    public class TestCorrecherss
    {
        public ProxyProject.Rules rl1;
        public  ProxyProject.Packet request;
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
        public ProxyProject.Rules rl1;
        public ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            rl1 = new ProxyProject.Correcherss();
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
        public ProxyProject.Rules rl1;
        public ProxyProject.Packet request;
        [SetUp]
        public void BeforeTest()
        {
            rl1 = new ProxyProject.Correcherss();
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
        [SetUp]
        public void BeforeTest()
        {
            
        }
        [Test]
        public void Prepare()
        {
            ProxyProject.ProxyServ proxy = new ProxyProject.ProxyServ(new ProxyProject.RealSubject());
            ProxyProject.Packet request = ProxyProject.Packet.GetPacket();
            request.Sourse = 1;
            request.Destination = 12;
            Assert.That(() => proxy.Prepare(request), Throws.Nothing);
        }
    }

    public class TestSystem
    {
        public ProxyProject.ProxyServ proxy;
        public ProxyProject.User user;
        [SetUp]
        public void ProductionPrepare()
        {
            proxy = new ProxyProject.ProxyServ(new ProxyProject.RealSubject());
            int possibleCountPassword = 50;
            ProxyProject.Authentification.AddUser(possibleCountPassword);
            user = new ProxyProject.User(30);
        }
        [Test]
        public void ProductionTest()
        {
            
            Assert.IsNotNull(proxy);
            Assert.IsNotNull(user);
            ProxyProject.Packet request = ProxyProject.Packet.GetPacket();
            Assert.IsNotNull(request);
            Assert.That(() => ProxyProject.Authentification.ClientAuthentification(user), Throws.Nothing);
            Assert.That(() => proxy.Prepare(request), Throws.Nothing);
            ProxyProject.Packet response = user.GetResponse(proxy, request, user);
            Assert.IsNotNull(response);
        }
    }
}
