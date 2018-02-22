using FinalKnockoutJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalKnockoutJS.Controllers
{
    public class GameController : ApiController
    {
        // GET: api/Game
        public IEnumerable<Game> Get()
        {
            var game = GameRepository.GetGames();
            return game.ToList();
        }

        // GET: api/Game/5
        public Game Get(int id)
        {
            return GameRepository.GetGames().Where((g) => g.Id == id).FirstOrDefault();
        }

        // POST: api/Game
        public HttpResponseMessage Post(Game value)
        {
            GameRepository.InsertGame(value);

            var response = Request.CreateResponse<Game>(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = value.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT: api/Game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Game/5
        public void Delete(int id)
        {
        }
    }
}
