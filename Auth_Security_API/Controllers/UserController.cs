using Auth_Security_API.Dtos;
using Auth_Security_Domain.Commands;
using Auth_Security_Domain.Entities;
using Auth_Security_Domain.Queries;
using Auth_Security_Domain.Repositories;
using Microsoft.AspNetCore.Mvc;




namespace Auth_Security_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public UserController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Enregistrer")]
        public IActionResult Enregistrer(AjoutUtilisateurDTO dto)
        {
            try
            {
                _authRepository.Handle(new EnregistrementCommand(dto.Nom, dto.Prenom, dto.Email, dto.Passwd));
                return Ok();
            }
            catch (Exception ex)
            {

               return BadRequest();

            }
        }

        [HttpPost("Connexion")]
        public IActionResult Connexion(ConnexionUtilisateurDTO dto)
        {
            try
            {
                Utilisateur? utilisateur = _authRepository.Handle(new ConnexionQuery(dto.Email, dto.Passwd));
                return utilisateur is not null ? Ok(utilisateur) : BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest();

            }
        }

    }
}
