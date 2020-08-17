package com.ankamagames.dofus.datacenter.communication
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class Smiley#4572 implements IDataCenter
   {
      
      public static const MODULE:String = "Smileys";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(Smiley#4572));
       
      
      public var id:uint;
      
      public var order:uint;
      
      public var gfxId:String;
      
      public var forPlayers:Boolean;
      
      public var triggers:Vector.<String>;
      
      public var referenceId:uint;
      
      public var categoryId:uint;
      
      public function Smiley#4572()
      {
         super();
      }
      
      public static function getSmileyById(param1:int) : Smiley#4572
      {
         return GameData.getObject(MODULE,param1) as Smiley#4572;
      }
      
      public static function getSmileys() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
