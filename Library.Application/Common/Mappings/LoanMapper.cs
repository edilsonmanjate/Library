using AutoMapper;

using Library.Application.DTOs;
using Library.Application.Features.Loans.Commands.CreateLoanCommand;
using Library.Application.Features.Loans.Commands.UpdateLoanCommand;
using Library.Core.Entities;

namespace Library.Application.Common.Mappings
{
    internal class LoanMapper : Profile
    {
        public LoanMapper()
        {
            CreateMap<Loan, LoanDto>().ReverseMap();
            CreateMap<Loan, CreateLoanCommand>().ReverseMap();
            CreateMap<Loan, UpdateLoanCommand>().ReverseMap();
        }
    }
    
}
