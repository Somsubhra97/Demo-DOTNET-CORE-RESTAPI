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

        
        //ServiceResponse<List<Command>> GetAllCommands();
       // ServiceResponse<Command> GetCommandById(int id);
      //  ServiceResponse<List<Command>> Post(Command data)
     //   ServiceResponse<List<Command>> Put(Command data,int id)
    }
}