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
    private readonly DataContext _context;
    public MockCommanderRepo(IMapper mapper, DataContext dbcontext)
    {  
        _mapper = mapper;
        _context=dbcontext;

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


 //async code
    public async Task<ServiceResponse<List<GetCommandDto>>> Getter(){
        ServiceResponse<List<GetCommandDto>> ob=new ServiceResponse<List<GetCommandDto>>();
        List<GetCommandDto> op=new List<GetCommandDto>();
        foreach (Command i in commands) 
        {
            op.Add(_mapper.Map<GetCommandDto>(i));
        }
        ob.Data=op;
        return ob;
    } 
    public async Task<ServiceResponse<List<GetCommandDto>>> GetterDB(){
        ServiceResponse<List<GetCommandDto>> ob=new ServiceResponse<List<GetCommandDto>>();
        List<Command> dbCommand=new List<Command>();
        dbCommand=await _context.Commands.ToListAsync();
        ob.Data=dbCommand.Select(i=>_ma_mapper.Map<GetCommandDto>(i));
        return ob;
    } 
    

    public ServiceResponse<GetCommandDto> GetCommandDtoById(int id){
        ServiceResponse<CommandGetDto> ob=new ServiceResponse<Command>();        
        ob.Data= _mapper.Map<GetCommandDto>(commands.FirstOrDefault(c=>c.id==id));  
        return ob;          
    }
    public Task<ServiceResponse<GetCommandDto>> GetCommandByIdDB(int id){
         ServiceResponse<CommandGetDto> ob=new ServiceResponse<Command>();        
         Command x=await _context.Commands.FirstOrDefaultAsync(i=>i.id==id);
         ob.Data= _mapper.Map<GetCommandDto>(x);
    }
    // public Command GetCommandById(int id){
    //             Command x=null;
    //             foreach (Command cmd in commands){
    //                 if(cmd.Id==id)
    //                  x=cmd;
    //             }  
    //             return x;      
    //         }



    public ServiceResponse<List<GetCommandDto>> CreateCommand(CommandCreateDto data){
        Command cmd = _mapper.Map<Command>(data);
         Random r = new Random();
         int random= r.Next(10,50);
         cmd.Id=random;
         commands.Add(cmd);
         ServiceResponse<List<CommandGetDto>> ob=new ServiceResponse<List<CommandGetDto>>();
         ob.Data=commands.Select(i=>_mapper.Map<GetCommandDto>(i)).toList(); 
         return ob;
    }
    public ServiceResponse<List<GetCommandDto>> CreateCommandDB(CommandCreateDto data){
        ServiceResponse<List<CommandGetDto>> ob=new ServiceResponse<List<CommandGetDto>>();
        Command cmd = _mapper.Map<Command>(data);
        await _context.Commands.AddAsync(cmd);
        await _context.SaveChanges();

        ob.Data = (_context.Commands.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();

        return ob;

    }
    // public Command CreateCommand(Command data){
     //         commands.Add(data);        
     //         return commands;
     //    }



    public ServiceResponse<GetCommandDto> UpdateCommand(CommandUpdateDto data,int id){
       ServiceResponse<CommandGetDto> ob=new ServiceResponse<CommandGetDto>();
       Comand commnd=null;
       try{
         commnd= commands.FirstOrDefault(i=>i.Id == id);
         command.Howto=data.Howto;
         ob.Data=_mapper.Map<GetCommandDto>(command);
       }

       catch(Exception e){
            ob.Success=false;
            ob.Message=e.Message
       }
       return ob;          
    }
    public ServiceResponse<GetCommandDto> UpdateCommand(CommandUpdateDto data,int id){
       ServiceResponse<CommandGetDto> ob=new ServiceResponse<CommandGetDto>();

       try{

        Command obj=await _context.Commands.FirstOrDefaultAsync(i=>i.id==id);
        obj.Howto=data.Howto;
        _context.Comands.Update(obj);
        await _context.SaveChanges();

        ob.Data =  _mapper.Map<GetCharacterDto>(obj);

       }
       catch(Exception e){
        ob.Message=e.Message;
        ob.Success=false;
       }
       return ob;
   }
    // public Command UpdateCommand(Command data,int id){
    //        Comand commnd=null;
    //          commnd= commands.FirstOrDefault(i=>i.Id == id);
    //          command.Howto=data.Howto;         
    //          return command;          
    //       } 


    Task<ServiceResponse<List<GetCommandDto>>> DeleteDB(int id){
        ServiceResponse<CommandGetDto> ob=new ServiceResponse<CommandGetDto>();
        try{
            Command x=await _context.Commands.FirstOrDefaultAsync(i=>i.id==id);
            _context.Commands.Remove(x);

            ob.Data = (_context.Commands.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
        }
        catch(Exception e){
            ob.Message=e.Message;
            ob.Success=false;
        }
        return ob;
    }      
}
}
