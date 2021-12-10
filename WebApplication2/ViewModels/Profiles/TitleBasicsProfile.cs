using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx;
using EfEx.Domain;


namespace WebService.ViewModels.Profiles
{
    public class TitleBasicsProfile : Profile
    {
        public TitleBasicsProfile()
        {
            CreateMap<TitleBasics, TitleBasicsViewModel>();
            //CreateMap<CreateStructuredStringViewModel, StructuredStringSearch>();
        }

    }
}
