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
      Task<ServiceResponse<List<GetCommandDto>>> GetterDB();

      ServiceResponse<GetCommandDto> GetCommandDtoById(int id);
      Task<ServiceResponse<GetCommandDto>> GetCommandByIdDB(int id);

      ServiceResponse<List<GetCommandDto>> CreateCommand(CommandCreateDto data);
      Task<ServiceResponse<List<GetCommandDto>>> CreateCommandDB(CommandCreateDto data);


      ServiceResponse<GetCommandDto> UpdateCommand(CommandUpdateDto data,int id);
      Task<ServiceResponse<GetCommandDto>> UpdateCommandDB(CommandUpdateDto data,int id);

      Task<ServiceResponse<List<GetCommandDto>>> DeleteDB(int id);
    }
}