package com.ankamagames.dofus.datacenter.bonus.criterion
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class BonusCriterion implements IDataCenter
   {
      
      public static const MODULE:String = "BonusesCriterions";
       
      
      public var id:int;
      
      public var type:uint;
      
      public var value:int;
      
      public function BonusCriterion()
      {
         super();
      }
      
      public static function getBonusCriterionById(param1:int) : BonusCriterion
      {
         return GameData.getObject(MODULE,param1) as BonusCriterion;
      }
   }
}
