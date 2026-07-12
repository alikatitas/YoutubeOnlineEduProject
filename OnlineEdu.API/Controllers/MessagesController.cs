using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDTOS;
using OnlineEdu.DTO.DTOs.MessageDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IGenericService<Message> _messageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _messageService.TGetById(id);
            if (value is null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _messageService.TDelete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Create(CreateMessageDto createMessageDto)
        {
            var newValue = _mapper.Map<Message>(createMessageDto);
            _messageService.TCreate(newValue);
            return Ok("Yeni Mesaj alanı oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesaj alanı güncellendi");
        }
    }
}
