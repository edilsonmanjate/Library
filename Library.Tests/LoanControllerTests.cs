using Library.API.Controllers;
using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Features.Loans.Commands.CreateLoanCommand;
using Library.Application.Features.Loans.Commands.ReturnLoanCommand;
using Library.Application.Features.Loans.Commands.UpdateLoanCommand;
using Library.Application.Features.Loans.Queries.GetAllLoansQuery;
using Library.Application.Features.Loans.Queries.GetLoanByIdQuery;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace Library.Tests
{
    public class LoanControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly LoanController _loanController;

        public LoanControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loanController = new LoanController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var query = new GetAllLoanQuery();
            var response = new BaseResponse<IEnumerable<LoanDto>> { Success = true};
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllLoanQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            // Act
            var result = await _loanController.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<IEnumerable<LoanDto>>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var query = new GetAllLoanQuery();
            var response = new BaseResponse<IEnumerable<LoanDto>> { Success = false };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllLoanQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);


            // Act
            var result = await _loanController.GetAllAsync();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<IEnumerable<LoanDto>>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }

        [Fact]
        public async Task GetAsync_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var loanId = Guid.NewGuid();
            var query = new GetLoanByIdQuery { LoanId = loanId };
            var response = new BaseResponse<LoanDto> { Success = true };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetLoanByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);


            // Act
            var result = await _loanController.GetAsync(loanId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<LoanDto>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task GetAsync_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var loanId = Guid.NewGuid();
            var query = new GetLoanByIdQuery { LoanId = loanId };

            var response = new BaseResponse<LoanDto> { Success = false };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetLoanByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            // Act
            var result = await _loanController.GetAsync(loanId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<LoanDto>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }

        [Fact]
        public async Task Create_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var command = new CreateLoanCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _loanController.Create(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<bool>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task Create_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var command = new CreateLoanCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _loanController.Create(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var command = new UpdateLoanCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _loanController.UpdateAsync(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<bool>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var command = new UpdateLoanCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _loanController.UpdateAsync(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }

        [Fact]
        public async Task ReturnBook_Should_Return_OkResult_With_Response_When_Successful()
        {
            // Arrange
            var command = new ReturnLoanCommand();
            var response = new BaseResponse<bool> { Success = true };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _loanController.ReturnBook(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<bool>>(okResult.Value);
            Assert.True(actualResponse.Success);
        }

        [Fact]
        public async Task ReturnBook_Should_Return_BadRequest_With_Response_When_Unsuccessful()
        {
            // Arrange
            var command = new ReturnLoanCommand();
            var response = new BaseResponse<bool> { Success = false };
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(response);

            // Act
            var result = await _loanController.ReturnBook(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var actualResponse = Assert.IsType<BaseResponse<bool>>(badRequestResult.Value);
            Assert.False(actualResponse.Success);
        }
    }
}
