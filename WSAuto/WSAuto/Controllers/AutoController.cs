using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WSAuto.Data;
using WSAuto.Models;

namespace WSAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AutoDbContext context;
        public AutoController(AutoDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return context.Auto.ToList();
        }

        [HttpGet("GetByModel/{model}")]
        public IEnumerable<Auto> GetByModel(string model)
        {
            var autos = (from a in context.Auto
                         where a.Modelo == model
                         select a).ToList();
            return autos;
        }

        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            context.Auto.Add(auto);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Auto> Get(int id)
        {
            return context.Auto.Find(id);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }
            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            Auto auto = context.Auto.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            context.Auto.Remove(auto);
            context.SaveChanges();
            return auto;
        }

        [HttpGet("GetByModelAndBrand/{model}/{brand}")]
        public IEnumerable<Auto> GetByModelAndBrand(string model, string brand)
        {
            var auto = (from a in context.Auto
                         where a.Modelo == model
                         && a.Marca == brand
                         select a).ToList();
            return auto;
        }

        [HttpGet("GetByColor/{color}")]
        public IEnumerable<Auto> GetByColor(string color)
        {
            var auto = (from a in context.Auto
                         where a.Color == color
                         select a).ToList();
            return auto;
        }
    }
}