using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using TheLibrary.Core.Entities;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Tests.Repositories
{
    [TestClass]
    public class AuthorRepositoryTests
    {
        private readonly UnitOfWork uow;

        public AuthorRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            var context = new LibraryContext(optionsBuilder.Options);
            uow = new UnitOfWork(context);
        }

        [TestMethod]
        public async Task CreateValidAuthor()
        {
            var newAuthor = new Author()
            {
                Name = "TESTE"
            };

            var result = await uow.Repository<Author>().Create(newAuthor);

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
            }
        }
    }
}
