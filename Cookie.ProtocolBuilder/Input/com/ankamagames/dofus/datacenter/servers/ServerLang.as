package com.ankamagames.dofus.datacenter.servers
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class ServerLang implements IDataCenter
   {
      
      public static const MODULE:String = "ServerLangs";
      
      private static var _log:Logger = Log.getLogger(getQualifiedClassName(ServerLang));
       
      
      public var id:int;
      
      public var nameId:uint;
      
      public var langCode:String;
      
      private var _name:String;
      
      public function ServerLang()
      {
         super();
      }
      
      public static function getServerLangById(param1:int) : ServerLang
      {
         return GameData.getObject(MODULE,param1) as ServerLang;
      }
      
      public static function getServerLangs() : Array
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
