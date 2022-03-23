using NUnit.Framework;
using bookstore.Data.Services.AuthorServices;
using bookstore.Models;
using System.Collections.Generic;
using System.Linq;
using bookstore.Data.Repositories;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace bookstoreUnitTest
{
    [TestFixture]
    public class AuthorTest
    {
        private Mock<IAuthorRepository> _mockrepo;
        private IAuthorService _service;
        private List<Author> _authors;
        [SetUp]
        public void Setup()
        {
            // mocking iauthorrepository
            _mockrepo = new Mock<IAuthorRepository>();

            // this will call to the authorservice, which has the "iauthorrepository" = the mock of the iauthorrepository
            // which mean the data it going to access will be fakes.
            _service = new AuthorService(_mockrepo.Object);
            _authors = new List<Author>()
            {
                new Author() {author_id = 1, pseudonym = "atest01" },
                new Author() {author_id = 2,pseudonym = "atest02" },
                new Author() {author_id = 3, pseudonym = "atest03" },
            };
        }

        [Test]
        public void Author_Service_GetAll()
        {
            // set up mock - Specify the method that needed mocking: getall
            // returns - Specify the return value for the method
            // => get all will return all value of _authors
            _mockrepo.Setup(m => m.GetAll()).Returns(_authors);

            // call service
            var result = _service.GetAll() as List<Author>;

            // test
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
           

        }

        [Test]
        public void Author_Service_Create()
        {
            // mock is just mocking the behavior of a method
            // it will not update what it had mocked, if dont call again after the update of code.
            // each var result is a record of a mock
            // a var must alway be put after the _mock?
            var authors = new List<Author>();

            /*a.Add(new Author { author_id = 1, pseudonym = "create test 1" });
            _mockrepo.Setup(m => m.GetAll()).Returns(a);
            var result2 = _service.GetAll() as List<Author>;
            Assert.AreEqual(1, result2.Count);*/

            Author auth = new Author() { author_id = 2, pseudonym = "create test 2" };
            _mockrepo.Setup(m => m.Add(auth)).Returns((Author author) => 
            {
                author.pseudonym = auth.pseudonym;
                return author;
            });
 
            var result = _service.Add(auth);

            authors.Add(auth);
            _mockrepo.Setup(m => m.GetAll()).Returns( authors);
            var result2 = _service.GetAll() as List<Author>;

            //Assert.IsNotNull(result);
            Assert.AreEqual("create test 2", result.pseudonym);
            Assert.AreEqual(1, result2.Count);
        }

        [Test] 
        public void Author_Service_Update()
        {

            var auth = new Author() { author_id = 100, pseudonym = "Update test 1" };
            Assert.AreEqual(100, auth.author_id);
            //_mockrepo.Setup(m => m.GetById(It.IsAny<int>())).Returns(_authors.FirstOrDefault(a => a.author_id == 1));

            _mockrepo.Setup(m => m.Update(auth));
            var result1 = _service.Update(1, auth);
            _mockrepo.Verify(m => m.Update(auth), Times.Once());

            Assert.AreEqual(1, auth.author_id); // change to id = 1 => replace the new pseudonym into the pseudonym of id 1
            Assert.AreEqual("Update test 1", auth.pseudonym);


        }

        [Test]
        public void Author_Service_GetById()
        {
            // if the paramater was specifical, then the result must call that specifical
            _mockrepo.Setup(m => m.GetById(It.IsAny<int>())).Returns(_authors.FirstOrDefault(a => a.author_id == 1));

            // now, whenever result call for service GetById, result will alway have the value that pass to the _mock.
            var result = _service.GetById(It.IsAny<int>()) as Author;
            //_mockrepo.Verify(m => m.GetById(1), Times.Once());

            Assert.AreEqual(1, result.author_id);
            Assert.AreEqual("atest01", result.pseudonym);

        }

        [Test]
        public void Author_Service_Delete()
        {
            var timesCalled = 0;

            _mockrepo.Setup(m => m.Delete(It.IsAny<int>()))
                .Returns(_authors.FirstOrDefault(a => a.author_id == 1))
                .Callback(() => ++timesCalled);
            var result1 = _service.Delete(It.IsAny<int>());
            _mockrepo.Verify(m => m.Delete(It.IsAny<int>()), Times.Once());
            Assert.AreEqual(1,result1.author_id);
            Assert.AreEqual(1, timesCalled);

        }
    }
}