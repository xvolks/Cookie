package com.ankamagames.dofus.datacenter.bonus
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Bonus implements IDataCenter
   {
      
      public static const MODULE:String = "Bonuses";
       
      
      public var id:int;
      
      public var type:uint;
      
      public var amount:int;
      
      public var criterionsIds:Vector.<int>;
      
      public function Bonus()
      {
         super();
      }
      
      public static function getBonusById(param1:int) : Bonus
      {
         return GameData.getObject(MODULE,param1) as Bonus;
      }
      
      public function isRespected(... rest) : Boolean
      {
         return false;
      }
   }
}
