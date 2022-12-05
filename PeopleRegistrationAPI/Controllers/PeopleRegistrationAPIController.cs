using Microsoft.AspNetCore.Mvc;
using PeopleRegistrationAPI.DAL;
using PeopleRegistrationAPI.Models;
namespace PeopleRegistrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleRegistrationAPIController : Controller
    {
        [HttpGet]
        [Route("GetUsers")]

        public IActionResult Get()
        {
            try
            {
                return Ok(new ListUsersDAL().ToList());
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetUsers/{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                ListUsersDAL dal = new ListUsersDAL();
                ListUsersModel listUsers = dal.GetListUsers(id);
                return Ok(listUsers);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost(Name = "GetUsers")]

        public IActionResult Post([FromBody] ListUsersModel listUsers)
        {
            try
            {
                ListUsersDAL dal = new ListUsersDAL();
                dal.Insert(listUsers);
                string location = "https://localhost:7013/PeopleRegistrationAPI";

                return Created(new Uri(location), listUsers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete(Name = "GetUsers")]

        public IActionResult Delete(int id)
        {
            try
            {
                ListUsersDAL dal = new ListUsersDAL();
                dal.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut(Name = "GetUsers")]
        public IActionResult Put([FromBody] ListUsersModel listUsers)
        {
            try
            {
                ListUsersDAL dal = new ListUsersDAL();
                dal.Update(listUsers);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
