using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx.Domain;
using Xunit;
using EfEx;

namespace IMDB.Tests
{
    public class DataServiceTests
    {
        [Fact]
        public void BookmarkTitle_Object_HasUserIdFilmIdAndTitle()
        {
            var bookrmarkTitle = new BookmarkTitle();
            Assert.Equal(0, bookrmarkTitle.UserId);
            Assert.Null(bookrmarkTitle.FilmId);
            Assert.Null(bookrmarkTitle.Title);
        }

        [Fact]
        public void CreateBookmarkTitle_ValidData_CreteBookmarkTitleAndRetunsNewObject()
        {
            var service = new DataService();
            var bookmarkTitle = new BookmarkTitle();
            {
                bookmarkTitle.UserId = 17;
                bookmarkTitle.FilmId = "test0123458";
                bookmarkTitle.Title = "CreateBookmarkTitle_ValidData_CreteBookmarkTitleAndRetunsNewObject";
            }

            var testBookmarkTitle = service.CreateBookmarkTitle(bookmarkTitle);

            Assert.True(testBookmarkTitle.UserId > 0);
            Assert.Equal(17, testBookmarkTitle.UserId);
            Assert.Equal("test0123458", testBookmarkTitle.FilmId);
            Assert.Equal("CreateBookmarkTitle_ValidData_CreteBookmarkTitleAndRetunsNewObject", testBookmarkTitle.Title);


        }

        [Fact]
        public void DeleteBookmarkTitle_ValidData_RemoveTheBookmark()
        {
            var service = new DataService();
            var bookmarkTitle = new BookmarkTitle();
            {
                bookmarkTitle.UserId = 18;
                bookmarkTitle.FilmId = "anothertest0123458";
                bookmarkTitle.Title = "DeleteBookmarkTitle_ValidData_RemoveTheBookmark";
            }

            service.CreateBookmarkTitle(bookmarkTitle);

            var result = service.DeleteBookmarkTitle(bookmarkTitle.UserId, bookmarkTitle.FilmId);
            Assert.True(result);
            bookmarkTitle = service.GetBookmarkTitleByUserIdAndFilmId(bookmarkTitle.UserId, bookmarkTitle.FilmId);
            Assert.Null(bookmarkTitle);

        }

        //[Fact]
        //public void DeleteBookmarkTitle_InvalidUserIdAndFilmId_ReturnsFalse()
        //{
        //    var service = new DataService();
        //    var result = service.DeleteBookmarkTitle(-1, "test-1");
        //    Assert.False(result);
        //}
    }

}
