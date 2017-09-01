package com.ankamagames.dofus.datacenter.characteristics
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class CharacteristicCategory implements IDataCenter
   {
      
      public static const MODULE:String = "CharacteristicCategories";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(CharacteristicCategory));
       
      
      public var id:int;
      
      public var nameId:uint;
      
      public var order:int;
      
      public var characteristicIds:Vector.<uint>;
      
      private var _name:String;
      
      public function CharacteristicCategory()
      {
         super();
      }
      
      public static function getCharacteristicCategoryById(param1:int) : CharacteristicCategory
      {
         return GameData.getObject(MODULE,param1) as CharacteristicCategory;
      }
      
      public static function getCharacteristicCategories() : Array
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
