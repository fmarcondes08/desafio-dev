using AutoMapper;
using DesafioDevBackEnd.Application.Dtos;
using DesafioDevBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Transaction, TransactionOutputDto>()
                .ForMember(x => x.TransactionsType,
                map => map.MapFrom(
                    source => source.TransactionType));

            CreateMap<TransactionType, TransactionTypeOutputDto>();

            CreateMap<Store, StoreOutputDto>();
        }
    }
}
