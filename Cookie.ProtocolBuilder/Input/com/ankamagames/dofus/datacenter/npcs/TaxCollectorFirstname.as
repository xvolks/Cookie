package com.ankamagames.dofus.datacenter.npcs
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class TaxCollectorFirstname implements IDataCenter
   {
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(TaxCollectorFirstname));
      
      public static const MODULE:String = "TaxCollectorFirstnames";
       
      
      public var id:int;
      
      public var firstnameId:uint;
      
      private var _firstname:String;
      
      public function TaxCollectorFirstname()
      {
         super();
      }
      
      public static function getTaxCollectorFirstnameById(param1:int) : TaxCollectorFirstname
      {
         return GameData.getObject(MODULE,param1) as TaxCollectorFirstname;
      }
      
      public function get firstname() : String
      {
         if(!this._firstname)
         {
            this._firstname = I18n.getText(this.firstnameId);
         }
         return this._firstname;
      }
   }
}
