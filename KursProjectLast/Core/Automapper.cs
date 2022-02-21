
using AutoMapper;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.Core
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<User, UserToAddDTO>().ReverseMap();
            CreateMap<User, UserToListDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();

            CreateMap<Flight, FlightToAddDTO>().ReverseMap();
            CreateMap<Flight, FlightToListDTO>().ReverseMap();
            CreateMap<FlightToListDTO, ReserveTicketViewModel>().ReverseMap();

            CreateMap<Passenger, PassengerToListDTO>().ReverseMap();
            CreateMap<Passenger, PassengerToAddDTO>().ReverseMap();

            CreateMap<City, CityToListDTO>().ReverseMap();

            CreateMap<Airline, AirlineToListDTO>().ReverseMap();

            CreateMap<CityAirlineViewModel, FlightToAddDTO>().ReverseMap();

            CreateMap<Ticket, TicketToListDTO>().ReverseMap();
            CreateMap<Ticket, TicketToAddDTO>().ReverseMap();
            CreateMap<TicketViewModel, PassengerToAddDTO>().ReverseMap();
            CreateMap<TicketViewModel, FlightToListDTO>().ReverseMap();
            CreateMap<TicketViewModel, TicketToAddDTO>().ReverseMap();

        }
    }
}
