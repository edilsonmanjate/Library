

using Library.API.Controllers;
using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Features.Books.Commands.CreateBookCommand;
using Library.Application.Features.Books.Commands.DeleteBookCommand;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Application.Features.Books.Queries.GetAllBooksQuery;
using Library.Application.Features.Books.Queries.GetBookByIdQuery;

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

        // Update the test methods to use the correct type for the response
        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var query = new GetAllBooksQuery();
            var response = new BaseResponse<IEnumerable<BookDto>> { Success = true };
            _mediatorMock.Setup(x => x.Send(query, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsBadRequestResult_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var query = new GetAllBooksQuery();
            var response = new BaseResponse<IEnumerable<BookDto>> { Success = false };
            _mediatorMock.Setup(x => x.Send(query, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.GetAllAsync();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(response, badRequestResult.Value);
        }

        [Fact]
        public async Task GetAsync_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var query = new GetBookByIdQuery { BookId = bookId };
            var response = new BaseResponse<BookDto> { Success = true };
            _mediatorMock.Setup(x => x.Send(query, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.GetAsync(bookId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task GetAsync_ReturnsBadRequestResult_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var query = new GetBookByIdQuery { BookId = bookId };
            var response = new BaseResponse<BookDto> { Success = false };
            _mediatorMock.Setup(x => x.Send(query, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.GetAsync(bookId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(response, badRequestResult.Value);
        }

        [Fact]
        public async Task InsertAsync_ReturnsOkResult_WhenResponseIsSuccessful()
        {
            // Arrange
            var command = new CreateBookCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.InsertAsync(command);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(response, okResult.Value);
        }

        [Fact]
        public async Task InsertAsync_ReturnsBadRequestResult_WhenResponseIsNotSuccessful()
        {
            // Arrange
            var command = new CreateBookCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _booksController.InsertAsync(command);

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
            var result = await _booksController.UpdateAsync(command);

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
            var result = await _booksController.UpdateAsync(command);

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
            var result = await _booksController.DeleteAsync(command);

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
            var result = await _booksController.DeleteAsync(command);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(response, badRequestResult.Value);
        }
    }
}
