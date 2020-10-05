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

        
        //ServiceResponse<List<GetCommandDto>> GetAllCommands();
       // ServiceResponse<GetCommandDto> GetCommandById(int id);
      //  ServiceResponse<List<GetCommandDto>> Post(Command data)
     //   ServiceResponse<List<GetCommandDto>> Put(Command data,int id)
    }
}