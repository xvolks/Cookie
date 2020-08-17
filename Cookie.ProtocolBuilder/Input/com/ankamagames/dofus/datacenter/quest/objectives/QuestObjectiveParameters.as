package com.ankamagames.dofus.datacenter.quest.objectives
{
   import flash.utils.Proxy;
   import flash.utils.flash_proxy;
   
   public class QuestObjectiveParameters extends Proxy
   {
       
      
      public var numParams:uint;
      
      public var parameter0:int;
      
      public var parameter1:int;
      
      public var parameter2:int;
      
      public var parameter3:int;
      
      public var parameter4:int;
      
      public var dungeonOnly:Boolean;
      
      public function QuestObjectiveParameters()
      {
         super();
      }
      
      override flash_proxy function getProperty(param1:*) : *
      {
         var _loc2_:String = QName(param1).localName;
         if(!isNaN(parseInt(_loc2_)))
         {
            return this["parameter" + _loc2_];
         }
         return this[_loc2_];
      }
      
      public function get length() : uint
      {
         return this.numParams;
      }
   }
}
