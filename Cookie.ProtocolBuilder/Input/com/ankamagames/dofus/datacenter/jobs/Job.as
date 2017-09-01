package com.ankamagames.dofus.datacenter.jobs
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Job implements IDataCenter
   {
      
      public static const MODULE:String = "Jobs";
       
      
      public var id:int;
      
      public var nameId:uint;
      
      public var iconId:int;
      
      private var _name:String;
      
      public function Job()
      {
         super();
      }
      
      public static function getJobById(param1:int) : Job
      {
         return GameData.getObject(MODULE,param1) as Job;
      }
      
      public static function getJobs() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get name() : String
      {
         if(!this._name)
         {
            this._name = I18n.getText(this.nameId);
         }
         return this._name;
      }
   }
}
