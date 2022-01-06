using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Application.Controllers;

[ApiController]
[Route("/")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMapper _mapper;
    private readonly ApplicationContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }
    [HttpGet()]
    public object Select(){
        return _context.Roots.Include(x => x.SharedObjects).Include(x => x.UniqueProperties);
    }
    [HttpGet("insert")]
    public object Get(){

        var a = new Domain.Root
        {
            Name = "john",
            IsOkay = true,
            UniqueProperties = new[]{
                new Domain.UniqueProperty{Id = "John's property"}}.ToList()
        };
        var v = _mapper.Map<Domain.Root, Persistence.Root>(a);
        _context.Add(v);
        _context.SaveChanges();
        return new {Domain = a, persistence = v };
    }
    [HttpGet("update")]
    public object Update(){
        var a = _context.Roots.First();
        var b = new Domain.Root
        {
            Name = "John H.",
            IsOkay = false,
            SharedObjects = new[] { new Domain.SharedObject { Id = "shared" } }.ToList(),
        };
        var c = _mapper.Map<Persistence.Root, Domain.Root>(a);
        string ex = "";
        _mapper.Map(b, a);try
        {
            _context.SaveChanges();
        }catch (Exception e){ex = e.ToString(); }

        return new { a= _mapper.Map<Persistence.Root, Domain.Root>(a), b, c,ex };

    }
    [HttpGet("clear")]
    public string Clear(){
        _context.RemoveRange(_context.Roots);
        _context.RemoveRange(_context.SharedObjects);
        _context.RemoveRange(_context.UniqueProperties);
        _context.SaveChanges();
        return "Ok";
    }
}
