using Domain;
using AutoMapper;
namespace Persistence;
public class PersistenceProfile : Profile{
public PersistenceProfile(){
    CreateMap<Domain.Root,Root>();
    CreateMap<Domain.UniqueProperty,UniqueProperty>();
    CreateMap<Domain.SharedObject,SharedObject>();
    CreateMap<Root,Domain.Root>();
    CreateMap<UniqueProperty,Domain.UniqueProperty>();
    CreateMap<SharedObject,Domain.SharedObject>();
}

}
