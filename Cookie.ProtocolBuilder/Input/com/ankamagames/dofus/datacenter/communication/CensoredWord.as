package com.ankamagames.dofus.datacenter.communication
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class CensoredWord implements IDataCenter
   {
      
      public static const MODULE:String = "CensoredWords";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(CensoredWord));
       
      
      public var id:uint;
      
      public var listId:uint;
      
      public var language:String;
      
      public var word:String;
      
      public var deepLooking:Boolean;
      
      public function CensoredWord()
      {
         super();
      }
      
      public static function getCensoredWordById(param1:int) : CensoredWord
      {
         return GameData.getObject(MODULE,param1) as CensoredWord;
      }
      
      public static function getCensoredWords() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
