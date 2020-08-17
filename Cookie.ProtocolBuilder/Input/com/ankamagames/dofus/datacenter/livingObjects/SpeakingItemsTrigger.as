package com.ankamagames.dofus.datacenter.livingObjects
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class SpeakingItemsTrigger implements IDataCenter
   {
      
      public static const MODULE:String = "SpeakingItemsTriggers";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(SpeakingItemsTrigger));
       
      
      public var triggersId:int;
      
      public var textIds:Vector.<int>;
      
      public var states:Vector.<int>;
      
      public function SpeakingItemsTrigger()
      {
         super();
      }
      
      public static function getSpeakingItemsTriggerById(param1:int) : SpeakingItemsTrigger
      {
         return GameData.getObject(MODULE,param1) as SpeakingItemsTrigger;
      }
      
      public static function getSpeakingItemsTriggers() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
