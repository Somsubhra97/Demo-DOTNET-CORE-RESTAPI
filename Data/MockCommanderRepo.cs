using System.Collections.Generic;
using Project.Models;
using System.Threading.Tasks;
using Project.Dtos.Command;
using AutoMapper;
using System;

namespace Project.Data
{
    public class MockCommanderRepo : ICommanderRepo///
    {
      private static List<Command> commands= new List<Command>
        {
            new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
            new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="knife & chopping board"},
            new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"}
        };
        private readonly IMapper _mapper;  
        public MockCommanderRepo(IMapper mapper)
        {  
            _mapper = mapper;
        }

      public List<Command> GetAllCommands()
        {

           return commands;
        }

      public Command GetCommandById(int id)
        {
           Command x=null;
           
           try{
            foreach (Command cmd in commands) 
            {
                if(cmd.Id==id)
                 x=cmd;
            } 
            if(x==null) throw new Exception("NOT FOUND"); 
           }
           catch(Exception e){
            Console.Write(e.Message);
           }
            
            return x;          
        }

        public async Task<ServiceResponse<List<GetCommandDto>>> Getter(){
           // ServiceResponse<List<Command>> ob=new ServiceResponse<List<Command>>();
           // ob.Data=commands;
            ServiceResponse<List<GetCommandDto>> ob=new ServiceResponse<List<GetCommandDto>>();
            //ob.Data=commands.Select(i=>_mapper.Map<GetCommandDto>(i)).toList(); 
            List<GetCommandDto> op=new List<GetCommandDto>();
            foreach (Command i in commands) 
            {
                op.Add(_mapper.Map<GetCommandDto>(i));
            }
            ob.Data=op;
            return ob;
        }
 
    }
}
    //public ServiceResponse<GetCommandDto> GetCommandById(int id){
        //         ServiceResponse<CommandGetDto> ob=new ServiceResponse<Command>();
        //         Command x=null;
        //         ob.Data= _mapper.Map<GetCommandDto>(commands.FirstOrDefault(c=>c.id==id));  
        //         return ob;          
        //     }
    //public Command GetCommandById(int id){
        //         Command x=null;
        //         foreach (Command cmd in commands){
        //             if(cmd.Id==id)
        //              x=cmd;
        //         }  
        //         return x;      
        //     }



    //  public ServiceResponse<List<GetCommandDto>> CreateCommand(CommandCreateDto data){
        //     Command cmd = _mapper.Map<Command>(data);
        //      Random r = new Random();
        //      int random= r.Next(10,50);
        //      cmd.Id=random;
        //      commands.Add(cmd);
        //      ServiceResponse<List<CommandGetDto>> ob=new ServiceResponse<List<CommandGetDto>>();
        //      ob.Data=commands.Select(i=>_mapper.Map<GetCommandDto>(i)).toList(); 
        //      return ob;
        // }
    //  public Command CreateCommand(Command data){
        //      commands.Add(data);        
        //      return commands;
        // }



    //public ServiceResponse<GetCommandDto> UpdateCommand(CommandUpdateDto data,int id){
        //    ServiceResponse<CommandGetDto> ob=new ServiceResponse<CommandGetDto>();
        //    Comand commnd=null;
        //    try{
        //      commnd= commands.FirstOrDefault(i=>i.Id == id);
        //      command.Howto=data.Howto;
        //      ob.Data=_mapper.Map<GetCommandDto>(command);
        //    }

        //    catch(Exception e){
        //         ob.Success=false;
        //         ob.Message=e.Message
        //    }
        //      return ob;          
        //   }
    //public Command UpdateCommand(Command data,int id){
        //    Comand commnd=null;
        //      commnd= commands.FirstOrDefault(i=>i.Id == id);
        //      command.Howto=data.Howto;         
        //      return command;          
        //   }       
    // }
