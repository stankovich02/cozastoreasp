﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Messages
{
    public class CreateMessageDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
    }
}
