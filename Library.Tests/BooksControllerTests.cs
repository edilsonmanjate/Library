using Library.API.Controllers;
using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Features.Books.Commands.CreateBookCommand;
using Library.Application.Features.Books.Commands.DeleteBookCommand;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Application.Features.Books.Queries.GetAllBooksQuery;
using Library.Application.Features.Books.Queries.GetBookByIdQuery;
using Library.Application.Features.Loans.Queries.GetAllLoansQuery;
using Library.Application.Features.Loans.Queries.GetLoanByIdQuery;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace Library.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BooksController _booksController;

        public BooksControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _booksController = new BooksController(_mediatorMock.Object);
         
        }


        [Fact]
        public async Task GetAllAsync_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var query = new GetAllBooksQuery();
            var response = new BaseResponse<IEnumerable<BookDto>> { Success = true };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            // Act
            var result = await _booksController.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<IEnumerable<BookDto>>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var query = new GetAllBooksQuery();
            var response = new BaseResponse<IEnumerable<BookDto>> { Success = false };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);


            // Act
            var result = await _booksController.GetAllAsync();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<IEnumerable<BookDto>>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }

        [Fact]
        public async Task GetAsync_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var loanId = Guid.NewGuid();
            var query = new GetBookByIdQuery { BookId = loanId };
            //var response = new BaseResponse<bool> { Success = true };
            //_mediatorMock.Setup(x => x.Send(It.IsAny<BaseResponse<bool>>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
            var response = new BaseResponse<BookDto> { Success = true };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);


            // Act
            var result = await _booksController.GetAsync(loanId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<BookDto>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task GetAsync_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var loanId = Guid.NewGuid();
            var query = new GetBookByIdQuery { BookId = loanId };

            var response = new BaseResponse<BookDto> { Success = false };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            // Act
            var result = await _booksController.GetAsync(loanId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<BookDto>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }



        [Fact]
        public async Task CreateAsync_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var command = new CreateBookCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.Create(command, default);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task CreateAsync_ReturnsBadRequestResult_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var command = new CreateBookCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.Create(command, default);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(response, badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var command = new UpdateBookCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.UpdateAsync(command, default);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsBadRequestResult_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var command = new UpdateBookCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

         

            // Act
            var result = await _booksController.UpdateAsync(command, default);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(response, badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var command = new DeleteBookCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.DeleteAsync(command, default);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsBadRequestResult_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var command = new DeleteBookCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.DeleteAsync(command, default);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(response, badRequestResult.Value);
        }
    }
}
