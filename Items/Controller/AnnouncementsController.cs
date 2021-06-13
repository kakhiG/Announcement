
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	[ApiConventionType(typeof(DefaultApiConventions))]
	public class AnnouncementsController : ControllerBase
	{
		private readonly IProductService _service;

		public AnnouncementsController(IProductService service)
		{
			this._service = service;
		}

		// GET: api/<controller>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Announcement>>> Get()
		{
			return await this._service.GetItems();
		}

		// GET: api/<controller>/search/{title}
		[HttpGet("search/{term?}")]
		public async Task<ActionResult<IEnumerable<Announcement>>> SearchItems(string term)
		{
			return await this._service.SearchItems(term);
		}


		// GET api/<controller>/5
		[HttpGet("{id}", Name = "GetItem")]
		public async Task<ActionResult<Announcement>> Get(int id)
		{
			var item = await this._service.GetItem(id);

			if (item == null)
			{
				return NotFound();
			}

			return item;
		}

		// POST api/<controller>
		[HttpPost]
		public async Task<ActionResult<Announcement>> Post(Announcement item)
		{
			await this._service.CreateItem(item);
			return CreatedAtRoute("GetItem", new { id = item.Id }, item);
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var item = await this._service.GetItem(id);

			if (item == null)
			{
				return NotFound();
			}

			await this._service.DeleteItem(item);

			return NoContent();
		}

		// PUT api/<controller>/{id}
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, Announcement item)
		{
			if (id != item.Id)
			{
				return BadRequest();
			}

			await this._service.UpdateItem(item);

			return NoContent();
		}
	}


}