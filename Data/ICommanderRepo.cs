using System.Collections.Generic;
using Project.Models;
using System.Threading.Tasks;
using Project.Dtos.Command;

namespace Project.Data
{
    public interface ICommanderRepo
    {
        List<Command> GetAllCommands();
        Command GetCommandById(int id);           

        
      Task<ServiceResponse<List<GetCommandDto>>> Getter();   
      ServiceResponse<GetCommandDto> GetCommandDtoById(int id);
      ServiceResponse<List<GetCommandDto>> CreateCommand(CommandCreateDto data);
      ServiceResponse<GetCommandDto> UpdateCommand(CommandUpdateDto data,int id);
    }
}