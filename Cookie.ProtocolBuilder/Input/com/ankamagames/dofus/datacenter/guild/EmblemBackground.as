package com.ankamagames.dofus.datacenter.guild
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class EmblemBackground implements IDataCenter
   {
      
      public static const MODULE:String = "EmblemBackgrounds";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(EmblemBackground));
       
      
      public var id:int;
      
      public var order:int;
      
      public function EmblemBackground()
      {
         super();
      }
      
      public static function getEmblemBackgroundById(param1:int) : EmblemBackground
      {
         return GameData.getObject(MODULE,param1) as EmblemBackground;
      }
      
      public static function getEmblemBackgrounds() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
