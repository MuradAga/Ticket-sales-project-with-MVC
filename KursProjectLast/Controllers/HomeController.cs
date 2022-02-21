using AutoMapper;
using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.Filters;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Xml.Linq;

namespace KursProjectLast.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;
        private readonly IFlightService _flightService;
        private readonly ICityService _cityService;
        private readonly IAirlineService _airlineService;
        private readonly ITicketService _ticketService;
        private readonly IPassengerService _passengerService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper,DataContext dataContext, IUserService userService, IFlightService flightService, ICityService cityService, IAirlineService airlineService, ITicketService ticketService, IPassengerService passengerService)
        {
            _logger = logger;
            _mapper = mapper;
            _dataContext = dataContext;
            _userService = userService;
            _flightService = flightService;
            _cityService = cityService;
            _airlineService = airlineService;
            _ticketService = ticketService;
            _passengerService = passengerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Baku&mode=xml&lang=az&units=metric&appid=c5e752e8f2e7f45ce3c40c6845b24c4a";
            XDocument weather = XDocument.Load(connection);
            WeatherDetails details = new WeatherDetails();
            details.Degree = (weather.Descendants("temperature").ElementAt(0).Attribute("value").Value).ToString();
            details.Clouds = (weather.Descendants("clouds").ElementAt(0).Attribute("name").Value).ToString();
            details.Icon = (weather.Descendants("weather").ElementAt(0).Attribute("icon").Value).ToString() + ".png";
            ViewData["Temperature"] = details.Degree.Substring(0, details.Degree.IndexOf('.')) + "°C";
            ViewData["Clouds"] = details.Clouds;
            ViewData["Icon"] = details.Icon;
            return View();
        }
        public async Task<IActionResult> CovidDetails()
        {
            var client = new RestClient("https://api.covid19api.com/live/country/Azerbaijan/status/");
            var request = new RestRequest("confirmed");
            var responce = client.Execute(request);

            CovidDetailsViewModel covidDetailsViewModel = new CovidDetailsViewModel();

            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string resp = responce.Content;

                List<CovidDetails> result = JsonConvert.DeserializeObject<List<CovidDetails>>(resp);

                int totalConfirmed = result[result.Count - 1].Confirmed;
                int totalDeaths = result[result.Count - 1].Deaths;
                int Confirmed = result[result.Count - 1].Confirmed - result[result.Count - 2].Confirmed;
                int Deaths = result[result.Count - 1].Deaths - result[result.Count - 2].Deaths;

                covidDetailsViewModel.TotalConfirmed = totalConfirmed;
                covidDetailsViewModel.TotalDeaths = totalDeaths;
                covidDetailsViewModel.Confirmed = Confirmed;
                covidDetailsViewModel.Deaths = Deaths;

            }
            return View("CovidDetails",covidDetailsViewModel);
        }
        public async Task<IActionResult> SearchTicket(string text)
        {
            List<TicketToListDTO> tickets = await _ticketService.SearchTickets(text);
            return View("ReservedTicketsPanel", tickets);
        }
        public async Task<IActionResult> SellTicket(int id)
        {
            TempData["flightId"] = id;
            FlightToListDTO flightToListDTO = await _flightService.GetFlight(id);
            TicketViewModel ticket = new TicketViewModel();
            ticket.FlightId = id;
            return View("SellTicketToPassenger", ticket);
        }
        public async Task<IActionResult> ReserveTicket(TicketViewModel ticket)
        {
            PassengerToAddDTO passengerToAddDTO = _mapper.Map<PassengerToAddDTO>(ticket);
            PassengerToListDTO passengerToListDTO = await _passengerService.Add(passengerToAddDTO);
            ticket.PassengerId = passengerToListDTO.PassengerId;
            ticket.FlightId = Convert.ToInt32(TempData["flightId"]);
            TicketToListDTO ticketToListDTO;
            int id = 0;
            for (int i = 0; i < ticket.NumberOfPlace; i++)
            {
                ticketToListDTO = await _ticketService.Add(_mapper.Map<TicketToAddDTO>(ticket));
                id = ticketToListDTO.FlightId;
            }
            
            for (int i = 0; i <= ticket.NumberOfPlace; i++)
            {
                FlightToListDTO flightToListDTO = await _flightService.GetFlight(id);
                Flight flight = _mapper.Map<Flight>(flightToListDTO);
                flight.NumberOfPlace -= ticket.NumberOfPlace;
                _dataContext.SaveChanges();
            }
            return View("Index");
        }
        public async Task<IActionResult> ShowFlights(ReserveTicketViewModel model)
        {
            FlightToListDTO flight = _mapper.Map<FlightToListDTO>(model);
            List<FlightToListDTO> flights = new List<FlightToListDTO>();
            flights = await _flightService.GetFlights(flight.FromId, flight.ToId, flight.Departure);
            return View("SellTicket", flights);
        }

        [HttpGet]
        public async Task<IActionResult> GoReserveTicketPanel()
        {
            ReserveTicketViewModel model = new ReserveTicketViewModel();
            model.Cities = await _cityService.GetCities();
            model.Airlines = await _airlineService.GetAirlines();
            return View("ReserveTicketPanel", model);
        }
        [HttpGet]
        public async Task<IActionResult> GoReservedTicketsPanel()
        {
            List<TicketToListDTO> tickets = await _ticketService.GetTickets();
            return View("ReservedTicketsPanel", tickets);
        }
        public async Task<IActionResult> ShowTicket(int? id)
        {
            if (id != null)
            {
                TicketToListDTO ticket = await _ticketService.GetTicket(id);
                return View("TicketPicture", ticket);
            }
            else
            {
                return View("TicketPicture");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GoFlightPanel()
        {
            CityAirlineViewModel cityAirlineViewModel = new CityAirlineViewModel();
            cityAirlineViewModel.Cities = await _cityService.GetCities();
            cityAirlineViewModel.Airlines = await _airlineService.GetAirlines();
            return View("AddFlightPanel", cityAirlineViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlight(CityAirlineViewModel cityAirlineViewModel)
        {
            cityAirlineViewModel.Departure = Convert.ToDateTime(cityAirlineViewModel.Departure).ToString("MM/dd/yyyy HH:mm");
            await _flightService.Add(_mapper.Map<FlightToAddDTO>(cityAirlineViewModel));
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}