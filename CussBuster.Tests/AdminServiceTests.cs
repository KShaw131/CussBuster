using NUnit.Framework;
using Moq;

using CussBuster.API.Services;
using CussBuster.API.Repository;
using CussBuster.Database.Entities;

namespace CussBuster.Tests
{
    [TestFixture]
    public class AdminServiceTests
    {

        private AdminService _adminService;
        private Mock<ICurseWordsRepository> _curseWordRepository;

        [SetUp]
        public void SetUp()
        {
            _curseWordRepository = new Mock<ICurseWordsRepository>();
            _adminService = new AdminService(_curseWordRepository.Object);
        }

        [Test]
        public void GetCurseWord_Null()
        {
            const int id = 1;

            //Arrange
            _curseWordRepository.Setup(x => x.GetById(id)).Returns(default(CurseWords));

            //Act
            var result = _adminService.GetCurseWord(id);

            //Assert
            Assert.True(result == null);

            _curseWordRepository.Verify(x => x.GetById(id), Times.Once());
        }

        [Test]
        public void GetCurseWord_NotNull()
        {
            const int id = 1;

            CurseWords curseWords = new CurseWords
            {
                Id = 1,
                CurseWord = "BadWord",
                Severity = 3,
                TypeId = 1
            };

            //Arrange
            _curseWordRepository.Setup(x => x.GetById(id)).Returns(curseWords);

            //Act
            var result = _adminService.GetCurseWord(id);

            //Assert
            Assert.True(result.Id == curseWords.Id);
            Assert.True(result.CurseWord == curseWords.CurseWord);
            Assert.True(result.Severity == curseWords.Severity);
            Assert.True(result.TypeId == curseWords.TypeId);

            _curseWordRepository.Verify(x => x.GetById(id), Times.Once());

        }
    }
}

