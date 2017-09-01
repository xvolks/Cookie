package com.ankamagames.dofus.datacenter.bonus
{
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusCriterion;
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusEquippedItemCriterion;
   import com.ankamagames.dofus.internalDatacenter.items.ItemWrapper;
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   
   public class MonsterBonus extends MonsterLightBonus
   {
       
      
      public function MonsterBonus()
      {
         super();
      }
      
      override public function isRespected(... rest) : Boolean
      {
         var _loc3_:int = 0;
         var _loc4_:BonusCriterion = null;
         var _loc5_:ItemWrapper = null;
         var _loc2_:Boolean = super.isRespected(rest);
         if(!_loc2_)
         {
            for each(_loc3_ in criterionsIds)
            {
               _loc4_ = BonusCriterion.getBonusCriterionById(_loc3_);
               if(_loc4_ is BonusEquippedItemCriterion)
               {
                  for each(_loc5_ in PlayedCharacterManager.getInstance().inventory)
                  {
                     if(_loc5_.position <= 15 && _loc5_.objectGID == _loc4_.value)
                     {
                        return true;
                     }
                  }
               }
            }
         }
         return _loc2_;
      }
   }
}
