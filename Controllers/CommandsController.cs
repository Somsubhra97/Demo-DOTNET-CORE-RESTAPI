using System.Collections.Generic;
using Project.Data;
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Project.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        //private readonly MockCommander repo=new MockCommander();

        private readonly ICommanderRepo _repository;
        
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
           
        }
       
        //GET api/commands
        [HttpGet]
        public IActionResult GetAllCommmands()
        {         

            //With dep injection
            return Ok(_repository.GetAllCommands());       
          
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public IActionResult GetCommandById(int id)
        {
            //With dep injection
            Command commandItem = _repository.GetCommandById(id);
            if(commandItem == null)            
                return NotFound();            
            
          
            return Ok(commandItem);
            
        }  
        [HttpGet("GetAll")]
        public async Task<IActionResult> Getter (){
           var ob=_repository.Getter();
             Console.Write(ob);            
             return Ok(ob);
        } 
 

        // [HttpPost]
    // public IActionResult Add(commandCreateDto cmd){
       
        //     var ret=_repository.CreateCommand(cmd);                       
        //     return Ok(ret);            
        // }
    // public IActionResult Add(Command cmd){
        //     List<Command>  ret=_repository.CreateCommand(commandModel);                       
        //     return Ok(ret);            
        // }
        


        // [HttpPut("{id}")]
    // public IActionResult Put(commandUpdateDto cmd,int id){       
        //     var ret=_repository.UpdateCommand(cmd,id);        
        //     if(!ret.Success){
        //        return NotFound(ret)
        //      }      
        //     return Ok(ret);            
        // }         
    // public IActionResult Put(commandUpdateDto cmd,int id){        
        //     Command ret=_repository.UpdateCommand(commandModel,id);        
        //     if(ret==null){
        //        return NotFound();
        //      }           
        //     return Ok(ret);
            
        // }            
    }
}