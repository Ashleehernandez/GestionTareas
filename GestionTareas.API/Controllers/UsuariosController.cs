using AutoMapper;
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Service;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public UsuariosController(IAuthService authService , IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var usuario = await _authService.GetByEmailAsync(email);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        [HttpPost("Usuarios")]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuarios>(usuarioDto); 

                await _authService.CreateAsync(usuario);

                return CreatedAtAction(nameof(GetByEmail), new { email = usuario.Email }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("All")]
            public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _authService.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _authService.RemoveAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                var existingUsuario = await _authService.GetByIdAsync(id);
                if (existingUsuario == null)
                {
                    return NotFound();
                }

                _mapper.Map(usuarioDto, existingUsuario);

                await _authService.CreateAsync(existingUsuario); 
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
