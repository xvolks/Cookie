package com.ankamagames.dofus.datacenter.npcs
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class NpcAction implements IDataCenter
   {
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(NpcAction));
      
      public static const MODULE:String = "NpcActions";
       
      
      public var id:int;
      
      public var realId:int;
      
      public var nameId:uint;
      
      private var _name:String;
      
      public function NpcAction()
      {
         super();
      }
      
      public static function getNpcActionById(param1:int) : NpcAction
      {
         return GameData.getObject(MODULE,param1) as NpcAction;
      }
      
      public static function getNpcActions() : Array
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
