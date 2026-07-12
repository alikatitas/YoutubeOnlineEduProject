using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOs.SubscriberDTOs
{
    public class CreateSubscriberDto
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
