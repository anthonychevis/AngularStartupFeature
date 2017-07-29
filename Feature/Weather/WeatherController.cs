﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;


//a30bd294317ae3534e3f7c6612021806

namespace Kit.Feature.Weather
{
    [Authorize]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            try {
                var result = await _mediator.Send(new Weather.Query() { City = city });
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Error getting weather from OpenWeather: {ex.Message}");
            }
        }
    }

  



}
