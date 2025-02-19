using System;
using BookManagement.Api.Dtos;
using BookManagement.Api.Entities;
using BookManagement.Api.Services;
using BookManagement.Api.UoW;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthService _authService;

        public UserController(IUnitOfWork unitOfWork, AuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        // CREATE: Thêm mới User
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterDto reqDto)
        {
            if (await _unitOfWork.Users.GetByUsernameAsync(reqDto.Username) != null)
            {
                return BadRequest(new ErrorDto("400", "InvalidRequest", "Username already exists"));
            }

            var user = new User
            {
                Username = reqDto.Username,
                Password = _authService.HashPassword(reqDto.Username + reqDto.Password) // Mã hóa mật khẩu trước khi lưu
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();  // Commit thay đổi vào cơ sở dữ liệu

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // READ: Lấy tất cả User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        // READ: Lấy User theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // UPDATE: Cập nhật thông tin User
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegisterDto reqDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Password = _authService.HashPassword(reqDto.Password); // Mã hóa mật khẩu trước khi lưu

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return NoContent(); // Trả về 204 No Content khi cập nhật thành công
        }

        // DELETE: Xóa User theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _unitOfWork.Users.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            return NoContent(); // Trả về 204 No Content khi xóa thành công
        }
    }
}

