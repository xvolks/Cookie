package com.ankamagames.dofus.datacenter.dare
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class DareCriteria implements IDataCenter
   {
      
      public static const MODULE:String = "DareCriterias";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(DareCriteria));
       
      
      public var id:uint;
      
      public var nameId:uint;
      
      public var maxOccurence:uint;
      
      public var maxParameters:uint;
      
      public var minParameterBound:int;
      
      public var maxParameterBound:int;
      
      private var _name:String;
      
      public function DareCriteria()
      {
         super();
      }
      
      public static function getDareCriteriaById(param1:int) : DareCriteria
      {
         return GameData.getObject(MODULE,param1) as DareCriteria;
      }
      
      public static function getDareCriterias() : Array
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
