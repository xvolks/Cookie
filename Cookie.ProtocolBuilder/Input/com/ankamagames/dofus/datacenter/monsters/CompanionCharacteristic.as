package com.ankamagames.dofus.datacenter.monsters
{
   import com.ankamagames.dofus.datacenter.characteristics.Characteristic;
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class CompanionCharacteristic implements IDataCenter
   {
      
      public static const MODULE:String = "CompanionCharacteristics";
       
      
      public var id:int;
      
      public var caracId:int;
      
      public var companionId:int;
      
      public var order:int;
      
      public var statPerLevelRange:Vector.<Vector.<Number>>;
      
      private var _name:String;
      
      public function CompanionCharacteristic()
      {
         super();
      }
      
      public static function getCompanionCharacteristicById(param1:uint) : CompanionCharacteristic
      {
         return GameData.getObject(MODULE,param1) as CompanionCharacteristic;
      }
      
      public static function getCompanionCharacteristics() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get name() : String
      {
         var _loc1_:Characteristic = null;
         if(!this._name)
         {
            _loc1_ = Characteristic.getCharacteristicById(this.caracId);
            if(_loc1_)
            {
               this._name = _loc1_.name;
            }
            else
            {
               this._name = "???";
            }
         }
         return this._name;
      }
   }
}
