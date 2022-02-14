using System;
using AutoMapper;
using EfEx;
using EfEx.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using WebService.Controllers;
using WebService.ViewModels;
using Xunit;

namespace Webservice.Tests
{
    
    
    public class BookmarkTitleControllerTests
    {
        private readonly Mock<IDataService> _dataServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<LinkGenerator> _linkGeneratorMock;

         public BookmarkTitleControllerTests()
         {
             _dataServiceMock = new Mock<IDataService>();
             _mapperMock = new Mock<IMapper>();
             _linkGeneratorMock = new Mock<LinkGenerator>();
         }

        [Fact]
        public void GetBookmarTitle_ValidFilmId_ReturnsOkStatus()
        {
            _dataServiceMock.Setup(x => x.GetBookmarkTitleByFilmId(It.IsAny<string>())).Returns(new BookmarkTitle());
            _mapperMock.Setup(x => x.Map<BookmarkTitleViewModel>(It.IsAny<BookmarkTitle>())).Returns(new BookmarkTitleViewModel());

            var ctrl = new BookmarkTitleController(_dataServiceMock.Object, _linkGeneratorMock.Object, _mapperMock.Object);
            ctrl.ControllerContext = new ControllerContext();
            ctrl.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = ctrl.GetBookmarkTitleByFilmId("01224");

            Assert.IsType<OkObjectResult>(result);
        }




        [Fact]
        public void CreateBookmarkTitle_ValidNewBookmarkTitle_DataServiceCreateBookmarkTitleMustBeCalledOnce()
        {

            _mapperMock.Setup(x => x.Map<BookmarkTitle>(It.IsAny<CreateBookmarkTitleViewModel>())).Returns(new BookmarkTitle());
            _mapperMock.Setup(x => x.Map<BookmarkTitleViewModel>(It.IsAny<BookmarkTitle>())).Returns(new BookmarkTitleViewModel());

            _linkGeneratorMock.Setup(x => x.GetUriByAddress(
                    It.IsAny<HttpContext>(),
                    It.IsAny<string>(),
                    It.IsAny<RouteValueDictionary>(),
                    default, default, default, default, default, default))
                .Returns("");

            var ctrl = new BookmarkTitleController(_dataServiceMock.Object, _linkGeneratorMock.Object, _mapperMock.Object);
            ctrl.ControllerContext = new ControllerContext();
            ctrl.ControllerContext.HttpContext = new DefaultHttpContext();


            ctrl.CreateBookmarkTitle(new CreateBookmarkTitleViewModel());

            _dataServiceMock.Verify(x => x.CreateBookmarkTitle(It.IsAny<BookmarkTitle>()), Times.Once);

        }

        [Fact]
        public void DeleteBookmarkTitle_WithDefinedBookmark()
        {

            var bookmarkTitle = new BookmarkTitle();
            {
                bookmarkTitle.UserId = 18;
                bookmarkTitle.FilmId = "anothertest0123458";
                bookmarkTitle.Title = "DeleteBookmarkTitle_ValidData_RemoveTheBookmark";
            }

            _linkGeneratorMock.Setup(x => x.GetUriByAddress(
                    It.IsAny<HttpContext>(),
                    It.IsAny<string>(),
                    It.IsAny<RouteValueDictionary>(),
                    default, default, default, default, default, default))
                .Returns("");

            var ctrl = new BookmarkTitleController(_dataServiceMock.Object, _linkGeneratorMock.Object, _mapperMock.Object);
            ctrl.ControllerContext = new ControllerContext();
            ctrl.ControllerContext.HttpContext = new DefaultHttpContext();


            ctrl.DeleteBookmarkTitle(bookmarkTitle.FilmId);

            _dataServiceMock.Verify(x => x.DeleteBookmarkTitle(bookmarkTitle.UserId, bookmarkTitle.FilmId));

        }



    }


    
}