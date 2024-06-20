using Application.DTO.Messages;
using Application.UseCases.Commands.Messages;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Messages
{
    public class EfCreateMessageCommand : EfUseCase,ICreateMessageCommand
    { 
        private readonly CreateMessageValidator _validator;

        public EfCreateMessageCommand(CozaStoreContext context, CreateMessageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 38;

        public string Name => "Send Message";

        public string Table => "Messages";

        public void Execute(CreateMessageDTO data)
        {
            _validator.ValidateAndThrow(data);

            Context.Messages.Add(new Domain.Message
            {
                Email = data.Email,
                Subject = data.Subject,
                FullName = data.FullName,
                MessageText = data.MessageText,
                SendedAt = DateTime.UtcNow,
            });

            Context.SaveChanges();
        }
    }
}
