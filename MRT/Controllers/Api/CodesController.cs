using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MRT.Models;
using MRT.Dtos;
using MRT.DataContexts;
using AutoMapper;

namespace MRT.Controllers.Api
{
    public class CodesController : ApiController
    {
        private DataDb _context;
        public CodesController()
        {
            _context = new DataDb();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/codes
        [HttpGet]
        public IHttpActionResult GetCodes()
        {
            var codeDtos = _context.Codes.ToList().Select(Mapper.Map<Code, CodeDto>);

            return Ok(codeDtos);
        }
    }
}
